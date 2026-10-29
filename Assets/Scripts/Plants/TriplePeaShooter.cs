using UnityEngine;

/// <summary>
/// Tripitidora: dispara tres guisantes en paralelo (arriba, centro, abajo).
/// </summary>
public class TriplePeaShooter : MonoBehaviour
{
    [Header("Configuración de disparo")]
    public GameObject peaPrefab; // Usar PascalCase
    public Transform firePoint; // Usar PascalCase
    public float fireRate = 1.5f; // Revisar: usar un nombre descriptivo; Usar PascalCase

    [Header("Offsets verticales")]
    public float verticalOffset = 5f; // separación entre los guisantes // Usar PascalCase; Revisar si este código es necesario

    [Header("Ángulo de apertura")]
    public float angleSpread = 15f; // grados de separación // Usar PascalCase

    private float timer; // Usar _camelCase

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Disparar();
            timer = 0f;
        }
    }

    private void Disparar() // Usar inglés
    {
        Vector3 spawnPos = firePoint != null ? firePoint.position : transform.position; // Sin abreviaciones

        // Centro (recto)
        GameObject peaCenter = Instantiate(peaPrefab, spawnPos, Quaternion.identity);
        peaCenter.GetComponent<PeaAdvance>().SetDirection(Vector2.right);

        // Arriba (ángulo positivo)
        GameObject peaUp = Instantiate(peaPrefab, spawnPos, Quaternion.identity);
        peaUp.GetComponent<PeaAdvance>().SetDirection(Quaternion.Euler(0, 0, angleSpread) * Vector2.right);

        // Abajo (ángulo negativo)
        GameObject peaDown = Instantiate(peaPrefab, spawnPos, Quaternion.identity);
        peaDown.GetComponent<PeaAdvance>().SetDirection(Quaternion.Euler(0, 0, -angleSpread) * Vector2.right);
    }
}
