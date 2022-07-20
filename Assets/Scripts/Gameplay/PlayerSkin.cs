using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    public Sprite[] currentSkin = new Sprite[14];

    private SpriteRenderer spriteRenderer;

    public int currentSprite;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        switch (ChooseSkin.currentSkinId)
        {
            case 1:
                currentSkin = LinkToObjects.instance.magicSkin;
                break;
            case 2:
                currentSkin = LinkToObjects.instance.treeHatSkin;
                break;
            case 3:
                currentSkin = LinkToObjects.instance.electroSkin;
                break;
            case 4:
                currentSkin = LinkToObjects.instance.creamSkin;
                break;
            case 5:
                currentSkin = LinkToObjects.instance.creamHatSkin;
                break;
            case 6:
                currentSkin = LinkToObjects.instance.skeletonSkin;
                break;
            default:
                currentSkin = LinkToObjects.instance.defaultSkin;
                break;
        }
    }

    void Update()
    {
        spriteRenderer.sprite = currentSkin[currentSprite];
    }
}
