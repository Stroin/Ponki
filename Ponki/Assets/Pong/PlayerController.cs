using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }    
}