using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SeeActions (A)", menuName = "ScriptableObject/Action/SeeActions")]//IMPORTANTE
public class SeeActions : Action
{
    public float AngleVision; //el angulo que le das a la vista (mas o menos la vista es de 100)
    public override bool Check(GameObject owner)
    {
        GameObject target = owner.GetComponent<Targetreference>().target;
        Conocollider conocollider = owner.GetComponentInChildren<Conocollider>();
        List<GameObject> visionList = conocollider.GetVisionList();
        foreach (GameObject gameObjectInVision in visionList)
        {
            if (gameObjectInVision == target)
            {
                return true;

            }
        }
        //Vector3 dir = target.transform.position - owner.transform.position;//la direccion donde se va la vista

        //float angle = Vector3.Angle(dir, owner.transform.forward);//Coge el angulo del player y donde esta el enemigo

        //Debug.DrawRay(owner.transform.position + owner.transform.up, dir);

        //if (angle < AngleVision * 0.5f)//si el angulo que se ve  es menor al angulo de vision
        //{
        //    RaycastHit hits;//el raycast se utiliza si le da al enemigo


        //    if (Physics.Raycast(owner.transform.position + owner.transform.up, dir.normalized, out hits, 30f))//te mira si estas dando el raycast
        //    {

        //        if (hits.collider.gameObject == target)//si pegas o tocas al  taget 
        //        {
        //            return true; //lo ve
        //        }

        //    }
        return false;

    }


    // RaycastHit[] hits = Physics.RaycastAll(owner.transform.position, Vector3.forward, 30f);//
    // GameObject target = owner.GetComponent<Target>().target;

    public override void DrawGizmo(GameObject owner)
    {

    }

}

