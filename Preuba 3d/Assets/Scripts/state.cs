using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[System.Serializable]
public struct ActionParameters//este struct sirve para relacionar un booleano con una acci�n
{
    [Tooltip("Action that is gonna be executed")]
    public Action action;
    [Tooltip("Indicates if the action's check must be true or false")]
    public bool actionValue;
}

[System.Serializable]


public struct StateParameters
{
    [Tooltip("ActionParameters array")]
    public ActionParameters[] actionParameters;
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
            bool allactions = true;//asumimos que todas las aciones e han cumplido
            for (int j = 0; j < stateParameters[i].actionParameters.Length; j++)//AL HABER UN ARRAY DENTRO DE OTRO RECORRE EL ARRAY DE LAS ACCIONES DE DEBE,PS RECPRRER
            {
                ActionParameters actionParameters = stateParameters[i].actionParameters[j];

                if (actionParameters.action.Check(owner) == actionParameters.actionValue)//si entramos en este if significa que la accion se ha cumplido
                {
                    if (!stateParameters[i].and)//si solo se tiene que cumplir una accis�n
                    {
                        //devovlemos el siguiente estado
                        return stateParameters[i].NextState;
                    }
                }
                else if (stateParameters[i].and)
                {
                    allactions = false;
                    break;//se sale del bucle,porque una accion no se ha cumplido y estamos en and
                }

            }
            //si llegamos hasta aqui,signfica que el disenador ha marcado que todas las acciones 
            //tienen que cumplirse,y ademas se han cumplido
            if (stateParameters[i].and && allactions)//tenemos que comprobar si todas las acciones se han cumplido
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
            foreach (ActionParameters aP in parameter.actionParameters)
            {
                aP.action.DrawGizmo(owner);
            }
        }
    }



}

















