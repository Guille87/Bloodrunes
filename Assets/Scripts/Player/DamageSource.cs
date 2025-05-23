using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float pushForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyDamage enemyDamage = collision.gameObject.GetComponent<EnemyDamage>();
        enemyDamage?.Hit(damage);

        PushBack pushBack = collision.gameObject.GetComponent<PushBack>();
        pushBack?.Push((collision.transform.position - transform.position).normalized, pushForce);
    }
}
