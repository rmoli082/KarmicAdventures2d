using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // ========= MOVEMENT =================
    public float speed = 4;
    
    // ======== HEALTH ==========
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;
    public int currentHealth;
    
    // ======== ATTACKS ==========
    public GameObject projectilePrefab;

    // ======== AUDIO ==========
    public AudioClip hitSound;
    public AudioClip shootingSound;

    // =========== MOVEMENT ==============
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;

    Scene _scene;
    
    
   
    // ==== ANIMATION =====
    Animator animator;
    public Vector2 lookDirection = new Vector2(1, 0);
    
    // ================= SOUNDS =======================
    AudioSource audioSource;
    
    void Start()
    {
        // =========== MOVEMENT ==============
        rigidbody2d = GetComponent<Rigidbody2D>();
        _scene = SceneManager.GetActiveScene();
                
        
        // ==== ANIMATION =====
        animator = GetComponent<Animator>();
        
        // ==== AUDIO =====
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        

        // ============== MOVEMENT ======================
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    
        if (System.Enum.IsDefined(typeof(OverlandEnemyTrap.Levels), _scene.name) ||  _scene.name.Equals("DemonRealm")) 
        {
            vertical = 0f; 
        }
                
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
    
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        currentInput = move;


        // ============== ANIMATION =======================

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        // ============== ATTACKS ======================

        if (Input.GetKeyDown(KeyCode.C))
            LaunchProjectile();

        if (Input.GetKeyDown(KeyCode.Z))
            SwordAttack();
        
        // ======== EXAMINE ==========
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                TreasureChest chest = hit.collider.GetComponent<TreasureChest>();
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    if (!character.dialogBox.activeSelf)
                        character.DisplayDialog();
                    else
                        character.CloseDialog();
                } 
                else if (chest != null && chest.GetComponent<Chest>().status == Chest.ChestState.CLOSED) 
                {
                    Time.timeScale = 0f;
                    chest.DisplayDialog();
                    chest.GetComponent<Chest>().status = Chest.ChestState.OPENED;
                    ChestManager.chestManager.UpdateChest(chest.GetComponent<Chest>().chestID, chest.GetComponent<Chest>().status);
                }

            }
        }

           
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                TreasureChest tchest = hit.collider.GetComponent<TreasureChest>();
                Chest chest = hit.collider.GetComponent<Chest>();
                if (chest != null)
                {
                    if (chest.status == Chest.ChestState.OPENED)
                    {
                        Time.timeScale = 1f;
                        tchest.dialogBox.SetActive(false);
                        tchest.GetTreasure();
                        chest.status = Chest.ChestState.USED;
                        ChestManager.chestManager.UpdateChest(chest.chestID, chest.status);
                    }
                }
            }
        }

 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        
        position = position + currentInput * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }


    bool CheckMana(Projectile p)
    {
        if (p.manaCost < CharacterSheet.charSheet.baseStats.GetStats("currentMP"))
        {
            return true;
        }
        else return false;
    }
    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 1.1f, Quaternion.identity);
        projectileObject.SetActive(false);
        Projectile projectile = projectileObject.GetComponent<Projectile>();

        if (CheckMana(projectile))
        {
            projectileObject.SetActive(true);
            projectile.Launch(lookDirection, 300);

            animator.SetTrigger("Launch");
            audioSource.PlayOneShot(shootingSound);
        }
        else
        {
            Destroy(projectileObject);
        }
        
    }
   
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    void SwordAttack()
    {
        animator.SetTrigger("Sword");
        audioSource.PlayOneShot(shootingSound);
    }
}
