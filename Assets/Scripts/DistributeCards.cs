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
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private AudioClip gameOver;

    List<Color> colors = new List<Color>() { Color.red, Color.blue, Color.green, Color.gray, Color.black, Color.yellow, Color.magenta, Color.cyan};

    // Start is called before the first frame update
    void Start()
    {
        if (SaveSystem.Instance.loading == false)
            FreshShuffle();
        else
            LoadShuffle();
    }

    private void Update()
    {
        if (transform.childCount > 0 || panel.activeInHierarchy == true) return;
        AudioManager.Instance.PlaySound(gameOver);
        panel.SetActive(true);
    }

    void FreshShuffle()
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject o = Instantiate(card, transform);
            CardFlip c = o.GetComponent<CardFlip>();
            c.color = colors[i / 2];
        }
        ShuffleCards(transform.GetComponentsInChildren<CardFlip>());
        Invoke("RemoveLayoutGroup", 0.5f);
    }

    void LoadShuffle()
    {
        RemoveLayoutGroup();
        CardWrapper wrapper = SaveSystem.Instance.Load();
        CardObject[] savedCards = wrapper.GetCards();
        foreach (CardObject savedCard in savedCards)
        {
            GameObject o = Instantiate(card, transform);
            CardFlip c = o.GetComponent<CardFlip>();
            c.transform.position = savedCard.GetPos();
            c.color = savedCard.GetColor();
        }
        ScoreSystem.Instance.SetScore(wrapper.GetScore());
        ScoreSystem.Instance.SetTurns(wrapper.GetTurns());
        SaveSystem.Instance.loading = false;
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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
