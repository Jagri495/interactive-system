using UnityEngine;

public class ObjectConsumable : MonoBehaviour, IInteractable
{
    public enum ConsumableType
    {
        Heal,
        Cup
    }

    [Header("Consumable Settings")]
    public ConsumableType type = ConsumableType.Heal;
    public bool requiresWet = false;
    public bool destroyOnUse = true;

    [Header("Values")]
    public int healAmount = 20;
    public int energyAmount = 10;

    [Header("Wet State Reference (optional)")]
    public WetState wetState;

    
    private void Awake()
    {
        wetState = GetComponent<WetState>();
    }
    
    public void Interact()
    {
        // 1. Check wet requirement
        if (requiresWet && !wetState.IsWet)
        {
            Debug.Log($"{name} cannot be used unless wet!");
            return;
        }

        // 2. Get player health component
        Player_HeadHealth playerHealth = FindFirstObjectByType<Player_HeadHealth>();
        if (playerHealth == null)
        {
            Debug.LogWarning("Player_HeadHealth not found!");
            return;
        }

        if (requiresWet)
        {
            GetComponent<Renderer>().material.color = Color.gray;
        }

        // 3. Apply effect
        switch (type)
        {
            case ConsumableType.Heal:
                playerHealth.Heal(healAmount);
                break;

            case ConsumableType.Cup:
                playerHealth.Heal(healAmount);
                wetState.IsWet = false;
                break;
        }

        // 4. Optionally destroy after use
        if (destroyOnUse)
            Destroy(gameObject);
    }
}