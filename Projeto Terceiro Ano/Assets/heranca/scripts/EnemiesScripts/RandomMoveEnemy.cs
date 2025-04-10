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

    public override void Update()
    {
        switch (monsterAI)
        {
            case MonsterAI.Break: 
                break;
            case MonsterAI.Patrolling:
                if (agent.stoppingDistance >= agent.remainingDistance)
                { 
                    SetMonsterAI(MonsterAI.Break);
                }
                break;
            case MonsterAI.Chasing:
                break;
        }

        if (Physics.Linecast(vision.position, playerPos.position, out hit))
        {
            if (hit.distance >= 10) //se o player estiver longe, nem executa
                return;
            if (hit.collider.CompareTag("Player")) //caso veja o player
            {
                if (monsterAI.Equals(MonsterAI.Chasing)) //se bão for o modo CHASING
                {
                    SetMonsterAI(MonsterAI.Chasing); //Mude para Chasing
                    StopAllCoroutines(); //Para a Coroutine do modo de espera
                }
                agent.SetDestination(playerPos.position);
                //Fica atualizañdo o destino dele para a posição do player
            }
            else
            { //se perder o player de vista
                if (monsterAI.Equals(MonsterAI.Chasing))
                    SetMonsterAI(MonsterAI.Break); //caso ainda esteja caçando , cancela
            }

            print(hit.collider.name);
        }
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
            SetDestiny(); //setar um novo destino e começar a patrulha
        }
    }
}