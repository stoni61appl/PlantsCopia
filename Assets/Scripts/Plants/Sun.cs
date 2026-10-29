using UnityEngine;

public class Sun : MonoBehaviour
{
    public int sunValue = 25; // Usar PascalCase

    private void OnMouseEnter()
    {
        Debug.Log("CLIC EN EL SOL");

        SunManager.instance.AddSun(sunValue);

        Destroy(gameObject);
    }
}