using UnityEngine;

public class TungTungSpawner : MonoBehaviour
{
    public GameObject tungTungPrefab; // Usar PascalCase
    public Transform[] puntosSpawn; // Usar inglés; Usar PascalCase

    public float tiempoMin = 3f; // Usar inglés; Usar PascalCase
    public float tiempoMax = 7f; // Usar inglés; Usar PascalCase

    void Start()
    {
        ProgramarSpawn();
    }

    void ProgramarSpawn() // Usar inglés
    {
        float tiempo = Random.Range(tiempoMin, tiempoMax); // Usar inglés
        Invoke("SpawnTungTung", tiempo);
    }

    void SpawnTungTung()
    {
        int fila = Random.Range(0, puntosSpawn.Length); // Usar inglés

        Instantiate(
            tungTungPrefab,
            puntosSpawn[fila].position,
            Quaternion.identity
        );

        ProgramarSpawn();
    }
}