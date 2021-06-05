using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    [SerializeField] GameObject grenade;
    [SerializeField] Transform spawnpoint;
    [SerializeField] public int capacidad = 4;
    float range = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Launch();
            HUD.Instancia.granadas(capacidad);
        }
    }

    private void Launch()
    {
        if(capacidad > 0) {
            GameObject grenadeInstance = Instantiate(grenade, spawnpoint.position, Quaternion.Euler(8,90,-8));
            grenadeInstance.GetComponent<Rigidbody>().AddForce(spawnpoint.forward * range, ForceMode.Impulse);
            capacidad--;
        }
    }
}
