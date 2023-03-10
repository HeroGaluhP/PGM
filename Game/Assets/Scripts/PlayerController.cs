using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//import Library Scene Management agar dapat menggunakan fungsi didalamnya

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce; //Membuat Teks box sebagai parameter
    bool canJump; //canJump merupakan variable untuk function yang berfungsi agar player hanya dapat melompat satu kali

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            //Jump
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    } 



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    //Function yang berfungsi untuk melakukan reset jika player mengenai obstacle
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
