using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    //variables
    public TMP_Text ScoreText;
    int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetScore();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreText(score);
    }

    public void CountScore()
    {
        score++;
        UpdateScoreText(score);
    }

    void UpdateScoreText(int NewScore)
    {
        ScoreText.text = "Score: " + NewScore.ToString();
    }
}
