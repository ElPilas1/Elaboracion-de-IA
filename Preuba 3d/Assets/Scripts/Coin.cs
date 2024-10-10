using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Score;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovementCC>())
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + Score);
            Destroy(gameObject);

        }
    }

}

