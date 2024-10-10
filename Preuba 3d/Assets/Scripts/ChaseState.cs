using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "ChaseState(S)", menuName = "ScriptableObject/States/ChaseState")]//nos hablidta la opcion de cogerlo en el create
public class ChaseState : state
{
    // Start is called before the first frame update


    // Update is called once per frame
    public override state Run(GameObject owner)
    {
        state netxState = ChechkActions(owner);//ejecutamos el chec actions



        NavMeshAgent navMeshAgent = owner.GetComponent<NavMeshAgent>();//el owner es el que tiene el objecto

        GameObject target = owner.GetComponent<Targetreference>().target;//para que persiga el objetivo
        navMeshAgent.SetDestination(target.transform.position);//hace que le persiga,es su objectivo y el coso que le pngamos es su destino y esquivara los obstaculos




        return netxState;
    }





}
