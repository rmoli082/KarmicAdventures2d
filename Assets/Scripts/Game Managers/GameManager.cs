﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private enum OVERWORLD {OverworldA};

    public static GameManager gm;

    public SceneData data;

    public string playerName;

    public GameObject[] EnemyTraps;
    public float secondsBetweenSpawning = 2.0f;
	public float xMinRange = -5.0f;
	public float xMaxRange = 5.0f;
	public float yMinRange = 2f;
	public float yMaxRange = 2f;

    public bool gameIsOver = false;

    private float nextSpawnTime;

    GameObject _player;
    Scene _scene;
    Vector3 _spawnLocation;

    void Awake()
    {
        if (gm == null) {
            gm = this.GetComponent<GameManager>();
        } 
        else if (gm != this)
        {
            Destroy(gameObject);
        }

        setupDefaults();
    }

    // Update is called once per frame
    void Update()
    {
        data = FindObjectOfType<SceneData>();
        _scene = SceneManager.GetActiveScene();
        // Pause and pause menu toggle
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale > 0f) {
                // when paused
                data.pause.SetActive(true);
                Time.timeScale = 0f;
            } else {
                // when unpaused
                data.pause.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            if (!data.inventoryCanvas.activeSelf)
            {
                Inventory.inventory.UpdatePanelSlots();
                Inventory.inventory.UpdateAvatarSlots();
                ShowHidePanels(true);
            }
            else
            {
                ShowHidePanels(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!data.questPanel.activeSelf)
            {
                QuestManager.questManager.UpdateQuestUI();
                data.questPanel.SetActive(true);
            }
            else
            {
                data.questPanel.SetActive(false);
            }
        }

        if (System.Enum.IsDefined(typeof(OVERWORLD), _scene.name) && Time.time  >= nextSpawnTime) {
            int random = Random.Range (0,2);
            if (random == 1) {
                SpawnEnemyTrap();
                nextSpawnTime = Time.time + secondsBetweenSpawning;
            }
        }

        refreshGui();
        
    }

    void setupDefaults() {
        if (_player == null) {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        data = FindObjectOfType<SceneData>();

        data.pause.SetActive(false);

        nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawning;
        _scene = SceneManager.GetActiveScene();
        if (PlayerPrefs.HasKey("overworldX") && System.Enum.IsDefined(typeof(OVERWORLD), _scene.name)){
            _spawnLocation.x = PlayerPrefs.GetFloat("overworldX") - 0.5f;
            _spawnLocation.y = PlayerPrefs.GetFloat("overworldY") - 0.5f;
            _spawnLocation.z = PlayerPrefs.GetFloat("overworldZ");

            _player.transform.position = _spawnLocation;
        }
        refreshGui();
        
    }

    void SpawnEnemyTrap() {
        Vector3 spawnPosition;

		// get a random position between the specified ranges
		spawnPosition.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = Random.Range (yMinRange, yMaxRange);
		spawnPosition.z = 0;

		// determine which object to spawn
		int objectToSpawn = Random.Range (0, EnemyTraps.Length);

        // actually spawn the game object
        _player = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnedObject = Instantiate (EnemyTraps [objectToSpawn], _player.transform.position + spawnPosition, transform.rotation) as GameObject;

		// make the parent the spawner so hierarchy doesn't get super messy
		spawnedObject.transform.parent = GameObject.FindGameObjectWithTag("EnemyDoor").transform;
    }

    void ShowHidePanels(bool showPanels)
    {
        data.playerInfo.SetActive(!showPanels);
        data.inventoryCanvas.SetActive(showPanels);
        data.goldHeader.SetActive(showPanels);
        data.goldPieces.gameObject.SetActive(showPanels);
        data.avatarHeader.SetActive(showPanels);
        data.avatarPanel.SetActive(showPanels);
        data.currentAvatar.gameObject.SetActive(showPanels);
    }

    public void EnterSubArea(string nextLevel) 
    {
        if (!_scene.name.Equals("OpeningStory"))
        {
            PlayerPrefsManager.SavePlayerState(Player.player.baseStats.GetStats("xp"),
                Player.player.baseStats.GetStats("hpnow"), Player.player.baseStats.GetStats("hpmax"),
                Player.player.baseStats.GetStats("mpnow"), Player.player.baseStats.GetStats("mpmax"),
                Player.player.baseStats.GetStats("attack"), Player.player.baseStats.GetStats("defense"),
                Player.player.baseStats.GetStats("magic"), Player.player.baseStats.GetStats("karma"));
        }
        if (System.Enum.IsDefined(typeof(OVERWORLD), _scene.name))
        {
            PlayerPrefsManager.SetPlayerOverworldPosition(_player.transform.position.x,_player.transform.position.y,
                _player.transform.position.z);
        }
        StartCoroutine(LoadNextLevel(nextLevel));
    }

    public void refreshGui()
    {
        if (!_scene.name.Equals("OpeningStory"))
        {
            data.level.text = Player.player.baseStats.GetStats("level").ToString();
        }
    }

    IEnumerator LoadNextLevel(string nextLevel)
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(nextLevel);
    }
}
