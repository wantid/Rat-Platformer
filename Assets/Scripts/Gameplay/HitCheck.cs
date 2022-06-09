using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public bool hit;

    public string TagToCompare;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(TagToCompare))
            hit = true;
    }
}
