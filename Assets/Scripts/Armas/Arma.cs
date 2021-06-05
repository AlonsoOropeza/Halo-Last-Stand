using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    [SerializeField] public int id;
    [SerializeField] public string nombre;
    [SerializeField] public float daño;
    [SerializeField] public float range;
    [SerializeField] public float cadencia;
    [SerializeField] public float impacto;
    [SerializeField] public float municion;
    [SerializeField] public float cargador;
    [SerializeField] public AudioClip shoot;
    [SerializeField] public AudioClip reload;
    [SerializeField] public AudioClip bash;
    [SerializeField] public bool rafagas;
    AudioSource audioSource;

    public float balasRecamara;
    public Camera FPSCamara;
    private Animator anim;
    private bool disparando;

    [SerializeField]
    private GameObject flama;
    
    private ParticleSystem flash;

    private float nextTimeToFire = 0f;
    private float lastRecharge = 0f; 
    private bool golpe = false;
    private float ultimoGolpe = 0f;

    void Start() {
        anim = gameObject.GetComponent<Animator>();
        balasRecamara = cargador;
        audioSource = gameObject.GetComponent<AudioSource>();
        
        if(flama != null)
        {
            flash = flama.GetComponent<ParticleSystem>();
        }
            
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && Time.time >= lastRecharge) {
            nextTimeToFire = Time.time + 2f / cadencia;
            Shoot();
            disparando = true;
        } else {
            disparando = false;
        }

        if (disparando) {
            if (flash != null) {
                //flash.Play();
            }
        }

        if (anim != null) {
            if ((Input.GetKeyDown(KeyCode.R) && Time.time >= lastRecharge && municion > 0) || (balasRecamara == 0f && Time.time >= nextTimeToFire && municion > 0)) {               
                lastRecharge = Time.time + 1;
                anim.Play("Recharge");
                audioSource.PlayOneShot(reload);

                float dif = cargador - balasRecamara;

                if(cargador > municion) {
                    balasRecamara = balasRecamara + municion;
                    municion = 0;    
                } else {
                    municion = municion - dif;
                    balasRecamara = balasRecamara + dif;
                }
            }
        }
        if(anim != null) {
            if (Input.GetKeyDown(KeyCode.F) && Time.time >= ultimoGolpe) {
                ultimoGolpe = Time.time + 0.5f;
                anim.Play("Bash");
                audioSource.PlayOneShot(bash);
            }
            if (ultimoGolpe > Time.time) {
                golpe = true;
            } else {
                golpe = false;
            }
        }

        HUD.Instancia.nombre_arma(nombre);
        HUD.Instancia.municion_arma(balasRecamara, municion);
    }

    void Shoot() {
        RaycastHit hit; 
        if (Physics.Raycast(FPSCamara.transform.position, FPSCamara.transform.forward, out hit, range) & balasRecamara > 0) {
            if (anim != null) {
                anim.Play("Shot");
            }
            flash.Play();
            audioSource.PlayOneShot(shoot);
            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(daño);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impacto);
            }
            if (rafagas)
                balasRecamara -= 3;
            else
                balasRecamara--;
        }
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Enemigo" && golpe) {
            Destroy(other.gameObject);
        }
    }
}
