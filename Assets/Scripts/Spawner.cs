using System;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Sprite[] lettersInOrder;
    [SerializeField] private float spacing = 1f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] private RotationDirection rotationDirection = RotationDirection.Forward;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        CreateAndPopulateWord();
        CenterPivot();
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(GetDirection(), rotationSpeed * Time.deltaTime);
    }

    private void CreateAndPopulateWord()
    {
        for (var i = 0; i< lettersInOrder.Length; i++)
        {
            var obj = new GameObject($"{lettersInOrder[i].name}_copy");
            obj.transform.SetParent(transform);
            obj.transform.localPosition = new Vector3(i * spacing, 0, 0);
            obj.transform.localScale = transform.localScale;
            
            var spriteRenderer = obj.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = lettersInOrder[i];
            spriteRenderer.sortingLayerName = "Foreground";
            spriteRenderer.sortingOrder = 1;
        }
    }
    
    private void CenterPivot()
    {
        if (lettersInOrder.Length == 0)
        {
            return;
        }

        var totalWidth = (lettersInOrder.Length - 1) * spacing;
        var offset = new Vector3(totalWidth / 2f, 0, 0);
        
        foreach (Transform child in transform)
        {
            child.localPosition -= offset;
        }

        transform.position += offset;
    }

    private Vector3 GetDirection()
    {
        return rotationDirection switch
        {
            RotationDirection.Forward => Vector3.forward,
            RotationDirection.Backward => Vector3.back,
            _ => Vector3.zero
        };
    }
    
    public void ReverseDirection()
    {
        rotationDirection = rotationDirection switch
        {
            RotationDirection.Forward => RotationDirection.Backward,
            RotationDirection.Backward => RotationDirection.Forward,
            _ => rotationDirection
        };
    }

    public void UpdateSpeed(float speed)
    {
        rotationSpeed = speed;
    }
}

public enum RotationDirection
{
    Forward,
    Backward
}
