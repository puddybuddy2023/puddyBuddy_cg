using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public static ScoreManager Instance; // 싱글톤 인스턴스

    public int score; // 현재 점수

    public ScoreManager()
    {
        Debug.Log("score manager 초기화");
    }

    public void UpdateScore(int amount)
    {
        score += amount;
    }

    public static int GetScore()
    {
        return GetInstance().score;
    }
}
