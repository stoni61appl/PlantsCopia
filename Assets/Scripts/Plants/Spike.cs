// Sugerencia general de Clean Code: usar if de una sola línea con llaves cuando sea legible.

using UnityEngine;

public class Spike : MonoBehaviour
{
    [Header("Atributos del proyectil")]
    public float velocidad = 5f; // Usar inglés; Usar PascalCase
    public int danio = 20; // Usar inglés; Usar PascalCase
    public int maxEnemigos = 3; // Usar inglés; Usar PascalCase
    public float tiempoVida = 5f; // Usar inglés; Usar PascalCase

    private int enemigosAtraviesados = 0; // Usar inglés; Usar _camelCase

    void Start()
    {
        // Autodestrucción por tiempo
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        // Movimiento constante hacia la derecha
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Zombie z = other.GetComponent<Zombie>(); // Usar un nombre descriptivo; Revisar si este código es necesario
        if (other.CompareTag("Zombie"))
        {
            other.SendMessage("TakeDamage", danio, SendMessageOptions.DontRequireReceiver);

            enemigosAtraviesados++;

            if (enemigosAtraviesados >= maxEnemigos)
            {
                Destroy(gameObject);
            }

        }
    }
}
