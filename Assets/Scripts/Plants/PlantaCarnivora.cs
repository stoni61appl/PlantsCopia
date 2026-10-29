// Sugerencia general de Clean Code: usar if de una sola línea con llaves cuando sea legible.

using UnityEngine;

public class PlantaCarnivora : MonoBehaviour
{
    [Header("Atributos")]
    public int danio = 999;           // Daño alto (mata de un bocado) // Usar inglés; Usar PascalCase
    public float rango = 1f;          // Distancia de detección // Usar inglés; Usar PascalCase
    public float tiempoRecarga = 10f; // Tiempo de espera tras comer // Usar inglés; Usar PascalCase

    private bool enRecarga = false; // Revisar: usar un verbo de estado (is, has o can); Usar inglés; Usar _camelCase
    private float temporizador = 0f; // Usar inglés; Usar _camelCase

    void Update()
    {
        if (enRecarga)
        {
            temporizador -= Time.deltaTime;
            if (temporizador <= 0f)
            {
                enRecarga = false;
            }
            return;
        }

        GameObject objetivo = BuscarZombie(); // Usar inglés
        if (objetivo != null)
        {
            ComerZombie(objetivo);
        }
    }

    GameObject BuscarZombie() // Usar inglés
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, rango);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Zombie"))
            {
                return hit.gameObject;
            }
        }
        return null;
    }

    void ComerZombie(GameObject zombie) // Usar inglés
    {
        zombie.SendMessage("TakeDamage", danio, SendMessageOptions.DontRequireReceiver);

        enRecarga = true;
        temporizador = tiempoRecarga;

        Debug.Log("La planta carnívora se comió un zombie!");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, rango);
    }
}