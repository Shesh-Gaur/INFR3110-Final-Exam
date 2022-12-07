using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;

    Vector2 mvmt;
    Rigidbody rb;
    public float speed = 2.0f;
    // Start is called before the first frame update
    public int score = 0;
    private void Awake()
    {

    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
            rb.velocity = new Vector3(0, 0, speed * Time.deltaTime);
        else if(Input.GetKey(KeyCode.A))
            rb.velocity = new Vector3(-speed * Time.deltaTime, 0, 0);
        else if(Input.GetKey(KeyCode.S))
            rb.velocity = new Vector3(0, 0, -speed * Time.deltaTime);
        else if (Input.GetKey(KeyCode.D))
            rb.velocity = new Vector3(speed * Time.deltaTime, 0, 0);
        else
            rb.velocity = Vector3.zero;
        
        if (score >= 4)
        {
            winScreen.SetActive(true);
        }
    }

    void GameOver()
    {
        loseScreen.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ghost"))
        {
            GameOver();
        }
    }
}
