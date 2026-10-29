using UnityEngine;

public class Pea : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 8f; // Usar PascalCase

    [Header("Daño")]
    public int damage = 20; // Usar PascalCase

    [Header("Limpieza")]
    [Tooltip("Tiempo máximo de vida antes de autodestruirse si no golpea nada")]
    public float lifeTime = 5f; // Usar PascalCase

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Zombie"))
        {
            other.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
    }
}
