using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 2;
    public Vector3 spawnPoint;

    private Rigidbody rb;

    private void Start()
    {
        spawnPoint = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3();
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");

        //transform.position += moveDirection * speed * Time.deltaTime;
        rb.velocity = moveDirection * speed;
        if (moveDirection != Vector3.zero) transform.forward = moveDirection;

        /*
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, speed) * Time.deltaTime;
        }        
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }        
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -speed) * Time.deltaTime;
        }        
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        */
    }
   
    public void Die()
    {
        var sceneNow = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneNow);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name.Contains("Enemy"))
        {
            Die();
        }
    }
}
