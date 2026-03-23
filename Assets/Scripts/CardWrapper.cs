using UnityEngine;

[System.Serializable]
public class CardWrapper
{
    [SerializeField]
    CardObject[] objects;
    [SerializeField]
    int score;
    [SerializeField]
    int turns;

    public CardWrapper(CardObject[] o, int s, int t)
    {
        objects = o;
        score = s;
        turns = t;
    }

    public CardObject[] GetCards()
    {
        return objects;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetTurns()
    {
        return turns;
    }
}
