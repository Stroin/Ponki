using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed = 5f;
    [SerializeField] private KeyCode upKey = KeyCode.W;
    [SerializeField] private KeyCode downKey = KeyCode.S;

    void Start()
    {

    }

    void Update()
    {


        if (Input.GetKey(upKey) && transform.position.y < 4)
        {

            transform.position += Vector3.up * Time.deltaTime * PlayerSpeed;

        }

        if (Input.GetKey(downKey) && transform.position.y > -4)
        {
            transform.position += Vector3.down * Time.deltaTime * PlayerSpeed;
        }

        
    }
    
}