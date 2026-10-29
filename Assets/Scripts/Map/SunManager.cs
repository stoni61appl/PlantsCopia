using UnityEngine;

public class SunManager : MonoBehaviour
{
    public static SunManager instance; // Usar PascalCase

    [Header("Soles iniciales")]
    public int currentSun = 50; // Usar PascalCase

    private void Awake()
    {
        instance = this;
    }

    public void AddSun(int amount)
    {
        currentSun += amount;

        Debug.Log("Soles actuales: " + currentSun);
    }

    public bool SpendSun(int amount)
    {
        if (currentSun >= amount)
        {
            currentSun -= amount;

            Debug.Log("Soles actuales: " + currentSun);

            return true;
        }

        Debug.Log("No tienes suficientes soles.");

        return false;
    }
}