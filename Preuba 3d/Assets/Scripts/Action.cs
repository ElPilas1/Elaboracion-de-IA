using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName ="ChaseState(S)",menuName="ScriptableObject/States/ChaseState")]
public  abstract class Action : ScriptableObject
{

  
    // public Action[] actions;


    //private bool ChechkActions()
    //{
    //devolvera true si alguna de sus acciones se cumple,o false si es al contrario
    // }

    public abstract bool Check(GameObject owner);//el check devuelve un bool











}
