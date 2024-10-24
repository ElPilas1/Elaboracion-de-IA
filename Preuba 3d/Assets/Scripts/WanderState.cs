using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "WanderState(S)", menuName = "ScriptableObject/States/WanderState")]
public class WanderState : state
{
    private float time = 0f;
    private int x;
    private int z;
    public override state Run(GameObject owner)
    {
        state nextState = CheckActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        time += Time.deltaTime;

        if (time >= 5f)
        {
            x = Random.Range(0, 61);
            z = Random.Range(50, 91);
            time = 0f;
        }
        navMeshAgent.SetDestination(new Vector3(x, 0, z));

        return nextState;
    }
}
