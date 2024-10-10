using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "GuardState(S)", menuName = "ScriptableObject/States/GuardState")]
public class GuardState : state
{

    public Vector3 guardPoint;



    public override state Run(GameObject owner)
    {
        state NextState = ChechkActions(owner);


        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(guardPoint);


        return NextState;

    }







}
