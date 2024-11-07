using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;          
    private int currentHealth;         

    private LifeSystem lifeSystem;     

    private void Start()
    {
        
        currentHealth = maxHealth;

       
        lifeSystem = FindObjectOfType<LifeSystem>();
        if (lifeSystem != null)
        {
            
            lifeSystem.maxLives = maxHealth;
            lifeSystem.currentLives = currentHealth;
            lifeSystem.UpdateHeartsUI();
        }
    }

    // Function to inflict damage on the player
    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)  
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  

            
            if (lifeSystem != null)
            {
                lifeSystem.currentLives = currentHealth;  
                lifeSystem.UpdateHeartsUI();
            }

            
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    // Function to heal the player
    public void Heal(int healAmount)
    {
        if (currentHealth < maxHealth)  
        {
            currentHealth += healAmount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

            
            if (lifeSystem != null)
            {
                lifeSystem.currentLives = currentHealth;  
                lifeSystem.UpdateHeartsUI();
            }
        }
    }

    // Function called when the player dies
    private void Die()
    {
        Debug.Log("Le joueur est mort !");
        // Ajoute ici la logique de mort, comme recharger la scène, afficher un écran de Game Over, etc.
    }
}
