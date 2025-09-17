using UnityEngine;
using TMPro;

public class scoreScript : MonoBehaviour
{
    // UI text objects to display player scores and win message
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI winText;

    // Internal counters for each player's score
    private int player1Score = 0;
    private int player2Score = 0;

    // Adds a point to the given player's score
    public void AddScore(int player)
    {
        if (player == 1) // Player 1 scores
        {
            player1Score++;
            // Update Player 1’s score text
            player1ScoreText.text = "Player 1: " + player1Score;

            // Check if Player 1 has reached winning condition
            if (player1Score >= 5) EndGame("Player 1 Wins!");
        }
        else if (player == 2) // Player 2 scores
        {
            player2Score++;
            // Update Player 2’s score text
            player2ScoreText.text = "Player 2: " + player2Score;

            // Check if Player 2 has reached winning condition
            if (player2Score >= 5) EndGame("Player 2 Wins!");
        }
    }

    // Ends the game by showing win message and stopping time
    void EndGame(string message)
    {
        // Display the winning message
        winText.text = message;

        // Freeze the game so no more updates happen
        Time.timeScale = 0f;
    }
}
