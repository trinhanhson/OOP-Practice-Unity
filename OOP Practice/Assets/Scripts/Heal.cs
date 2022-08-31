using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Shootable
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.AddRelativeForce(Vector3.one * 5, ForceMode.VelocityChange);

            rb.AddTorque(Vector3.one * 5, ForceMode.VelocityChange);
        }
    }
}
