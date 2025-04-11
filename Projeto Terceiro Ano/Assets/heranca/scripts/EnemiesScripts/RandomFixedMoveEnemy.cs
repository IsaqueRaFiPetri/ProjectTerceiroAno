using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class RandomFixedMoveEnemy : EnemyStatus
{
    public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SetRandomFixedPointDestiny();
    }

    public override IEnumerator GiveaBreak()
    {
        yield return new WaitForSeconds(2); //tempo de espera
        if (canPatrol)
        {
            SetRandomFixedPointDestiny();
        }
        else
        {
            SetRandomFixedPointDestiny(); //setar um novo destino e começar a patrulha
        }
    }
}
