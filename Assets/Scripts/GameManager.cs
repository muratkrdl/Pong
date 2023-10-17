using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshPro leftScoreText;
    [SerializeField] TextMeshPro rightScoreText;

    int scoreLeft = 0;
    int scoreRight = 0;

    void Update() 
    {
        leftScoreText.text = scoreLeft.ToString();

        rightScoreText.text = scoreRight.ToString();
    }

    public void IncreaseScoreRight()
    {
        scoreRight++;
    }

    public void IncreaseScoreLeft()
    {
        scoreLeft++;
    }

}
