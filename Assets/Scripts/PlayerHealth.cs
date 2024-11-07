using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 5; 
    private int currentHealth;

    private UIController uiController; 

    private void Start()
    {
        currentHealth = maxHealth;

        
        uiController = FindObjectOfType<UIController>();

        
        if (uiController != null)
        {
            uiController.UpdateHeartsUI(currentHealth);
        }
    }

    // Inflige des dégâts au joueur
    public void TakeDamage(int damage)
    {
        if (damage <= 0 || currentHealth <= 0) return; 

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        
        if (uiController != null)
        {
            uiController.UpdateHeartsUI(currentHealth);
        }

        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Soigne le joueur
    public void Heal(int healAmount)
    {
        if (healAmount <= 0 || currentHealth >= maxHealth) return; 

        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        
        if (uiController != null)
        {
            uiController.UpdateHeartsUI(currentHealth);
        }
    }

    /
    private void Die()
    {
        Debug.Log("Le joueur est mort !");
        
}
