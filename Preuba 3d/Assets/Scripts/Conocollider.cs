using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conocollider : MonoBehaviour
{
   public List<GameObject> list=new List<GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        list.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        list.Remove(other.gameObject);
    }
    public List<GameObject> GetVisionList()
    {
        return list;
    }
}
