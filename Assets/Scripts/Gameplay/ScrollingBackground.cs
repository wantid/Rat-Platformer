using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public GameObject[] tunnel;
    public GameObject[] station;

    public Transform[] items;
    public Transform[] parallaxItems;

    public float speed;
    public float minX;

    public Vector3 direction;
    public Vector3 startPosition;

    private float parallaxDelay;

    private float delayTime;

    private static bool changeBackground;

    private void Awake()
    {
        changeBackground = false;
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].position.x < minX)
            {
                items[i].position = startPosition + direction;

                tunnel[i].SetActive(!changeBackground);
                station[i].SetActive(changeBackground);
            }
            if (delayTime <= 0)
                items[i].position = items[i].position + direction;
        }
        if (parallaxDelay <= 0)
        {
            parallaxDelay = 2f;
            foreach (Transform i in parallaxItems)
            {
                if (i.transform.position.x < minX)
                    i.transform.position = startPosition + direction;
                if (delayTime <= 0)
                    i.transform.position = i.transform.position + direction;
            }
        } else parallaxDelay -= Time.deltaTime * speed;

        if (delayTime <= 0) delayTime = 1;
        else delayTime -= Time.deltaTime * speed;
    }

    [ContextMenu("ChangeLevel")]
    public void ChangeLevel()
    {
        changeBackground = !changeBackground;
    }
}
