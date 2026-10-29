
using UnityEngine;

public class ZombiePrueba : MonoBehaviour
{
    [Header("Vida")]
    public int vida = 10; // Usar inglés; Usar PascalCase

    [Header("Movimiento")]
    public float velocidad = 0.5f; // Usar inglés; Usar PascalCase

    [Header("Ataque")]
    public Transform puntoAtaque;          // hijo vacío del zombie, al frente (izquierda) // Usar inglés; Usar PascalCase
    public float radioAtaque = 0.3f; // Usar inglés; Usar PascalCase
    public string tagPlant = "Planta"; // Usar PascalCase
    public int damage = 20; // Usar PascalCase
    public float tiempoEntreAtaques = 1f; // Usar inglés; Usar PascalCase

    private float temporizadorAtaque; // Usar inglés; Usar _camelCase
    private PlantHealth plantaObjetivo; // Usar inglés; Usar _camelCase

    void Update()
    {
        DetectarPlanta();

        if (plantaObjetivo != null)
        {
            // Atacando: se detiene
            temporizadorAtaque -= Time.deltaTime;
            if (temporizadorAtaque <= 0f)
            {
                plantaObjetivo.RecibirDanio(damage);
                temporizadorAtaque = tiempoEntreAtaques;
            }
        }
        else
        {
            // Avanza hacia la izquierda
            transform.Translate(Vector2.left * velocidad * Time.deltaTime);
        }
    }

    void DetectarPlanta() // Usar inglés
    {
        plantaObjetivo = null;
        Collider2D[] hits = Physics2D.OverlapCircleAll(puntoAtaque.position, radioAtaque);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(tagPlant))
            {
                plantaObjetivo = hit.GetComponent<PlantHealth>();
                break;
            }
        }
    }

    public void TakeDamage(int cantidad) // Respetar el orden de acceso y static; Usar inglés
    {
        vida -= cantidad;
        Debug.Log("Zombie prueba recibió daño, vida: " + vida);
        if (vida <= 0) Destroy(gameObject); // Agregar llaves al if
    }

    // Para ver el rango en la escena
    void OnDrawGizmosSelected()
    {
        if (puntoAtaque == null) return; // Agregar llaves al if
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(puntoAtaque.position, radioAtaque);
    }
}