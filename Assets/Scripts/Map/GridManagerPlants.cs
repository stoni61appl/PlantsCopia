using UnityEngine;

public class GridManagerPlants : MonoBehaviour
{
    [Header("Tamaño del grid (clásico PvZ)")]
    public int filas = 5; // Usar inglés; Usar PascalCase
    public int columnas = 9; // Usar inglés; Usar PascalCase

    [Header("Tamaño y posición")]
    public float tamañoCelda = 1f; // Usar inglés; Usar PascalCase
    public Vector2 origen = new Vector2(-4f, 2f); // esquina superior-izquierda del césped // Usar inglés; Usar PascalCase

    [Header("Prefabs")]
    public GameObject prefabCelda;       // objeto vacío con SpriteRenderer (opcional) + BoxCollider2D // Usar inglés; Usar PascalCase
    public GameObject prefabLanzaGuisantes; // Usar inglés; Usar PascalCase

    private GridCell[,] celdas; // Usar inglés; Usar _camelCase

    void Start()
    {
        GenerarGrid();
    }

    void GenerarGrid() // Usar inglés
    {
        celdas = new GridCell[filas, columnas];

        for (int f = 0; f < filas; f++)
        {
            for (int c = 0; c < columnas; c++)
            {
                Vector2 pos = origen + new Vector2(c * tamañoCelda, -f * tamañoCelda); // Sin abreviaciones

                GameObject celdaObj = Instantiate(prefabCelda, pos, Quaternion.identity, transform); // Sin abreviaciones; Usar inglés
                celdaObj.name = $"Celda_{f}_{c}";

                GridCell celda = celdaObj.GetComponent<GridCell>(); // Usar inglés
                celda.fila = f;
                celda.columna = c;

                celdas[f, c] = celda;
            }
        }
    }

    // Llamado desde GridCell cuando el jugador hace clic en una celda libre
    public void ColocarPlanta(GridCell celda) // Respetar el orden de acceso y static; Usar inglés
    {
        Vector3 posPlanta = celda.transform.position; // Sin abreviaciones; Usar inglés
        Instantiate(prefabLanzaGuisantes, posPlanta, Quaternion.identity);

        celda.MarcarOcupada();
        Debug.Log($"Lanzaguisantes colocado en ({celda.fila},{celda.columna})");
    }
}
