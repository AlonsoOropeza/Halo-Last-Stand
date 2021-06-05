using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Barricada : MonoBehaviour
{

    [SerializeField] public float barricada_salud;
    [SerializeField] public int barricada_puntos_reconstruir;

    private Renderer render;
    private MeshCollider meshcollider;
    private BoxCollider boxcollider;
    [SerializeField] public AudioClip broken;
    [SerializeField] public AudioClip repairing;
    [SerializeField] public AudioClip breaking;
    AudioSource audioSource;
    ParticleSystem particle;

    bool onTrigger;

    void Start()
    {
        render = this.gameObject.GetComponent<MeshRenderer>();
        meshcollider = this.gameObject.GetComponent<MeshCollider>();
        boxcollider = this.gameObject.GetComponent<BoxCollider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        particle = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            HUD.Instancia.esconder_construir_barricada();
            construir();
        }
    }

    private void destruir() {
        barricada_salud -= 20;
        audioSource.PlayOneShot(breaking);
        onTrigger = false;
        if (barricada_salud <= 0) {
            audioSource.PlayOneShot(broken);
            particle.Play();
            barricada_salud = 0;
            if(render != null) {
                render.enabled = false;
            }
            if(meshcollider != null) {
                meshcollider.enabled = false;
            }
            if(boxcollider != null) {
                boxcollider.enabled = true;
            }
        }
    }
    
    private void construir() {
        audioSource.PlayOneShot(repairing);
        HUD.Instancia.puntos_barricadas(barricada_puntos_reconstruir);
        barricada_salud = 100;
        if(render != null) {
            render.enabled = true;
        }
        if(meshcollider != null) {
            meshcollider.enabled = true;
        }
        if(boxcollider != null) {
            boxcollider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Enemigo") {
            destruir();
        }
    }    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            onTrigger = true;
            HUD.Instancia.mostrar_construir_barricada(barricada_puntos_reconstruir);
        }
    }   

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Player") {
            HUD.Instancia.esconder_construir_barricada();
            onTrigger = false;
        }
    }  
}
