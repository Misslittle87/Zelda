using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Jag har inte hunnit ge en AI till mullvaden
    // Men den ger skada till playern vid Collision
    // Men jag kommer att forsätta utvekla detta spelet
    Rigidbody2D enemyBody;
    public Animator animator;
    public int health;
    public string enemyName;
    public int baseAttack;
    public float moveSpeed;


    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            Debug.Log("Player takes damage");
            player.ChangeHealth(-1);
        }
    }

}
