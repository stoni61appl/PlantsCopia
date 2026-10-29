using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float velocidad = 1f; // Usar inglés; Usar PascalCase

    void Update()
    {
        transform.Translate(Vector2.left * velocidad * Time.deltaTime);
    }
}