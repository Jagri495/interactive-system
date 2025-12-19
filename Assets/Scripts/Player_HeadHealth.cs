using TMPro;
using UnityEngine;

public class Player_HeadHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public TextMeshProUGUI currentHealthText;

    void Update()
    {
        currentHealthText.text = currentHealth + "%";
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        Debug.Log($"Player healed for {amount}. Current health = {currentHealth}");
    }
}