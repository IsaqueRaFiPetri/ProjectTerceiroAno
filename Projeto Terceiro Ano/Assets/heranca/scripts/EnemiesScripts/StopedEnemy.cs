using System.Collections;
using UnityEngine;
using UnityEngine.AI;


public class StopedEnemy : EnemyStatus
{
    public override void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public override void Update()
    {
        //vazio para ele não se mexer ^_^ 
    }
}
