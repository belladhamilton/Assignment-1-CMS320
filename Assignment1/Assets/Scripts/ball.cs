using UnityEngine;
using TMPro; // Use this if you’re using TextMeshPro
public class ball : MonoBehaviour
{

// Start is called before the first frame update
Rigidbody2D rb;
public float speed;
public Vector2 direction;
public scoreScript score;

void Start()
{
    rb= GetComponent<Rigidbody2D>();
    direction= Vector2.one.normalized; //(1,1)
    score = GameObject.FindGameObjectWithTag("logic").GetComponent<scoreScript>();
}

// Update is called once per frame
void Update()
{
    rb.linearVelocity= direction*speed;
}

void ResetBall()
    {
        transform.position = Vector2.zero;
        direction = new Vector2(Random.value > 0.5f ? 1 : -1, 1).normalized;
    }

void OnTriggerEnter2D(Collider2D collison){
    if (collison.gameObject.CompareTag("P1")){
        direction.x = -direction.x;
    }
    else if (collison.gameObject.CompareTag("P2")){
        direction.x = -direction.x;
    }
    else if (collison.gameObject.CompareTag("leftSideWall")){
        score.AddScore(2); // Player 2 scores
            ResetBall();
    }   
    else if (collison.gameObject.CompareTag("rightSideWall")){
        score.AddScore(1); // Player 1 scores
            ResetBall();
    } 
    else if (collison.gameObject.CompareTag("ceiling")){
        direction.y = -direction.y;
    }

    else if (collison.gameObject.CompareTag("bottomWall")){
        direction.y = -direction.y;
    }
  
}
}
