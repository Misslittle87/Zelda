using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Jag �r absolut inte f�rdig med detta spelet och kommer forts�tta utveckla det.
    // Det �r f�rsta g�ngen jag g�r n�got i Unity och har verkligen haft skitroligt.
    // L�rt mig otroligt mycket, och kommer forts�tta med Unity och spelutveckling.
    // Det �r lite d�rf�r jag inte har hunnit klart med alla delar, f�r det tar otroligt
    // l�ng tid, l�ngre �n man tror. Men sjukt roligt.
    // F�r�ttring; pilen skjuts p� r�tt h�ll, g�ra quest, samla coins och diamanter, g�ra en inventory och allm�nt snygga till
    public Rigidbody2D playerBody;
    public float speed;
    public Vector2 direction;
    public Animator animator;
    public VectorValue startingPosition;
    public GameObject arrowPrefab;
    Vector2 lookDirection = new Vector2(-1, 0);
    // Player health
    public int maxHealth = 100;
    public int currentHealth;
    public int health { get { return currentHealth; }}
    public healthbar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>(); // H�mtar Playerns kropp s� vi kan g�ra n�got med den
        animator = GetComponent<Animator>(); // H�mtar playerns animation s� vi kan g�ra n�got med den
        currentHealth = maxHealth; // Vid start s� s�tts playerns HP till maxHP
        healthbar.SetMaxHealth(maxHealth);
        transform.position = startingPosition.initialValue;
    }


    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }
    public void Movement()
    {
        if (direction.x > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (direction.x < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1); // x, y, z
        }
        animator.SetFloat("Horizontal", direction.x); // H�mntar info till animatorn p� X-axeln
        animator.SetFloat("Vertical", direction.y); // H�mtar info till animatorn p� Y-axeln
        animator.SetFloat("Speed", direction.sqrMagnitude);
        Vector2 move = new Vector2(direction.x, direction.y);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) // Kollar vilket h�ll Player tittar �t s� att n�r
                                                                                      // playern blir Idle s� tittar den �t det h�ller den stannade
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Horizontal", lookDirection.x);
        animator.SetFloat("Vertical", lookDirection.y);
        animator.SetFloat("Speed", move.sqrMagnitude);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); // Clamping �r att spelaren inte kan ta skada n�r man �r p� noll och f� mer h�lsa n�r man har maxHP
    }

    private void FixedUpdate()
    {
        Vector2 position = playerBody.position;
        position.x = position.x + speed * direction.x * Time.deltaTime;
        position.y = position.y + speed * direction.y * Time.deltaTime;
        playerBody.MovePosition(position);
        //playerBody.MovePosition(playerBody.position + direction * speed * Time.fixedDeltaTime);
    }
    /// <summary>
    /// This change the health of the player when player takes damage
    /// </summary>
    /// <param name="damage">Player takes damage by walking in to the mole or press space</param>
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthbar.SetHealth(currentHealth);
    }
}
