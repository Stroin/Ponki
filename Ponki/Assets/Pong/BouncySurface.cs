using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
    public float bounceStrength;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        BallController ballController = collision.gameObject.GetComponent<BallController>();

        if (ballController != null )
        {
            Vector2 normal = collision.GetContact(0).normal;
            ballController.AddForce(-normal * this.bounceStrength);
        }
    }
}
