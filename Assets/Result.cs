using UnityEngine;using TMPro;
public class Point : MonoBehaviour{  
    public TMP_Text scoreText;
    public TMP_Text rankText;
    public TMP_Text messageText;
    void Start()
    {
        int score = Player_HeadHealth.currentHealth;
        // 念のため、表示上の制限をかける（元のコードのロジックを維持）
        int displayScore = Mathf.Clamp(score, 0, 100);
        // ★ スコア保存
    ScoreSave.SaveScore(displayScore);
        scoreText.text = "Score : " + displayScore;
        if (displayScore >= 90)
        {
            rankText.text = "S";
            rankText.color = Color.yellow;
            messageText.text = "Excellent";
        }
        else if (displayScore >= 75)
        {
            rankText.text = "A";
            rankText.color = Color.red;
            messageText.text = "Great";
        }
        else if (displayScore >= 60)
        {
            rankText.text = "B";
            rankText.color = Color.green;
            messageText.text = "Good";
        }
        else if (displayScore >= 40)
        {
            rankText.text = "C";
            rankText.color = Color.cyan;
            messageText.text = "Keep Trying";
        }
        else
        {
            rankText.text = "D";
            rankText.color = Color.gray;
            messageText.text = "Practice makes perfect!";
	}
    }
}