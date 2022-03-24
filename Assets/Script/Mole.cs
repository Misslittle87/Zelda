using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy
{
    // Här har jag lagt till så att mullvaden har en radie
    // så ifall playern kommer inom radien så får han aggro
    public Transform target;
    public float chaseRadius;
    public float attackRadius;
    public Transform homePosition;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        CheckDistance();
    }
    void CheckDistance()
    {
        if(Vector3.Distance(target.position, transform.position) <= chaseRadius && Vector3.Distance(target.position, transform.position) > attackRadius)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}
