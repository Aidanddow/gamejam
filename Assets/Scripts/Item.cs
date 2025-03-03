using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float fallSpeed = 2f;
    public ItemType type;

    void Awake()
    {
        // name = $"Item ({type.description})";
        // var spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteRenderer.color = type.color;
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
