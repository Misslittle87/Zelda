using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    // En hjärta som ger mer health
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            if (player.health < player.maxHealth)
            {
                player.ChangeHealth(20);
                Destroy(gameObject);
            }
        }
    }
}
