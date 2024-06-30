using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    [SerializeField] private float delayDestroy = 0.2f;
    private bool tienePaquete; // por defecto está en false
    [SerializeField] Color32 tienePaqueteColor = new Color32(255, 140, 0, 255);
    [SerializeField] Color32 noTienePaqueteColor = new Color32(255, 255, 255, 255); // Blanco (color normal)
    private SpriteRenderer spriteRenderer;
    private puntaje puntajeScript; // Referencia al script de puntaje

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        puntajeScript = FindObjectOfType<puntaje>(); // Buscar el script de puntaje en la escena
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fruit" && !tienePaquete)
        {
            Debug.Log("Recogio fruta");
            tienePaquete = true;
            spriteRenderer.color = tienePaqueteColor;
            Destroy(other.gameObject, delayDestroy);
        }

        if (other.tag == "House" && tienePaquete)
        {
            tienePaquete = false;
            spriteRenderer.color = noTienePaqueteColor;
            Debug.Log("Dejo fruta");
            puntajeScript.IncreaseScore(1); // Incrementar el puntaje al dejar una fruta
        }
    }
}
