using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5.0f;
    public float dir_speed = 15.0f;

    private int coins;
    public TextMeshProUGUI scoreText;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        coins = 0;
        scoreText.text = "" + coins;
    }

    // Update is called once per frame
    void Update()
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
        if (collision.gameObject.tag == "enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );
        }

        if (collision.gameObject.tag == "finishLine")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (collision.gameObject.tag == "coin")
        {
            Destroy(collision.gameObject);
            coins += 1;
            scoreText.text = "" + coins;

        }
    }
}