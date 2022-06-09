using UnityEngine;

public class LinkToObjects : MonoBehaviour
{
    public static int maxScore;

    public GameObject[] miniLevels;
    public GameObject Bonus;

    public Transform Level;

    [HideInInspector] public static LinkToObjects instance;
    void Awake()
    {
        instance = this;
    }
}
