using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private int score = 0;
    public TextMeshProUGUI text;
    public void IncrementScore()
    {
        score += 1;
        text.SetText("Score: "+score.ToString());

    }
}
