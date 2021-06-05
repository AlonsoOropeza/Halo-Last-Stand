using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float salud = 50f;

    [SerializeField]
    public GameObject targetImpactEffect;

    public void TakeDamage(float amount) {
        salud -= amount;
        if (salud <= 0f) {
            Die();
        }
    }

    public void Die() {   
        HUD.Instancia.puntos_asesinato(100);
        HUD.Instancia.agregar_baja();
        HUD.Instancia.mostrar_bajas();
        Destroy(gameObject);
    }
}
