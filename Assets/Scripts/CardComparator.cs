using System.Collections;
using System;
using UnityEngine;

public class CardComparator : MonoBehaviour
{
    public static CardComparator Instance { get; private set; }
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
                StartCoroutine(Delay(delay, card.RemoveCard));
                StartCoroutine(Delay(delay, c.RemoveCard));
            }
            else
            {
                StartCoroutine(Delay(delay, card.ReturnFlip));
                StartCoroutine(Delay(delay, c.ReturnFlip));
            }
            card = null;
        }
    }

    IEnumerator Delay(int time, Action func)
    {
        yield return new WaitForSeconds(time);
        func?.Invoke();
    }
}
