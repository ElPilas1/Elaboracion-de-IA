using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class LIFE : MonoBehaviour
{
    public GameObject[] life;
    public void DesactiveLifes(int index)
    {
        life[index].SetActive(false);
    }
    public void ActiveLifes(int index)
    {
        life[index].SetActive(true);
    }

    private void Update()
    {

    }
}
