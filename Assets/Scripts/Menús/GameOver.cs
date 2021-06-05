using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TMP_Text texto_bajas;
    [SerializeField] private TMP_Text texto_puntos;
    public static GameOver Instancia;

    void Start() {
        Invoke("Derrota", 3.0f);
        mostrar_bajas(HUD.Instancia.get_bajas());
        mostrar_puntos(HUD.Instancia.get_puntos());
    }

    public void Derrota() {
        SceneManager.UnloadSceneAsync("MenuGameOver");
    }

    private void Awake() {
        if(Instancia == null) {
            Instancia = this;
        }
    }

    public void mostrar_bajas(int bajas) {
        texto_bajas.text = $"{bajas}";
    }

    public void mostrar_puntos(int puntos) {
        texto_puntos.text = $"{puntos}";
    }
}
