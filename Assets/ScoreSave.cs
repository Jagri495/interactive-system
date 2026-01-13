using UnityEngine;
using System.Collections.Generic;

public static class ScoreSave
{
    private const int MaxRank = 5;

    // スコアを保存
    public static void SaveScore(int score)
    {
        List<int> scores = LoadScores();

        scores.Add(score);
        scores.Sort((a, b) => b.CompareTo(a)); // 降順（高い順）

        if (scores.Count > MaxRank)
            scores.RemoveAt(scores.Count - 1);

        for (int i = 0; i < scores.Count; i++)
        {
            PlayerPrefs.SetInt("Score_" + i, scores[i]);
        }
        PlayerPrefs.Save();
    }

    // スコアを読み込む
    public static List<int> LoadScores()
    {
        List<int> scores = new List<int>();

        for (int i = 0; i < MaxRank; i++)
        {
            if (PlayerPrefs.HasKey("Score_" + i))
            {
                scores.Add(PlayerPrefs.GetInt("Score_" + i));
            }
        }
        return scores;
    }
}
