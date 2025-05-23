using System.Collections;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int initialHealth;
    [SerializeField] float hitEffectDuration;

    Material material;
    int currentHealth;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        currentHealth = initialHealth;
    }

    public void Hit(int damage)
    {
        currentHealth -= damage;
        
        StartCoroutine(HitEffect());
    }

    IEnumerator HitEffect()
    {
        material.color = Color.red;
        yield return new WaitForSeconds(hitEffectDuration);
        material.color = Color.white;

        CheckDeath();
    }

    void CheckDeath()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
