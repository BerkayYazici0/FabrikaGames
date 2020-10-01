using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
     private CharacterController controller;
       private Vector3 direction;
       public float speed=10;
    void Start()
    {
       controller = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        direction.x = hInput*speed;
        controller.Move(direction * Time.deltaTime);
        
        
    }
   
}
