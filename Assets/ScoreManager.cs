using UnityEngine;
using TMPro;

public class ScoreManager_test : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;
    private float timer = 0f;

    void Start_0score()
    {
        scoreText.text = score.ToString("000");
    }

    void Update_score()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            score += 1;
            scoreText.text = score.ToString("000000");
            timer = 0f;
        }
    }
}
