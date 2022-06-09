using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public HitCheck hitCheck;

    public int healthPoints;

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
            Instantiate(LinkToObjects.instance.Bonus, transform.position, Quaternion.identity, LinkToObjects.instance.Level);
            Destroy(gameObject);
        }
    }
}
