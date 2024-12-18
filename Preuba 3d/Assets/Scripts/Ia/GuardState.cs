using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "GuardState(S)", menuName = "ScriptableObject/States/GuardState")]
public class GuardState : state
{
    public string blendParameter;
    public Vector3 guardPoint;



    public override state Run(GameObject owner)
    {
        state NextState = CheckActions(owner);


        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(guardPoint);
        Animator animator = owner.GetComponent<Animator>();

        animator.SetFloat(blendParameter, navMeshAgent.velocity.magnitude / navMeshAgent.speed);
        return NextState;

    }







}
