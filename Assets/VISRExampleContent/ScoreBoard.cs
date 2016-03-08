using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class ScoreBoard : MonoBehaviour {

    public static ScoreBoard Instance = null;

    int score = 0;
    int lastScore = 0;

    void Awake()
    {
        transform.name = "ScoreBoard";
        Instance = this;
    }

    public void IncrementScore()
    {
        score = score + 1;
        GetComponent<TextMesh>().text = "SCORE : " + score;
    }
}
