// Sugerencia general de Clean Code: usar if de una sola línea con llaves cuando sea legible.

using UnityEngine;

public class PeaAdvance : MonoBehaviour
{
    public float speed = 8f; // Usar PascalCase
    public int damage = 20; // Usar PascalCase
    public float lifeTime = 5f; // Usar PascalCase

    private Vector2 direction = Vector2.right; // Usar _camelCase
    private Vector2 finalDirection = Vector2.right; // Usar _camelCase

    [Header("Corrección de dirección")]
    public float straightenTime = 0.5f;  // Respetar el orden de acceso y static; Usar PascalCase
    private float timer; // Separar los grupos de acceso con una línea en blanco; Usar _camelCase


    public void SetDirection(Vector2 dir) // Sin abreviaciones
    {
        direction = dir.normalized;
    }

    private void Start() // Respetar el orden de los miembros
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update() // Respetar el orden de los miembros
    {
        timer += Time.deltaTime;

        
        if (timer < straightenTime)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            
            transform.Translate(finalDirection * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) // Respetar el orden de los miembros
    {
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
