using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinijuegoScript : MonoBehaviour
{
    public GameObject cuboCorrecto;
    public GameObject siguienteParte;
    public int puntos;
    public Button closeButton;

    public GameObject descriptionPanel;

    public GameObject panelVictoria;
    public AudioSource instrucciones;

    public Button jugar;

    public Button mensaje;

    void Start()
    {
        closeButton.onClick.AddListener(ClosePanel);
        puntos = 0;
        panelVictoria.SetActive(false);
        descriptionPanel.SetActive(false);
        gameObject.SetActive(false);

        jugar.onClick.AddListener(jugarF);
        mensaje.onClick.AddListener(mensajeF);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("aparatoG"))
        {
            Destroy(other.gameObject);
            Destroy(cuboCorrecto);
            siguienteParte.SetActive(true);
            puntos++;
        }
    }


    void ClosePanel()
    {
        descriptionPanel.SetActive(false);
        gameObject.SetActive(true);
    }

    void jugarF()
    {
        gameObject.SetActive(true);
        jugar.gameObject.SetActive(false);
        mensaje.gameObject.SetActive(false);

    }

    void mensajeF()
    {
        descriptionPanel.SetActive(true);
        instrucciones.Play();
        jugar.gameObject.SetActive(false);
        mensaje.gameObject.SetActive(false);
        descriptionPanel.GetComponent<AudioSource>().Play();
    }
}