using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]


public struct StateParameters
{
    [Tooltip("Indicates if the action's check must be true or false")]
    public bool[] actionValue;
    [Tooltip("Action that is gonna be executed")]
    public Action[] action;
    [Tooltip("If the action's check equals actionValue,nextState is pushed")]
    public state NextState;
    [Tooltip("all the actions are checked")]
    public bool and;

}
//Array de aciciones seria public Action[] actions;


public abstract class state : ScriptableObject
{
    public StateParameters[] stateParameters;
    protected state ChechkActions(GameObject owner)
    {
        for (int i = 0; i < stateParameters.Length; i++)//RECORRE TODOS LOS PARAMETROS
        {
            for (int j = 0; j < stateParameters[i].action.Length; j++)//AL HABER UN ARRAY DENTRO DE OTRO RECORRE EL ARRAY DE LAS ACCIONES DE DEBE,PS RECPRRER
            {
                if (stateParameters[i].action[j].Check(owner) == stateParameters[i].actionValue[j])
                {
                    if (!stateParameters[i].and)//si solo se tiene que cumplir una accisón
                    {
                        //devovlemos el siguiente estado
                        return stateParameters[i].NextState;
                    }
                }
                //else if (stateParameters[i].and)
                //{
                //    //estamos seguros de que esta accion s eha cumplido
                //    continue;
                //}

            }
            //si llegamos hasta aqui,signfica que el disenador ha marcado que todas las acciones 
            //tienen que cumplirse,y ademas se han cumplido
            if (stateParameters[i].and)
            {
                return stateParameters[i].NextState;
            }
        }
        return null;//NO SE CUMPLE CAMBIAMOS DE ESTADO



        //devolvera true si alguna de sus acciones se cumple,o false si es al contrario
    }
    public abstract state Run(GameObject owner);//el run de la clase state no hace nada
    public void DrawAllActionsGizmos(GameObject owner)
    {
        foreach (StateParameters parameter in stateParameters)
        {
            parameter.action.DrawGizmo(owner);
        }
    }



}

















