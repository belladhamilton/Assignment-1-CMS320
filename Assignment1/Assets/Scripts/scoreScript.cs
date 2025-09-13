using UnityEngine;
using TMPro;

public class scoreScript : MonoBehaviour
{
    public TextMeshProUGUI player1ScoreText;
    public TextMeshProUGUI player2ScoreText;
    public TextMeshProUGUI winText;

    private int player1Score = 0;
    private int player2Score = 0;

    public void AddScore(int player)
    {
        if (player == 1)
        {
            player1Score++;
            player1ScoreText.text = "Player 1: " + player1Score;
            if (player1Score >= 5) EndGame("Player 1 Wins!");
        }
        else if (player == 2)
        {
            player2Score++;
            player2ScoreText.text = "Player 2: " + player2Score;
            if (player2Score >= 5) EndGame("Player 2 Wins!");
        }
    }

    void EndGame(string message)
    {
        winText.text = message;
        Time.timeScale = 0f; // stop the game
    }
}
