using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomMoveEnemy : EnemyStatus
{
    public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetDestiny();
    }

    public override IEnumerator GiveaBreak()
    {
        yield return new WaitForSeconds(2); //tempo de espera
        if (canPatrol)
        {
            SetDestiny();
        }
        else
        {
            SetDestiny(); //setar um novo destino e come�ar a patrulha
        }
    }
}