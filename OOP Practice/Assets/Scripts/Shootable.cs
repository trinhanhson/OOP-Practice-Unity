using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour
{
    [SerializeField] protected int health;

    protected Rigidbody rb;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        if (transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }

    public virtual void Damage()
    {
        health -= 1;
        if (health == 0)
        {
            GameManager.Instance.score += 1;

            Destroy(gameObject);
        }
    }
}
