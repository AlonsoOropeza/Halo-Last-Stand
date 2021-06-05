using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyGrenade : MonoBehaviour
{
    [SerializeField] GameObject player;
    bool onTrigger;
    [SerializeField] public int precio;
    ThrowGrenade grenade;
    AudioSource audioSource;
    [SerializeField] public AudioClip repairing;
    // Start is called before the first frame update
    void Start()
    {
        grenade = player.GetComponent<ThrowGrenade>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger )
        {
            if (HUD.Instancia.get_puntos() >= precio && grenade.capacidad < 4)
            {
                audioSource.PlayOneShot(repairing);
                grenade.capacidad++;
                HUD.Instancia.puntos_arma(precio);
                HUD.Instancia.granadas(grenade.capacidad);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HUD.Instancia.mostrar_comprar_arma("granada", precio);
            onTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HUD.Instancia.esconder_comprar_arma();
            onTrigger = false;
        }
    }
}
