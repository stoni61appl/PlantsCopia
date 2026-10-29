// Sugerencia general de Clean Code: usar if de una sola línea con llaves cuando sea legible.

using UnityEngine;

public class PlantHealth : MonoBehaviour
{
    [Header("Vida")]
    public int vidaMaxima = 300; // Usar inglés; Usar PascalCase

    private int vidaActual; // Usar inglés; Usar _camelCase

    private void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidad) // Usar inglés
    {
        vidaActual -= cantidad;

        Debug.Log(gameObject.name + " recibió " + cantidad + " de daño. Vida: " + vidaActual);

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    private void Morir() // Usar inglés
    {
        Destroy(gameObject);
    }
}