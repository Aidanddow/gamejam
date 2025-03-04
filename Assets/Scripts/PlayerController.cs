using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 100)]
    public float mouseSensitivity = 25f;
    [Range(1, 100)]
    public float moveSpeed = 5f;

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var mouseXInput = Input.GetAxis("Mouse X") * mouseSensitivity;
        var input = horizontalInput != 0f ? horizontalInput : mouseXInput;
        var movement = new Vector2(input, 0f) * (moveSpeed * Time.deltaTime);

        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            var item = collision.gameObject.GetComponent<Item>();
            GameController.Instance.ModifyCoinBalance(item.coinModifier);
            Destroy(collision.gameObject);
        }
    }
}
