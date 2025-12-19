using UnityEngine;

public class WetState : MonoBehaviour, ISinkable
{
    public bool IsWet = false;

    public void BecomeWet()
    {
        if (IsWet) return;

        IsWet = true;
        Debug.Log($"{name} is now wet!");

        Renderer r = GetComponent<Renderer>();
        if (r != null)
            r.material.color = Color.blue;
    }
}
