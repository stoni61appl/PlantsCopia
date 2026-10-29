using UnityEngine;

// Este script va en cada celda del grid (un objeto con SpriteRenderer + BoxCollider2D)
public class GridCell : MonoBehaviour
{
    public int fila; // Usar inglés; Usar PascalCase
    public int columna; // Usar inglés; Usar PascalCase
    public bool ocupada = false; // Revisar: usar un verbo de estado (is, has o can); Usar inglés; Usar PascalCase

    private GridManagerPlants gridManager; // Usar _camelCase

    void Start()
    {
        gridManager = FindObjectOfType<GridManagerPlants>(); // Revisar la inyección de dependencias
    }

    // Se llama automáticamente cuando el jugador hace clic sobre el collider de esta celda
    void OnMouseDown()
    {
        if (ocupada)
        {
            Debug.Log($"Celda ({fila},{columna}) ya está ocupada");
            return;
        }

        gridManager.ColocarPlanta(this);
    }

    public void MarcarOcupada() // Usar inglés
    {
        ocupada = true;
    }
}
