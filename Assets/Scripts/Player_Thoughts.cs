using TMPro;
using UnityEngine;

public class PlayerThoughts : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI thoughtsText;
    [SerializeField] private float displayTime = 2.5f;

    private float timer;

    void OnEnable()
    {
        ThoughtEvents.OnThought += ShowThought;
    }

    void OnDisable()
    {
        ThoughtEvents.OnThought -= ShowThought;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
                thoughtsText.text = "";
        }
    }

    void ShowThought(string thought)
    {
        thoughtsText.text = thought;
        timer = displayTime;
    }
}
