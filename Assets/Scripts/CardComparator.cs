using System.Collections;
using System;
using UnityEngine;

public class CardComparator : MonoBehaviour
{
    public static CardComparator Instance;
    public CardFlip card;

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

    public void CompareCard(CardFlip c)
    {
        if (card == null)
        {
            card = c;
        }
        else
        {
            const int delay = 1;
            if (card.color == c.color)
            {
                StartCoroutine(Delay(delay, card.RemoveCard, c.RemoveCard, ScoreSystem.Instance.AddScore));
            }
            else
            {
                StartCoroutine(Delay(delay, card.ReturnFlip, c.ReturnFlip, ScoreSystem.Instance.ResetCombo));
            }
            card = null;
        }
    }

    IEnumerator Delay(int time, params Action[] func)
    {
        yield return new WaitForSeconds(time);
        foreach (Action f in func)
            f?.Invoke();
    }
}
