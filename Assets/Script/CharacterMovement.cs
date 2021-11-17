using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f; //kecepatan gerakan
    public bool cubeIsOnTheGround = true;

    private float xInput;
    private float zInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessInputs();
        Jump();
    }

    private void FixedUpdate()
    {
        //Pergerakan
        Move();
    }

    private void ProcessInputs()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move() //gerak
    {
        rb.AddForce(new Vector3(xInput, 0f, zInput) * moveSpeed);
    }

    private void Jump() //lompat
    {
        if (Input.GetButtonDown("Jump") && cubeIsOnTheGround == true) //membuat object melompat sekali
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            cubeIsOnTheGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) //untuk mengecek apakah object ada di lantai atau bukan
    {
        if(collision.gameObject.tag == "Ground")
        {
            cubeIsOnTheGround = true;
        }
    }
}
