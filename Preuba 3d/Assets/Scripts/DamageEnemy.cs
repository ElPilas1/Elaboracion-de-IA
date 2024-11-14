using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageEnemey : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent< PlayerMovementCC>())
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth)
            {
                playerHealth.LoseLifes();
                //Destroy(collision.gameObject);
            }
        }
    }
}
