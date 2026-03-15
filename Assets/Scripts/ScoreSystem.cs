using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    public static ScoreSystem Instance;


    [SerializeField]
    private TextMeshProUGUI text;
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

    private void UpdateText()
    {
        text.text = "Score:\n" + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ResetCombo()
    {
        combo = 0;
    }

    public void AddScore()
    {
        score += 10*combo + 10;
        combo++;
        UpdateText();
    }
}
