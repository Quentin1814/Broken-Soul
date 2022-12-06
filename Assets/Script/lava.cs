using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour
{
    public int damageOnCollision = 20;
    public bool isInLava = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInLava = true;
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            StartCoroutine(TakeDamage(playerHealth));
        }
    }

    public IEnumerator TakeDamage(PlayerHealth playerHealth)
    {
        while (isInLava)
        {
            
            playerHealth.TakeDamage(damageOnCollision);
            yield return new WaitForSeconds(3f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInLava = false;
    }
}