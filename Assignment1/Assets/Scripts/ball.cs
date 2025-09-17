using UnityEngine;

public class ball : MonoBehaviour
{
    // Reference to Rigidbody2D for handling ball physics
    Rigidbody2D rb;

    // Speed multiplier for ball movement
    public float speed;

    // Current movement direction of the ball
    public Vector2 direction;

    // Reference to scoreScript to keep track of scores
    public scoreScript score;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody2D component attached to this ball
        rb = GetComponent<Rigidbody2D>();

        // Set initial movement direction to (1,1), normalized
        direction = Vector2.one.normalized;

        // Find the score manager object (tagged "logic") and get its scoreScript
        score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreScript>();
    }

    // Update is called once per frame
    void Update()
    {
        // Continuously apply velocity to the ball based on direction and speed
        rb.linearVelocity = direction * speed;
    }

    // Resets ball position and gives it a new random horizontal direction
    void ResetBall()
    {
        // Reset ball to center of the screen
        transform.position = Vector2.zero;

        // Randomize horizontal direction (left or right), always going upward initially
        direction = new Vector2(Random.value > 0.5f ? 1 : -1, 1).normalized;
    }

    // Detects collisions with other objects using triggers
    void OnTriggerEnter2D(Collider2D collison)
    {
        // Bounce off Player 1 paddle
        if (collison.gameObject.CompareTag("P1"))
        {
            direction.x = -direction.x; // Invert x direction
        }
        // Bounce off Player 2 paddle
        else if (collison.gameObject.CompareTag("P2"))
        {
            direction.x = -direction.x; // Invert x direction
        }
        // If ball hits left wall → Player 2 scores
        else if (collison.gameObject.CompareTag("leftSideWall"))
        {
            score.AddScore(2);
            ResetBall();
        }
        // If ball hits right wall → Player 1 scores
        else if (collison.gameObject.CompareTag("rightSideWall"))
        {
            score.AddScore(1);
            ResetBall();
        }
        // Bounce off ceiling
        else if (collison.gameObject.CompareTag("ceiling"))
        {
            direction.y = -direction.y; // Invert y direction
        }
        // Bounce off bottom wall
        else if (collison.gameObject.CompareTag("bottomWall"))
        {
            direction.y = -direction.y; // Invert y direction
        }
    }
}
