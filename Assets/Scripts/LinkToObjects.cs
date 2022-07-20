using UnityEngine;

public class LinkToObjects : MonoBehaviour
{
    public static int maxScore;

    public GameObject[] miniLevels;
    public GameObject[] stationLevels;
    public GameObject Bonus;

    public Sprite[] defaultSkin = new Sprite[14];
    public Sprite[] magicSkin = new Sprite[14];
    public Sprite[] treeHatSkin = new Sprite[14];
    public Sprite[] electroSkin = new Sprite[14];
    public Sprite[] creamSkin = new Sprite[14];
    public Sprite[] creamHatSkin = new Sprite[14];
    public Sprite[] skeletonSkin = new Sprite[14];

    public Transform Level;

    [HideInInspector] public static LinkToObjects instance;

    void Awake()
    {
        instance = this;
    }
}
