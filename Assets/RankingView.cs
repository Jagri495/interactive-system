using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class RankingView : MonoBehaviour
{
    public TMP_Text[] rankTexts;

    void Start()
    {
        List<int> scores = ScoreSave.LoadScores();

        for (int i = 0; i < rankTexts.Length; i++)
        {
            if (i < scores.Count)
                rankTexts[i].text = $"{i + 1}位 : {scores[i]}";
            else
                rankTexts[i].text = $"{i + 1}位 : ---";
        }
    }
}
