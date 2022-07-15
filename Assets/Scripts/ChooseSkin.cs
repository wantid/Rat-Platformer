using UnityEngine;
using UnityEngine.UI;

public class ChooseSkin : MonoBehaviour
{
    public Image image;
    public Text price;

    private int currentImage;
    private int currentSprite;

    private float time;

    public int[] availableSkins = new int[6];
    public static int currentSkinId;

    private Sprite[] currentSkin;

    private void Start()
    {
        DrawSprite();
    }
    private void Update()
    {
        Animation();
    }
    public void ChangeSkin()
    {
        if (currentImage != 0 && availableSkins[currentImage - 1] <= GameManager.coin)
            BuySkin();
        else if (currentImage == 0 || availableSkins[currentImage - 1] == 0)
            currentSkinId = currentImage;
    }
    private void BuySkin()
    {
        GameManager.coin -= availableSkins[currentImage - 1];
        availableSkins[currentImage - 1] = 0;

        currentSkinId = currentImage;
    }
    public void SwipeLeft()
    {
        currentImage--;
        if (currentImage < 0) currentImage = 6;

        DrawSprite();
    }
    public void SwipeRight()
    {
        currentImage++;
        if (currentImage > 6) currentImage = 0;

        DrawSprite();
    }
    private void Animation()
    {
        if (currentImage != 0 && availableSkins[currentImage - 1] != 0)
            image.color = Color.black;

        if (time <= 0)
        {
            time = .2f;
            currentSprite++;
            if (currentSprite > 3) currentSprite = 0;

            image.sprite = currentSkin[currentSprite];

            if (currentImage == 0 || availableSkins[currentImage - 1] == 0)
                image.color = Color.white;
        }
        else
            time -= Time.deltaTime;
    }
    private void DrawSprite()
    {
        switch (currentImage)
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

        if (currentImage != 0 && availableSkins[currentImage - 1] != 0)
            price.text = $"{availableSkins[currentImage - 1]}";
        else
            price.text = "";
    }
}
