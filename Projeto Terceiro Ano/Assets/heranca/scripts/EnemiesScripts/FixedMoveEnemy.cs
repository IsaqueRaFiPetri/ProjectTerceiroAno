using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class FixedMoveEnemy : EnemyStatus
{
    public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        NextPointFixerdPatrol();
    }

    public override IEnumerator GiveaBreak()
    {
        yield return new WaitForSeconds(2); //tempo de espera
        if (canPatrol)
        {
            NextPointFixerdPatrol();
        }
        else
        {
            NextPointFixerdPatrol(); //setar um novo destino e começar a patrulha
        }
    }
}
