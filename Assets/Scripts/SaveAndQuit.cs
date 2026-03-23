using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class SaveAndQuit : MonoBehaviour
{

    Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ReturnToMenu);
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        SaveSystem.Instance.Save();
    }
}
