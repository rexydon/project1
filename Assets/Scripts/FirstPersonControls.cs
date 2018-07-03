using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonControls : MonoBehaviour
{
    public float speed = 4.0f;
    public float rotationSpeed = 180f;
    private float rotX;
    public float minRot = -20;
    public float maxRot = 60;
    public float jump = 5.0f;
    public GameObject playerCamera;
    public GameObject bullet;
    public GameObject turret1;
    public GameObject turret2;
    private Rigidbody rb;
    private bool canJump = true;

    // Use this for initialization
    void Start()
    {
        rotX = playerCamera.transform.eulerAngles.x;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection += -transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canJump == true)
            {
                rb.AddForce(0, jump, 0, ForceMode.Impulse);
                canJump = false;
            }
        }

        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet, turret1.transform.position, playerCamera.transform.rotation);
            Instantiate(bullet, turret2.transform.position, playerCamera.transform.rotation);
        }

        if (mouseX != 0)
        {
            transform.Rotate(transform.up, rotationSpeed * mouseX * Time.deltaTime, Space.World);
        }


        if (mouseY != 0)
        {
            rotX += -mouseY * (rotationSpeed * .5f) * Time.deltaTime;
            rotX = Mathf.Clamp(rotX, minRot, maxRot);
            Vector3 localRotation = new Vector3(rotX, 0.0f, 0.0f);
            playerCamera.transform.localEulerAngles = localRotation;

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            canJump = true;
        }
    }
}
