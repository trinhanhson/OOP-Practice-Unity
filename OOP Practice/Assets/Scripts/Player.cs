using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Text healthText;

    public int health;

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

        healthText.text = "Health: " + health;
    }

    void Update()
    {
        GetMove();

        GetTurn();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (transform.right * horizontal + transform.forward * vertical) * Time.fixedDeltaTime * 10);

        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, mouseX * Time.fixedDeltaTime * 50, 0));
    }

    void GetMove()
    {
        horizontal = Input.GetAxis("Horizontal");

        vertical = Input.GetAxis("Vertical");

        if (transform.position.y <= -10)
        {
            GameManager.Instance.Lose();
        }

    }

    void GetTurn()
    {
        mouseX = Input.GetAxis("Mouse X");

        mouseY = Input.GetAxis("Mouse Y");

        look -= mouseY;
        look = Mathf.Clamp(look, -85, 85);

        cam.localRotation = Quaternion.Euler(look, 0, 0);
    }

    void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.position, cam.TransformDirection(Vector3.forward), out hit, 1000, 1 << 3))
        {
            hit.collider.GetComponent<Shootable>().Damage();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Shootable"))
        {
            UpdateHealth(-1);
        }
    }

    public void UpdateHealth(int value)
    {
        health += value;

        healthText.text = "Health: " + health;

        if (health <= 0)
        {
            GameManager.Instance.Lose();
        }
    }
}
