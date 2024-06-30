using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEjemplo : MonoBehaviour
{
    [SerializeField] private float delayDestroy = 0.5f;
    private bool tienePaquete; //por dejecto está en false
    [SerializeField] Color32 tienePaqueteColor = new Color32(255,0,0,25);
    [SerializeField] Color32 noTienePaqueteColor = new Color32(0, 255, 255, 255);
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Ouch");
    }
/*
    void OnTriggerEnter2D(Collider2D other){
            Debug.Log("Entrando En trigger");
    }
*/
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando en trigger! " );
        if (other.tag == "Paquete" && !tienePaquete) 
        {
            Debug.Log("Recogio paquete");
            tienePaquete = true; 
            spriteRenderer.color = tienePaqueteColor;
            Destroy(other.gameObject, delayDestroy) ;
            
            
        }

        if (other.tag == "Cliente" && tienePaquete)
        {   
            tienePaquete = false; 
            spriteRenderer.color = noTienePaqueteColor;
            Debug.Log("Dejo paquete");
        }
    }
}