using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "FearAction(A)", menuName = "ScriptableObject/Action/FearAction")]
public class FearAction : Action
{
    public float radius = 10f;
    public PlayerMovementCC playerMovementCC;

    public override bool Check(GameObject owner)
    {
        RaycastHit[] hits = Physics.SphereCastAll(owner.transform.position, radius, Vector3.up);


        //if (playerMovementCC.GetComponent(CapsuleCollider))
        {














        }
        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(owner.transform.position, radius);
    }

    // Start is called before the first frame update
}
