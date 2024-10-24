using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PassTimeAction(A)", menuName = "ScriptableObject/Action/PassTimeAction")]
public class PassTimeAction : Action
{
    private float currentTime;
    public float maxTime;

    public override bool Check(GameObject owner)
    {
        currentTime += Time.deltaTime;
        if (currentTime > maxTime)
        {
            currentTime = 0;
            return true;
        }

        return false;
    }

    public override void DrawGizmo(GameObject owner)
    {

    }
}
