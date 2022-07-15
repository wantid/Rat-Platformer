using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public Vector3 direction;

    public Sprite[] sprites;

    public float speed;
    public float animationLength;

    public bool isAnimated;

    private SpriteRenderer spriteRenderer;

    private float curTime;
    private float delayTime;

    private int currentSprite;

    public void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        MoveObject();

        if (isAnimated) LoopAnimation();
    }
    private void MoveObject()
    {
        if (transform.position.x < -350)
        {
            Destroy(gameObject);
        }
        if (delayTime <= 0)
            transform.position = transform.position + direction;

        if (delayTime <= 0) delayTime = 1;
        else delayTime -= Time.deltaTime * speed;
    }
    private void LoopAnimation()
    {
        if (curTime <= 0)
        {
            curTime = animationLength / sprites.Length;

            currentSprite++;
            if (currentSprite > sprites.Length - 1)
                currentSprite = 0;

            spriteRenderer.sprite = sprites[currentSprite];
        }
        else curTime -= Time.deltaTime;
    }
}
