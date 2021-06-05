using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{

    [SerializeField] private int puerta_puntos_compra;

    private Renderer render;
    private MeshCollider meshcollider;
    private BoxCollider boxcollider;
    AudioSource audioSource;
    [SerializeField] public AudioClip repairing;

    bool onTrigger;

    void Start()
    {
        render = this.gameObject.GetComponent<MeshRenderer>();
        meshcollider = this.gameObject.GetComponent<MeshCollider>();
        boxcollider = this.gameObject.GetComponent<BoxCollider>();
        // Debug.Log(puntos);
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            int temp = HUD.Instancia.get_puntos();
            if (Mathf.Abs(temp) >= Mathf.Abs(puerta_puntos_compra))
            {
                HUD.Instancia.esconder_abrir_puerta();
                comprarPuerta();
                onTrigger = false;
            }
        }
    }

    private void comprarPuerta() {
        audioSource.PlayOneShot(repairing);
        HUD.Instancia.puntos_puertas(puerta_puntos_compra);
        onTrigger = false;
        if (render != null) {
            render.enabled = false;
        }
        if(meshcollider != null) {
            meshcollider.enabled = false;
        }
        if(boxcollider != null) {
            boxcollider.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            onTrigger = true;
            HUD.Instancia.mostrar_abrir_puerta(puerta_puntos_compra);
        }
    } 
    

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            onTrigger = false;
            HUD.Instancia.esconder_abrir_puerta();
        }
    }  
}

