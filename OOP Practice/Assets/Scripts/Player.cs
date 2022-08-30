using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;

    private float horizontal;
    private float vertical;

    private float mouseX;
    private float mouseY;
    private float look;

    private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        cam = transform.GetChild(0);

        Cursor.lockState = CursorLockMode.Locked;

        Cursor.visible = false;
    }

    void Update()
    {
        GetMove();

        GetTurn();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + new Vector3(horizontal, 0, vertical) * Time.fixedDeltaTime * 10);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, mouseX * Time.fixedDeltaTime * 50, 0));
    }

    void GetMove()
    {
        horizontal = Input.GetAxis("Horizontal");

        vertical = Input.GetAxis("Vertical");

    }

    void GetTurn()
    {
        mouseX = Input.GetAxis("Mouse X");

        mouseY = Input.GetAxis("Mouse Y");

        look -= mouseY;
        look = Mathf.Clamp(look, -85, 85);

        cam.localRotation = Quaternion.Euler(look, 0, 0);
    }
}
