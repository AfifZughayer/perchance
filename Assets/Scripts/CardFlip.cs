using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class CardFlip : MonoBehaviour
{

    private RawImage img;
    public Color color = Color.red;
    [SerializeField]
    private AudioClip flipSound;

    [SerializeField]
    private float flipSpeed = 100;
    private Quaternion nextRotation;
    bool isFlipped = true;

    // Start is called before the first frame update
    void Awake()
    {
        img = GetComponent<RawImage>();
        nextRotation = transform.rotation;
    }

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        nextRotation = Quaternion.Euler(0, 180, 0);
        Invoke("ReturnFlip", 3);
    }

    private void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, nextRotation, 1.0f/flipSpeed);
        if (transform.eulerAngles.y < 90 || transform.eulerAngles.y > 270)
            img.color = Color.white;
        else
            img.color = color;
    }

    public void FlipCard()
    {
        if (isFlipped) return;
        nextRotation = Quaternion.Euler(0, 180, 0);
        CardComparator.Instance.CompareCard(this);
        AudioManager.Instance.PlaySound(flipSound);
        isFlipped = true;
    }

    public void ReturnFlip()
    {
        nextRotation = Quaternion.Euler(Vector3.zero);
        isFlipped = false;
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
    }

}
