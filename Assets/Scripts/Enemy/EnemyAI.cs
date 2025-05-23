using System.Collections;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    enum EnemyState
    {
        Roaming
    }

    [SerializeField] float roamingFlipTime;

    EnemyPathFinding enemyPathFinding;
    EnemyState state;

    void Awake()
    {
        enemyPathFinding = GetComponent<EnemyPathFinding>();
        state = EnemyState.Roaming;
    }

    void Start()
    {
        StartCoroutine(Roaming());
    }

    IEnumerator Roaming()
    {
        while (state == EnemyState.Roaming)
        {
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
            enemyPathFinding.SetMoveDirection(randomDirection);
            yield return new WaitForSeconds(roamingFlipTime);
        }
    }
}
