using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSystem : MonoBehaviour
{
    public int maxLives = 5;         
    public int currentLives;          

    public GameObject heartPrefab;   
    public Transform content;        

    private List<GameObject> hearts = new List<GameObject>();  // List for storing active cores

    private void Start()
    {
        currentLives = maxLives;      
        UpdateHeartsUI();            
    }

    // Function to update the cores displayed
    public void UpdateHeartsUI()
    {
        // Deletes all current cores to reset them
        foreach (var heart in hearts)
        {
            Destroy(heart);  // Deletes each object from the list
        }
        hearts.Clear();

        // Adds a heart for each current hit point
        for (int i = 0; i < currentLives; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, content);  // Creates a new heart in the container
            hearts.Add(newHeart);  // Adds the heart to the list for future management
        }
    }

    // Function to add a life
    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;  
            UpdateHeartsUI(); 
        }
    }

    // Fonction pour perdre une vie
    public void LoseLife()
    {
        if (currentLives > 0)
        {
            currentLives--;  
            UpdateHeartsUI();  
        }
    }
}
