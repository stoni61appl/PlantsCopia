using UnityEngine;

/// <summary>
/// Lanzaguisantes estilo Plants vs Zombies.
/// Puede disparar 1 a N guisantes, separados en posici�n.
/// </summary>
public class PeaShooterAdvance : MonoBehaviour
{
    [Header("Configuraci�n de disparo")]
    [Tooltip("Prefab del guisante que se va a instanciar")]
    public GameObject peaPrefab; // Usar PascalCase

    [Tooltip("Punto desde donde sale el guisante (hijo vac�o delante de la planta)")]
    public Transform firePoint; // Usar PascalCase

    [Tooltip("Tiempo entre disparos, en segundos")]
    public float fireRate = 1.5f; // Revisar: usar un nombre descriptivo; Usar PascalCase

    [Tooltip("N�mero de guisantes por disparo (1-4)")]
    [Range(1, 4)]
    public int peasPerShot = 1; // Usar PascalCase

    [Tooltip("Separaci�n horizontal entre cada guisante")]
    public float peaSpacing = 0.3f; // Usar PascalCase

    [Header("Detecci�n de zombies (opcional)")]
    [Tooltip("Si est� activo, solo dispara cuando hay un zombie en el carril")]
    public bool requireZombieInLane = true; // Usar PascalCase

    [Tooltip("Radio del �rea que revisa si hay zombies enfrente")]
    public float detectionRadius = 6f; // Usar PascalCase

    [Tooltip("Capa donde est�n los zombies")]
    public LayerMask zombieLayer; // Usar PascalCase; Revisar si este código es necesario

    //[Header("Vida")]
    //public int vidaMaxima = 100;
    //private int vidaActual;

    private float timer; // Usar _camelCase

    private void Update()
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

    private bool HayZombieEnfrente() // Usar inglés
    {
        Vector2 origen = firePoint != null ? firePoint.position : transform.position; // Usar inglés
        RaycastHit2D[] hits = Physics2D.RaycastAll(origen, Vector2.right, detectionRadius);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.CompareTag("Zombie")) // Agregar llaves al if
                return true;
        }
        return false;
    }

    private void Disparar() // Usar inglés
    {
        if (peaPrefab == null)
        {
            Debug.LogWarning("PeaShooter: falta asignar el prefab del guisante.");
            return;
        }

        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position; // Sin abreviaciones

        // Instancia varios guisantes con separaci�n
        for (int i = 0; i < peasPerShot; i++)
        {
            Vector3 offset = new Vector3(i * peaSpacing, 0f, 0f);
            Instantiate(peaPrefab, spawnPos + offset, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 origen = firePoint != null ? firePoint.position : transform.position; // Usar inglés
        Gizmos.color = Color.green;
        Gizmos.DrawLine(origen, origen + Vector2.right * detectionRadius);
    }

    private void Morir() // Usar inglés; Respetar el orden de los miembros; Revisar si este código es necesario
    {
        Destroy(gameObject);
    }
}

