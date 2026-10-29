// Sugerencia general de Clean Code: usar if de una sola línea con llaves cuando sea legible.

using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float velocidad = 1f; // Usar inglés; Usar PascalCase
    public int vidaMaxima = 100; // Usar inglés; Usar PascalCase
    public int danio = 20; // Usar inglés; Usar PascalCase
    public float distanciaAtaque = 0.8f; // Usar inglés; Usar PascalCase

    private int vidaActual; // Usar inglés; Usar _camelCase
    private Animator animator; // Usar _camelCase
    private GameObject plantaObjetivo; // Usar inglés; Usar _camelCase

    void Start()
    {
        vidaActual = vidaMaxima;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        BuscarPlanta();

        if (plantaObjetivo == null)
        {
            transform.position += Vector3.left * velocidad * Time.deltaTime;

            animator.SetBool("Walk", true);
            animator.SetBool("Attack", false);
        }
        else
        {
            animator.SetBool("Walk", false);
            animator.SetBool("Attack", true);
        }
    }

    void BuscarPlanta()
    {
        RaycastHit2D hit = Physics2D.Raycast(
            transform.position,
            Vector2.left,
            distanciaAtaque
        );

        if (hit.collider != null && hit.collider.CompareTag("Plant"))
        {
            plantaObjetivo = hit.collider.gameObject;
        }
        else
        {
            plantaObjetivo = null;
        }
    }

    public void attack() // Respetar el orden de acceso y static; Usar PascalCase
    {
        if (plantaObjetivo != null)
        {
            plantaObjetivo.SendMessage(
                "RecibirDanio",
                danio,
                SendMessageOptions.DontRequireReceiver
            );
        }
    }

    public void TakeDamage(int cantidad) // Usar inglés
    {
        vidaActual -= cantidad;

        if (vidaActual <= 0)
        {
            Destroy(gameObject);
        }
    }
}