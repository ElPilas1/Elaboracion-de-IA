using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public state initialState;
    private state currentState;
    // Start is called before the first frame update
    void Start()
    {
        currentState = initialState;
    }

    // Update is called once per frame
    void Update()
    {


        state nextState = currentState.Run(gameObject);
        if (nextState)//si nextstate no es nulo cambiamos la variable de nextstate o siguiente estado
        {

            currentState = nextState;


        }
        //hay que ejecutar el estado y si en algun momento el estado cambia tenemos que cambiar el current state,relacionar el nextstate con el run
    }
    private void OnDrawGizmos()
    {
        if (currentState)//si no tiene el circulo lo dibujas
            currentState.DrawAllActionsGizmos(gameObject);
        else//
            initialState.DrawAllActionsGizmos(gameObject);
    }
}
