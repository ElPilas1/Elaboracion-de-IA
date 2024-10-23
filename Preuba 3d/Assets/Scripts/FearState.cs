using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "FearState(S)", menuName = "ScriptableObject/States/FearState")]
public class FearState : state
{
    public float radius = 10f;
    private PlayerMovementCC playerMovementCC;

    public override state Run(GameObject owner)
    {
        state NextState = ChechkActions(owner);
        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();
        GameObject target = owner.GetComponent<Targetreference>().target;

        target.GetComponent<PlayerMovementCC>().enabled = false;

        return NextState;
    }
    // Start is called before the first frame update
}
