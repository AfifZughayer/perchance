using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class DistributeCards : MonoBehaviour
{

    [SerializeField]
    private GameObject card;
    [SerializeField]
    private int amount = 16;

    List<Color> colors = new List<Color>() { Color.red, Color.blue, Color.green, Color.gray, Color.black, Color.yellow, Color.magenta, Color.cyan};

    // Start is called before the first frame update
    void Start()
    {
        ScoreSystem.Instance.ResetScore();
        for (int i = 0; i < amount; i++)
        {
            GameObject o = Instantiate(card, transform);
            CardFlip c = o.GetComponent<CardFlip>();
            c.color = colors[i/2];
        }
        ShuffleCards(transform.GetComponentsInChildren<CardFlip>());
        Invoke("RemoveLayoutGroup", 0.5f);
    }

    private void Update()
    {
        if (transform.childCount > 0) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void ShuffleCards(CardFlip[] list)
    {
        foreach (CardFlip c in list)
        {
            c.transform.SetSiblingIndex(Random.Range(0, list.Length));
        }
    }

    void RemoveLayoutGroup()
    {
        Destroy(GetComponent<GridLayoutGroup>());
    }
}
