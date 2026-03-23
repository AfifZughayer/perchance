using UnityEngine;
using System.IO;
using System.Collections.Generic;

public class SaveSystem : MonoBehaviour
{

    public static SaveSystem Instance;
    public bool loading = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void Save()
    {
        CardFlip[] cards = GameObject.FindGameObjectWithTag("Anchor").transform.GetComponentsInChildren<CardFlip>();
        List<CardObject> objects = new List<CardObject>();
        foreach(CardFlip c in cards)
        {
            objects.Add(new CardObject(c.transform.position, c.color));
        }

        CardWrapper wrapper = new CardWrapper(objects.ToArray(), ScoreSystem.Instance.GetScore(), ScoreSystem.Instance.GetTurns());
        string data = JsonUtility.ToJson(wrapper);
        string path = Application.persistentDataPath + "/save.json";
        File.WriteAllText(path, data);
    }
    
    public CardWrapper Load()
    {
        string path = Application.persistentDataPath + "/save.json";
        string data = File.ReadAllText(path);
        CardWrapper cards = JsonUtility.FromJson<CardWrapper>(data);
        return cards;
    }
}
