using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static int score;      // 他スクリプトから参照可能
    public TMP_Text scoreText;    // ゲーム中のスコア表示

    void Start()
    {
        score = 0;
        UpdateScoreText();
    }

    // スコア加算用（他スクリプトから呼ぶ）
    public static void AddScore(int value)
    {
        score += value;
    }

    void Update()
    {
        // 表示更新（毎フレームでもOK）
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString("000000");
    }
}
