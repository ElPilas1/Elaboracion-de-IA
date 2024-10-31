using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
[CreateAssetMenu(fileName = "ShootState(S)", menuName = "ScriptableObject/States/ShootState")]//nos hablidta la opcion de cogerlo en el create
public class ShootState : state
{
    public float radius = 10f;
    public GameObject bala;
    public override state Run(GameObject owner)
    {
        state netxState = CheckActions(owner);//ejecutamos el check actions
        GameObject target = owner.GetComponent<Targetreference>().target;
        Instantiate(bala,owner.transform.position, Quaternion.identity);



    }


}
