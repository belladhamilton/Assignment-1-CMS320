using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float displacement = 0.1f;
    public string player; // "P1" or "P2"

    private Rigidbody2D pad;

    void Start()
    {
        pad = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 pos = pad.position; // current paddle position

        if (player == "P1") // Player 1 controls (W/S)
        {
            if (Input.GetKey(KeyCode.W))
                pos.y = Mathf.Min(pos.y + displacement, 4.5f); // adjust boundary
            else if (Input.GetKey(KeyCode.S))
                pos.y = Mathf.Max(pos.y - displacement, -4.5f);
        }
        else if (player == "P2") // Player 2 controls (Arrow keys)
        {
            if (Input.GetKey(KeyCode.UpArrow))
                pos.y = Mathf.Min(pos.y + displacement, 4.5f);
            else if (Input.GetKey(KeyCode.DownArrow))
                pos.y = Mathf.Max(pos.y - displacement, -4.5f);
        }

        pad.MovePosition(pos);
    }
}
