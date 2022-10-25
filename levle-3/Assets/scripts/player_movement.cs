using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5.0f;
    public float dir_speed = 15.0f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = Vector3.forward * speed;

        if(Input.GetKey(KeyCode.A))
        {
            rb.velocity = Vector3.left * dir_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = Vector3.right * dir_speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}

