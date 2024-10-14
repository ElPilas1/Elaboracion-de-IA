using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public abstract class Action : ScriptableObject
{


    // public Action[] actions;


    //private bool ChechkActions()
    //{
    //devolvera true si alguna de sus acciones se cumple,o false si es al contrario
    // }

    public abstract bool Check(GameObject owner);//el check devuelve un bool

    public abstract void DrawGizmo(GameObject owner);











}
