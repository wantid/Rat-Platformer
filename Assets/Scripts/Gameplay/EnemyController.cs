using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HitCheck hitCheck;

    public int healthPoints;

    public Vector3 bonusOffset;

    void Update()
    {
        HealthChange();
        Death();
    }

    private void HealthChange()
    {
        if (hitCheck.hit == true)
        {
            hitCheck.hit = false;
            healthPoints--;
        }
    }

    private void Death()
    {
        if (healthPoints <= 0)
        {
            Instantiate(LinkToObjects.instance.Bonus, transform.position + bonusOffset, Quaternion.identity, LinkToObjects.instance.Level);
            Destroy(gameObject);
        }
    }
}
