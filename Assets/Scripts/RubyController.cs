using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RubyController : MonoBehaviour
{
    // ========= MOVEMENT =================
    public float speed = 4;
    
    // ======== HEALTH ==========
    public float timeInvincible = 2.0f;
    public Transform respawnPosition;
    public ParticleSystem hitParticle;
    public int currentHealth;
    
    // ======== PROJECTILE ==========
    public GameObject projectilePrefab;

    // ======== AUDIO ==========
    public AudioClip hitSound;
    public AudioClip shootingSound;

    // =========== MOVEMENT ==============
    Rigidbody2D rigidbody2d;
    Vector2 currentInput;

    Scene _scene;
    
    // ======== HEALTH ==========
    float invincibleTimer;
    bool isInvincible;
   
    // ==== ANIMATION =====
    Animator animator;
    Vector2 lookDirection = new Vector2(1, 0);
    
    // ================= SOUNDS =======================
    AudioSource audioSource;
    
    void Start()
    {
        // =========== MOVEMENT ==============
        rigidbody2d = GetComponent<Rigidbody2D>();
        _scene = SceneManager.GetActiveScene();
                
        // ======== HEALTH ==========
        invincibleTimer = -1.0f;
        if (PlayerPrefs.HasKey("health")) {
            currentHealth = PlayerPrefsManager.GetHealth();
        } else {
            currentHealth = Player.player.baseStats.GetStats("hpmax");
        }
        
        // ==== ANIMATION =====
        animator = GetComponent<Animator>();
        
        // ==== AUDIO =====
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        // ================= HEALTH ====================
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }

        // ============== MOVEMENT ======================
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    
        if (_scene.name.Equals("EnemyA")) 
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

        // ============== PROJECTILE ======================

        if (Input.GetKeyDown(KeyCode.C))
            LaunchProjectile();
        
        // ======== DIALOGUE ==========
        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rigidbody2d.position + Vector2.up * 0.2f, lookDirection, 1.5f, 1 << LayerMask.NameToLayer("NPC"));
            if (hit.collider != null)
            {
                TreasureChest chest = hit.collider.GetComponent<TreasureChest>();
                NonPlayerCharacter character = hit.collider.GetComponent<NonPlayerCharacter>();
                if (character != null)
                {
                    character.DisplayDialog();
                } 
                else if (chest != null && chest.GetComponent<Chest>().status == Chest.ChestState.CLOSED) 
                {
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
                if (chest.status == Chest.ChestState.OPENED)
                {
                    tchest.dialogBox.SetActive (false);
                    tchest.GetTreasure();
                    chest.status = Chest.ChestState.USED;
                    ChestManager.chestManager.UpdateChest(chest.chestID, chest.status);
                }
            }
        }

        ChangeHealth(0);
 
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        
        position = position + currentInput * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);
    }

    // ===================== HEALTH ==================
    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        { 
            if (isInvincible)
                return;
            
            isInvincible = true;
            invincibleTimer = timeInvincible;
            
            animator.SetTrigger("Hit");
            audioSource.PlayOneShot(hitSound);

            Instantiate(hitParticle, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
        
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, Player.player.baseStats.GetStats("hpmax"));
        
        if(currentHealth == 0 ) 
        {
            GameManager.gm.refreshGui();
            Respawn();
        }
        
        Player.player.ReloadStats();
        UIHealthBar.Instance.SetValue(currentHealth / (float)Player.player.baseStats.GetStats("hpmax"));
    }
    
    void Respawn()
    {
        ChangeHealth(Player.player.baseStats.GetStats("hpmax"));
        transform.position = respawnPosition.position;
    }
    
    // =============== PROJECTICLE ========================
    void LaunchProjectile()
    {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + Vector2.up * 0.5f, Quaternion.identity);

        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        
        animator.SetTrigger("Launch");
        audioSource.PlayOneShot(shootingSound);
    }
    
    // =============== SOUND ==========================

    //Allow to play a sound on the player sound source. used by Collectible
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
