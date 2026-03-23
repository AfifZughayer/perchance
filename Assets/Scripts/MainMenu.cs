using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class MainMenu : MonoBehaviour
{

    [SerializeField]
    Button cont;

    private void Update()
    {
        cont.interactable = File.Exists(Application.persistentDataPath + "/save.json");
    }

    public void BeginGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("SampleScene");
        SaveSystem.Instance.loading = true;
    }
}
