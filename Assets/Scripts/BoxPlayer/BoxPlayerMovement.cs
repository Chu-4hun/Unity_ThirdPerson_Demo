using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// ReSharper disable once CheckNamespace
public class BoxPlayerMovement : MonoBehaviour
{
    public float jumpForce = 1000f;
    public Rigidbody rb;
    public float speed = 1000f;
    public int jumpAmount = 2;
    private bool is_ground = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        rb.AddForce(direction * (speed * Time.deltaTime));
        
        if (Input.GetButtonDown("Jump") && is_ground)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        
    }

    void OnTriggerStay(Collider col){
        if (col.CompareTag("floor")) is_ground = true;      
    }
    void OnTriggerExit(Collider col){
        if (col.CompareTag("floor")) is_ground = false;    
    }
    
}
