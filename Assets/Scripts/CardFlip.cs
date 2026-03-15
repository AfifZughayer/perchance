using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class CardFlip : MonoBehaviour
{

    private RawImage img;
    public Color color = Color.red;

    [SerializeField]
    private float flipSpeed = 100;
    private Quaternion nextRotation;

    // Start is called before the first frame update
    void Awake()
    {
        img = GetComponent<RawImage>();
        nextRotation = transform.rotation;
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
        nextRotation = Quaternion.Euler(0, transform.eulerAngles.y + 180, 0);
        CardComparator.Instance.CompareCard(this);
    }

    public void ReturnFlip()
    {
        nextRotation = Quaternion.Euler(Vector3.zero);
    }

    public void RemoveCard()
    {
        Destroy(gameObject);
    }

}
