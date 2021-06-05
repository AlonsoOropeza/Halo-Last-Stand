using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyWeapon : MonoBehaviour
{
    [SerializeField] public int precio;
    [SerializeField] GameObject arma;
    [SerializeField] GameObject WeaponHolder;
    Arma armaScript;
    bool onTrigger;
    AudioSource audioSource;
    [SerializeField] public AudioClip repairing;
    void Start()
    {
        armaScript = arma.GetComponent<Arma>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && onTrigger)
        {
            int temp = HUD.Instancia.get_puntos();
            if (Mathf.Abs(temp) >= Mathf.Abs(precio))
            {
                audioSource.PlayOneShot(repairing);
                WeaponHolder.GetComponent<WeaponSwitching>().SelectWeapon(armaScript.id);
                HUD.Instancia.puntos_arma(precio);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            HUD.Instancia.mostrar_comprar_arma(armaScript.nombre, precio);
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
