using UnityEngine;

public class Swapper : MonoBehaviour
{
    public Sprite[] sprites;
    public float swapInterval = 2f;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        int randomIndex = Random.Range(0, sprites.Length);
        spriteRenderer.sprite = sprites[randomIndex];
        swapInterval= Random.Range(0, 4);
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
