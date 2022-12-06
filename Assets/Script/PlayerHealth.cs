using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public float DamageTimeAfterHit = 2f;
    public float DamageFlashDelay = 0.2f;
    public bool takeDamage = false;

    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public GameObject Win;

    void Start()
    {
        Win.SetActive(false);
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        while (!takeDamage)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            takeDamage = true;
            StartCoroutine(DamageFlash());
            StartCoroutine(HandleDamageDelay());
                
            if (currentHealth == 0)
            {
                StartCoroutine(LoadNextLevel());
            }
        }
    }
    public void GetLife(int damage)
    {
        while (!takeDamage)
        {
            if (currentHealth < 100)
            {
                currentHealth += damage;
                healthBar.SetHealth(currentHealth);
                takeDamage = true;
                StartCoroutine(DamageFlash());
                StartCoroutine(HandleDamageDelay());
            }
            else
            {
                takeDamage = true;
                StartCoroutine(HandleDamageDelay());
            }
        }
        
    }

    public IEnumerator DamageFlash()
    {
        while (!takeDamage)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(DamageFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(DamageFlashDelay);
        }
    }

    public IEnumerator HandleDamageDelay()
    {
        yield return new WaitForSeconds(DamageTimeAfterHit);
        takeDamage = false;
    }

    public IEnumerator LoadNextLevel()
    {
        Win.SetActive(true);

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}