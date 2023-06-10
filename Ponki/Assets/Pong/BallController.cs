using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField] private float BallSpeed = 5f;
    [SerializeField] private AudioSource hitSoundEffect;
    [SerializeField] private AudioSource golSoundEffect;

    public Rigidbody2D rb2D;
    public Vector3 vel;
    public bool isPlaying;
    public ScoreManager scoreManager;


    private void ResetAndSendBallInRandomDirection()
    {
        ResetBall();
        rb2D.velocity = GenerateRandomVelocity(true) * BallSpeed;
        vel = rb2D.velocity;
        isPlaying = true;
    }

    public void ResetBall()
    {
        rb2D.velocity = Vector3.zero;
        transform.position = Vector3.zero;
        isPlaying = false;

    }
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        ResetBall();
        
    }

    private Vector3 GenerateRandomVelocity(bool shouldReturnNormalize)
    {
        Vector3 velocity = new Vector3();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        velocity.x = shouldGoRight ? Random.Range(.8f, .3f) : Random.Range(-.8f, -.3f);
        velocity.y = shouldGoRight ? Random.Range(.8f, .3f) : Random.Range(-.8f, -.3f);

        if (shouldReturnNormalize)
        {
            return velocity.normalized;
        }

        return velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb2D.velocity = Vector3.Reflect(vel, collision.contacts[0].normal);
        Vector3 newVelocityWithOffset = rb2D.velocity;
        newVelocityWithOffset += new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f));
        rb2D.velocity = newVelocityWithOffset.normalized * BallSpeed;
        vel = rb2D.velocity;
        hitSoundEffect.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
            print("left Player +1");

        if (transform.position.x < 0)
            print("right Player +1");

        ResetAndSendBallInRandomDirection();

        if(collision.gameObject.name == "BorderRight")
        {
            
            scoreManager.PlayerLeftScore();
            golSoundEffect.Play();
        }
        if(collision.gameObject.name == "BorderLeft")
        {
            scoreManager.PlayerRightScore();
            golSoundEffect.Play();
        }
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && isPlaying == false)
        {
            ResetAndSendBallInRandomDirection();
        }

        if (rb2D.velocity.magnitude < BallSpeed * 0.5f)
            ResetBall();
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetAndSendBallInRandomDirection();
        }
    }
    public void AddForce(Vector2 force)
        {
            rb2D.AddForce(force);
        }
            
    
}
