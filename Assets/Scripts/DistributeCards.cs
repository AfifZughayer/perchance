using UnityEngine;

public class DistributeCards : MonoBehaviour
{

    [SerializeField]
    private GameObject card;
    [SerializeField]
    private int amount = 16;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amount; i++)
            Instantiate(card, transform);
    }
}
