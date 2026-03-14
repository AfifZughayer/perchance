using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DistributeCards : MonoBehaviour
{

    [SerializeField]
    private GameObject card;
    [SerializeField]
    private int amount = 16;

    List<CardFlip> cards = new List<CardFlip>();
    List<Color> colors = new List<Color>() { Color.red, Color.blue, Color.green, Color.gray, Color.black, Color.yellow, Color.magenta, Color.cyan};

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject o = Instantiate(card, transform);
            CardFlip c = o.GetComponent<CardFlip>();
            c.color = colors[i/2];
            cards.Add(c);
        }
        ShuffleCards(cards);
        Invoke("RemoveLayoutGroup", 0.5f);
    }

    void ShuffleCards(List<CardFlip> list)
    {
        foreach (CardFlip c in list)
        {
            c.transform.SetSiblingIndex(Random.Range(0, list.Count));
        }
    }

    void RemoveLayoutGroup()
    {
        Destroy(GetComponent<GridLayoutGroup>());
    }
}
