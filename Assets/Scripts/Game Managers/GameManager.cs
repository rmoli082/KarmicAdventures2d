using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private enum OVERWORLD {OverworldA};

    public static GameManager gm;

    public SceneData data;

    public GameObject[] EnemyTraps;
    public float secondsBetweenSpawning = 5.0f;
	public float xMinRange = -5.0f;
	public float xMaxRange = 5.0f;
	public float yMinRange = 2f;
	public float yMaxRange = 2f;

    public bool gameIsOver = false;

    private float nextSpawnTime;

    GameObject _player;
    Scene _scene;
    Vector3 _spawnLocation;

    [SerializeField]
    string locationName;
    string lastLocation;

    void Awake()
    {
        if (gm == null) {
            gm = this.GetComponent<GameManager>();
        } 
        else if (gm != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        GameEvents.LocationFound += SetCurrentLocation;
        SceneManager.sceneLoaded += OnSceneLoaded;
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
                SetInventoryActive(true);
            }
            else
            {
                SetInventoryActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!data.questPanel.activeSelf)
            {
                QuestManager.questManager.UpdateQuestUI();
                data.questPanel.SetActive(true);
                data.overviewMap.SetActive(false);
            }
            else
            {
                data.questPanel.SetActive(false);
                data.overviewMap.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Period))
        {
            if (!data.levelUpPanel.activeSelf)
            {
                Time.timeScale = 0f;
                data.levelUpPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                data.levelUpPanel.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (!data.overviewMap.activeSelf)
            {
                data.overviewMap.SetActive(true);
            }
            else
            {
                data.overviewMap.SetActive(false);
            }
        }

        if (System.Enum.IsDefined(typeof(OVERWORLD), _scene.name) && Time.timeSinceLevelLoad  >= nextSpawnTime) {
            int random = Random.Range (0,3);
            if (random == 1) {
                SpawnEnemyTrap();
                nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawning;
            }
        }
        
    }

    void setupDefaults() {
        if (_player == null) {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        data = FindObjectOfType<SceneData>();

        data.pause.SetActive(false);

        nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawning;
        _scene = SceneManager.GetActiveScene();

        if (System.Enum.IsDefined(typeof(OVERWORLD), _scene.name)){
            if (System.Enum.IsDefined(typeof(OverlandEnemyTrap.Levels), CharacterSheet.charSheet.GetLastLevel()))
            {
                Vector3 spawnPosition = new Vector3();
                spawnPosition.x = PlayerPrefs.GetFloat("overworldX");
                spawnPosition.y = PlayerPrefs.GetFloat("overworldY");
                spawnPosition.z = PlayerPrefs.GetFloat("overworldZ");

                _player.transform.position = spawnPosition;
            }
            else
            {
                GameObject[] spawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
                foreach (GameObject spawn in spawnPoints)
                {
                    if (spawn.name == CharacterSheet.charSheet.GetLastLevel())
                    {
                        _player.transform.position = spawn.transform.position;
                    }
                }
            }
        }

        locationName = SceneManager.GetActiveScene().name;
        
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

    public void SetInventoryActive(bool showPanels)
    {
        data.playerInfo.SetActive(!showPanels);
        data.inventoryCanvas.SetActive(showPanels);
        data.tooltip.SetActive(showPanels);
    }

    public void EnterSubArea(string nextLevel) 
    {
        CharacterSheet.charSheet.SetLastLevel(_scene.name);
        lastLocation = _scene.name;

        if (!_scene.name.Equals("OpeningStory"))
        {
            PlayerPrefsManager.SavePlayerState(CharacterSheet.charSheet.baseStats.GetStats("xp"),
                CharacterSheet.charSheet.baseStats.GetStats("currentHP"), CharacterSheet.charSheet.baseStats.GetStats("hp"),
               CharacterSheet.charSheet.baseStats.GetStats("currentMP"), CharacterSheet.charSheet.baseStats.GetStats("mp"),
                CharacterSheet.charSheet.baseStats.GetStats("attack"), CharacterSheet.charSheet.baseStats.GetStats("defense"),
                CharacterSheet.charSheet.baseStats.GetStats("magic"), CharacterSheet.charSheet.baseStats.GetStats("special"));
        }

        if (System.Enum.IsDefined(typeof(OVERWORLD), _scene.name))
        {
            PlayerPrefsManager.SetPlayerOverworldPosition(data.player.transform.position.x, data.player.transform.position.y,
               data.player.transform.position.z);
        }
        StartCoroutine(LoadNextLevel(nextLevel));
    }

    public string GetCurrentLocation()
    {
        return locationName;
    }

    void SetCurrentLocation(string location)
    {
        if (locationName.Equals(" ") || !locationName.Equals(location))
        {
            lastLocation = locationName;
            locationName = location;
        } else if (locationName.Equals(location))
        {
            locationName = lastLocation;
            lastLocation = location;
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        setupDefaults();
    }

    IEnumerator LoadNextLevel(string nextLevel)
    {
        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(nextLevel);
    }
}
