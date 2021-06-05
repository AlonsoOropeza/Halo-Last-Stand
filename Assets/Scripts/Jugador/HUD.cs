using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System;

public class HUD : Singleton<HUD>
{
    [SerializeField] private TMP_Text texto_numero_bajas;
    [SerializeField] private TMP_Text texto_puntos_actuales;
    [SerializeField] private TMP_Text texto_puntos_movidos;
    [SerializeField] private TMP_Text texto_salud;
    [SerializeField] private TMP_Text texto_municion;
    [SerializeField] private TMP_Text texto_nombre_arma;
    [SerializeField] private TMP_Text texto_granadas;
    [SerializeField] private TMP_Text texto_abrir_puerta;
    [SerializeField] private TMP_Text texto_construir_barricada;
    [SerializeField] private TMP_Text texto_comprar_arma;
    [SerializeField] private TMP_Text texto_comprar_caja;

    public static HUD Instancia;
    public float delayPuntos;

    [SerializeField] public int puntos;
    [SerializeField] public int salud;
    [SerializeField] public int bajas;

    void Start()
    {
        mostrar_bajas();
    }

    void Update()
    {
    }

    private void Awake() {
        if(Instancia == null) {
            Instancia = this;
        }
    }

    // Manejo de salud
    private IEnumerator regenerar_salud() {
        yield return new WaitForSeconds(5f);
        salud = 100;
        salud_actual();
    }
    
    public void salud_actual() {
        texto_salud.text = $"{salud}";
    }

    public void perder_salud() {
        salud = salud - 50;
        if(salud <= 0) {
            SceneManager.LoadScene("MenuPrincipal");
            SceneManager.LoadScene("MenuGameOver", LoadSceneMode.Additive);
        }
        salud_actual();
        StartCoroutine(regenerar_salud());
    }

    // Puntos de puertas
    public void mostrar_abrir_puerta(int valor_puerta) {
        texto_abrir_puerta.text = $"Pulsa 'E' para abrir la puerta ({valor_puerta} puntos)";
    }
    public void esconder_abrir_puerta() {
        texto_abrir_puerta.text = "";
    }

    // Puntos de barreras
    public void mostrar_construir_barricada(int valor_barricada) {
        texto_construir_barricada.text = "Pulsa 'E' para reconstruir la barrera";
    }
    public void esconder_construir_barricada() {
        texto_construir_barricada.text = "";
    }

    // Puntos de armas
    public void mostrar_comprar_arma(String nombre_arma, float valor_arma) {
        texto_comprar_arma.text = $"Pulsa 'E' para comprar {nombre_arma} ({valor_arma} puntos)";
    }
    public void esconder_comprar_arma() {
        texto_comprar_arma.text = "";
    }

    // Detalles del arma
    public void nombre_arma(string nombre) {
        texto_nombre_arma.text = $"{nombre}";
    }
    public void municion_arma(float cargador, float municion) {
        texto_municion.text = $"{cargador}/{municion}";
    }

    // Obtención de puntos
    public int get_puntos() {
        return puntos;
    }
    public void puntos_actuales() {
        texto_puntos_actuales.text = $"{puntos}";
    }

    /// Manejo de puntos
    public void puntos_barricadas(int valor_barricada) {
        puntos = puntos + valor_barricada;
        StartCoroutine(moverPuntos(valor_barricada));
    }
    public void puntos_puertas(int valor_puerta) {
        puntos = puntos + valor_puerta;
        StartCoroutine(moverPuntos(valor_puerta));
    }
    public void puntos_impacto(int valor_impacto) {
        puntos = puntos + valor_impacto;
        StartCoroutine(moverPuntos(valor_impacto));
    }
    public void puntos_asesinato(int valor_asesinato) {
        puntos = puntos + valor_asesinato;
        StartCoroutine(moverPuntos(valor_asesinato));
    }
    public void puntos_arma(int valor_arma) {
        puntos = puntos + valor_arma;
        StartCoroutine(moverPuntos(valor_arma));
    }

    public IEnumerator moverPuntos(int valor) {
        puntos_actuales();
        if(valor < 0) {
            texto_puntos_movidos.color = new Color(255,0,0);
            texto_puntos_movidos.text = $"{valor}";
        } else {
            texto_puntos_movidos.color = new Color(255,246,0);
            texto_puntos_movidos.text = $"+{valor}";
        }
		yield return new WaitForSeconds(1f);
        texto_puntos_movidos.text = "";
	}

    public void granadas(int capacidad) {   
        texto_granadas.text = $"{capacidad}xG";
    }

    public void agregar_baja() {
        bajas++;
    }
    public int get_bajas() {
        return bajas;
    }
    public void mostrar_bajas() {
        texto_numero_bajas.text = $"{bajas}";
    }
}
