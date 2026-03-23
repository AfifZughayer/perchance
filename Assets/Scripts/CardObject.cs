using UnityEngine;

[System.Serializable]
public class CardObject
{

    [SerializeField]
    Vector3 pos;
    [SerializeField]
    Color color;

    public CardObject(Vector3 _pos, Color _color)
    {
        pos = _pos;
        color = _color;
    }
    public Vector3 GetPos()
    {
        return pos;
    }
    public Color GetColor()
    {
        return color;
    }
}
