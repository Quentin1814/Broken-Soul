using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    public int damageOnCollision = 20;
    public bool isInWater = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInWater = true;
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            StartCoroutine(TakeDamage(playerHealth));



        }
    }

    public IEnumerator TakeDamage(PlayerHealth playerHealth)
    {
        while (isInWater)
        {

            playerHealth.GetLife(damageOnCollision);
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInWater = false;
    }
}
