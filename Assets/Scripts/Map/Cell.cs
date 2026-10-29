// Sugerencia general de Clean Code: usar if de una sola línea con llaves cuando sea legible.

using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool occupied = false; // Revisar: usar un verbo de estado (is, has o can); Usar PascalCase
    public GameObject currentPlant; // Usar PascalCase

    void OnMouseDown()
    {
        if (!occupied)
        {
            PlantManager.Instance.PlantHere(this);
        }
    }
}

