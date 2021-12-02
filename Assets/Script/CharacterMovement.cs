using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f; //kecepatan gerakan
    public bool cubeIsOnTheGround = true;
    public ParticleSystem p;
    public GameObject LoseCanvas;

    private bool GameAktif = true;
    private float xInput;
    private float zInput;
    private float threshold = -60f;
    // Update is called once per frame
   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        ProcessInputs();
        Jump();
        if (transform.position.y < threshold)
        {
            LoseCanvas.SetActive(true);
            Debug.Log("Game Kalah");
            GameAktif = false;
            
        }
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

        else if (collision.gameObject.tag == "Trampoline")
        {
            rb.AddForce(new Vector3(0, 4, 0), ForceMode.Impulse);
            Instantiate(p, new Vector3(0.3f,-12.3f,-3.15f),Quaternion.identity);
        }
    }
}
