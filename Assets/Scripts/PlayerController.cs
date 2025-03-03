using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public ScoreTracker scoreTracker;

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var movement = new Vector2(horizontalInput, 0f) * (moveSpeed * Time.deltaTime);
        transform.Translate(movement);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.CompareTag("Item"))
        // {
        //     var item = collision.gameObject.GetComponent<Item>();
        //     scoreTracker.ModifyScore(item.type.scoreModifier);
        //     Debug.Log("Score: " + scoreTracker.GetScore());
        //     Destroy(collision.gameObject);
        // }
        if (collision.CompareTag("GoodItem"))
        {
            scoreTracker.ModifyScore(1);
            Debug.Log("Score: " + scoreTracker.GetScore());
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("BadItem"))
        {
            scoreTracker.ModifyScore(-1);
            Debug.Log("Score: " + scoreTracker.GetScore());
            Destroy(collision.gameObject);
        }
    }
}
