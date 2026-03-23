using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    public static ScoreSystem Instance;


    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private TextMeshProUGUI turnText;
    private int turns = 0;
    private int score = 0;
    private int combo = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public int GetTurns()
    {
        return turns;
    }

    public void ResetCombo()
    {
        combo = 0;
    }

    public void SetScore(int s)
    {
        score = s;
        scoreText.text = "Score:\n" + score;
    }

    public void SetTurns(int t)
    {
        turns = t;
        turnText.text = "Turns:\n" + turns;
    }

    public void AddScore()
    {
        score += 10*combo + 10;
        combo++;
        scoreText.text = "Score:\n" + score;
    }

    public void AddTurns()
    {
        turns++;
        turnText.text = "Turns:\n" + turns;
    }
}
