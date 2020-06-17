using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager gm;

    public Text UILevel;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public SceneData data;

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
        pausePanel = data.pause;
        UILevel = data.level;
        inventoryPanel = data.inventoryCanvas;
        _scene = SceneManager.GetActiveScene();
        _player = data.player;
        // Pause and pause menu toggle
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (Time.timeScale > 0f) {
                // when paused
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
            } else {
                // when unpaused
                pausePanel.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {

            if (!inventoryPanel.activeSelf)
            {
                Inventory.inventory.UpdatePanelSlots();
                Inventory.inventory.UpdateAvatarSlots();
                data.playerInfo.SetActive(false);
                inventoryPanel.SetActive(true);
                data.goldHeader.SetActive(true);
                data.goldPieces.gameObject.SetActive(true);
                data.avatarHeader.SetActive(true);
                data.avatarPanel.SetActive(true);
                data.currentAvatar.gameObject.SetActive(true);
            }
            else
            {
                data.playerInfo.SetActive(true);
                inventoryPanel.SetActive(false);
                data.goldHeader.SetActive(false);
                data.goldPieces.gameObject.SetActive(false);
                data.avatarHeader.SetActive(false);
                data.avatarPanel.SetActive(false);
                data.currentAvatar.gameObject.SetActive(false);
            }
        }

        if (_scene.name.Equals("TesterScene") && Time.time  >= nextSpawnTime) {
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

        pausePanel.SetActive(false);

        nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawning;
        _scene = SceneManager.GetActiveScene();
        if (PlayerPrefs.HasKey("overworldX") && _scene.name.Equals("TesterScene")){
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
		GameObject spawnedObject = Instantiate (EnemyTraps [objectToSpawn], _player.transform.position + spawnPosition, transform.rotation) as GameObject;

		// make the parent the spawner so hierarchy doesn't get super messy
		spawnedObject.transform.parent = gameObject.transform;
    }

    public void EnterSubArea(string nextLevel) 
    {
        PlayerPrefsManager.SavePlayerState(_player.GetComponent<RubyController>().health, 
            _player.GetComponent<Player>().baseStats.GetStats("xp"));
        if (_scene.name.Equals("TesterScene"))
        {
            PlayerPrefsManager.PlayerOverworldPosition(_player.transform.position.x,_player.transform.position.y,
                _player.transform.position.z);
        }
        StartCoroutine(LoadNextLevel(nextLevel));
    }

    public void refreshGui() {
        data.level.text = (Mathf.FloorToInt(50 + Mathf.Sqrt(625 + 100 * 
            Player.player.baseStats.GetStats("xp")))/100).ToString();
    }

    IEnumerator LoadNextLevel(string nextLevel) {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(nextLevel);
    }
}
