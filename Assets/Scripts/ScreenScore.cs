using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScore : MonoBehaviour
{
    private int score = 0; // 현재 점수

    // Start is called before the first frame update
    void Start()
    {
        this.score = ScoreManager.GetScore();
        Debug.Log(score);
    }

}
