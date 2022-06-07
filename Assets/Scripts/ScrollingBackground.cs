using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public Transform[] items;

    public float speed;
    public float minX;

    public Vector3 direction;
    public Vector3 startPosition;

    private float delayTime;

    private void FixedUpdate()
    {
        foreach (Transform i in items)
        {
            if (i.transform.position.x < minX)
            {
                i.transform.position = startPosition + direction;
            }
            if (delayTime <= 0)
                i.transform.position = i.transform.position + direction;
        }

        if (delayTime <= 0) delayTime = 1;
        else delayTime -= Time.deltaTime * speed;
    }
}
