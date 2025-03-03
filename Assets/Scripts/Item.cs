using UnityEngine;

public class Item : MonoBehaviour
{
    [Range(-10, 10)]
    [Tooltip("Value used to modify player coin balance when collected")]
    public int coinModifier;
    public string description;
    [Range(1, 10)]
    [Tooltip("Higher value means faster item speed when falling")]
    public float fallSpeed = 2f;

    void Awake()
    {
        name = $"Item ({description})";
    }

    void Update()
    {
        transform.Translate(Vector2.down * (fallSpeed * Time.deltaTime));
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
