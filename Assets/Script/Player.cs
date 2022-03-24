using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Jag är absolut inte färdig med detta spelet och kommer fortsätta utveckla det.
    // Det är första gången jag gör något i Unity och har verkligen haft skitroligt.
    // Lärt mig otroligt mycket, och kommer fortsätta med Unity och spelutveckling.
    // Det är lite därför jag inte har hunnit klart med alla delar, för det tar otroligt
    // lång tid, längre än man tror. Men sjukt roligt.
    // Förättring; pilen skjuts på rätt håll, göra quest, samla coins och diamanter, göra en inventory och allmänt snygga till
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
        playerBody = GetComponent<Rigidbody2D>(); // Hämtar Playerns kropp så vi kan göra något med den
        animator = GetComponent<Animator>(); // Hämtar playerns animation så vi kan göra något med den
        currentHealth = maxHealth; // Vid start så sätts playerns HP till maxHP
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
        animator.SetFloat("Horizontal", direction.x); // Hämntar info till animatorn på X-axeln
        animator.SetFloat("Vertical", direction.y); // Hämtar info till animatorn på Y-axeln
        animator.SetFloat("Speed", direction.sqrMagnitude);
        Vector2 move = new Vector2(direction.x, direction.y);
        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f)) // Kollar vilket håll Player tittar åt så att när
                                                                                      // playern blir Idle så tittar den åt det håller den stannade
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
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); // Clamping är att spelaren inte kan ta skada när man är på noll och få mer hälsa när man har maxHP
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
