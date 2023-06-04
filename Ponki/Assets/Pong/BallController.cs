using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float BallSpeed = 5f;

    public Rigidbody2D rb2D;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = GenerateRandomVelocity(true) * BallSpeed;
    }

    private Vector3 GenerateRandomVelocity(bool shouldReturnNormalize)
    {
        Vector3 velocity = new Vector3();
        velocity.x = Random.Range(-1f, 1f);
        velocity.y = Random.Range(-1f, 1f);

        if (shouldReturnNormalize)
        {
            return velocity.normalized;
        }

        return velocity;
    }
    

    

    void Update()
    {
    
    }
}
