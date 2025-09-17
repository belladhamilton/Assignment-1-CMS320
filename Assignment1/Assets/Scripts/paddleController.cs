using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // How much the paddle moves per frame update
    public float displacement = 0.1f;

    // Which player this paddle belongs to ("P1" or "P2")
    public string player;

    // Reference to the paddle's Rigidbody2D component
    private Rigidbody2D pad;

    // Start is called before the first frame update
    void Start()
    {
        // Get Rigidbody2D attached to this paddle object
        pad = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get the current paddle position
        Vector2 pos = pad.position;

        // Controls for Player 1 (W and S keys)
        if (player == "P1")
        {
            if (Input.GetKey(KeyCode.W))
                // Move paddle up, clamp at y = 4.5f
                pos.y = Mathf.Min(pos.y + displacement, 4.5f);
            else if (Input.GetKey(KeyCode.S))
                // Move paddle down, clamp at y = -4.5f
                pos.y = Mathf.Max(pos.y - displacement, -4.5f);
        }
        // Controls for Player 2 (Arrow keys)
        else if (player == "P2")
        {
            if (Input.GetKey(KeyCode.UpArrow))
                // Move paddle up, clamp at y = 4.5f
                pos.y = Mathf.Min(pos.y + displacement, 4.5f);
            else if (Input.GetKey(KeyCode.DownArrow))
                // Move paddle down, clamp at y = -4.5f
                pos.y = Mathf.Max(pos.y - displacement, -4.5f);
        }

        // Apply the new position to the paddle
        pad.MovePosition(pos);
    }
}
