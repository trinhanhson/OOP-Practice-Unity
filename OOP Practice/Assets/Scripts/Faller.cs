using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faller : Shootable
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddForce(((GameManager.Instance.player.transform.position - rb.position).normalized + Vector3.up) * 10, ForceMode.VelocityChange);
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce((rb.position - collision.gameObject.transform.position).normalized * 10, ForceMode.VelocityChange);
        }
    }
}
