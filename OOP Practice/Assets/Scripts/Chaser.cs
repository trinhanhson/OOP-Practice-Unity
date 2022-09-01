using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Shootable
{
    public override void Move()
    {
        base.Move();

        rb.AddForce((GameManager.Instance.player.gameObject.transform.position - rb.position).normalized * 10);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce((rb.position - collision.gameObject.transform.position).normalized * 10, ForceMode.VelocityChange);
        }
    }
}
