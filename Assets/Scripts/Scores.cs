using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{
    public Text textContainer;

    private static int currentScore;
    private static string scoreText;

    private float curTime;

    void Update()
    {
        TimeScore();

        textContainer.text = $"SCORE: {scoreText}";
    }
    private void TimeScore()
    {
        if (curTime <= 0)
        {
            curTime = 5;
            AddScore(1);
        }
        else curTime -= Time.deltaTime;
    }
    public static void AddScore(int change)
    {
        currentScore += change;

        if (currentScore < 999999)
        {
            int count = 6 - currentScore.ToString().Length;
            scoreText = "";

            while (count > 0)
            {
                scoreText += "0";
                count--;
            }    

            scoreText += currentScore.ToString();
        }
        else
        {
            currentScore = 999999;
            scoreText = currentScore.ToString();
        }
    }
}
