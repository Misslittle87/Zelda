using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    // En klass som har en firepoint där arrown kommer ut
    // och hur arrown ser ut
    // vilken kraft den skjuts
    public Transform Firepoint;
    public GameObject arrowPrefab;
    public float arrowForce = 10f;
    // Update is called once per frame
    void Update()
    {
        // Skjuts med hjälp av Vänster musknapp
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        GameObject arrow = Instantiate(arrowPrefab, Firepoint.position, Firepoint.rotation); // man "kopierar" fler arrows, från firepointen
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>(); // arrows rigidbody
        rb.AddForce(Firepoint.position * arrowForce, ForceMode2D.Impulse); // lägger till kraften
    }
}
