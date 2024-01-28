using UnityEngine;

public class SpriteSwapper : MonoBehaviour
{
    public Sprite[] sprites;
    public float swapInterval = 2f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating(nameof(SwapSprite), swapInterval, swapInterval);
    }

    private void SwapSprite()
    {
        if (sprites.Length == 0)
        {
            Debug.LogWarning("No sprites assigned.");
            return;
        }

        int randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
    }
}
