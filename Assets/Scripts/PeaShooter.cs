// Sugerencia general de Clean Code: usar if de una sola línea con llaves cuando sea legible.

using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject peaPrefab; // Usar PascalCase
    public Transform firePoint; // Usar PascalCase
    public float fireRate = 1.5f; // Revisar: usar un nombre descriptivo; Usar PascalCase

    [Header("Detección")]
    public bool requireZombieInLane = true; // Usar PascalCase
    public float detectionRadius = 6f; // Usar PascalCase
    public LayerMask zombieLayer; // Usar PascalCase

    [Header("Vida")]
    public int vidaMaxima = 100; // Usar inglés; Usar PascalCase

    private int vidaActual; // Usar inglés; Usar _camelCase
    private float timer; // Usar _camelCase

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            if (!requireZombieInLane || HayZombieEnfrente())
            {
                Disparar();
                timer = 0f;
            }
        }
    }

    bool HayZombieEnfrente() // Usar inglés
    {
        Vector2 origen = firePoint != null // Usar inglés
            ? firePoint.position
            : transform.position;

        RaycastHit2D hit = Physics2D.Raycast(
            origen,
            Vector2.right,
            detectionRadius,
            zombieLayer
        );

        return hit.collider != null;
    }

    void Disparar() // Usar inglés
    {
        if (peaPrefab == null) // Agregar llaves al if
            return;

        Vector3 posicion = firePoint != null // Usar inglés
            ? firePoint.position
            : transform.position;

        Instantiate(peaPrefab, posicion, Quaternion.identity);
    }

    public void RecibirDanio(int cantidad) // Respetar el orden de acceso y static; Usar inglés
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}