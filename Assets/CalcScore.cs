using UnityEngine;
using TMPro;

public class CalcScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScore();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
}
