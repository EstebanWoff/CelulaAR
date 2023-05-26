using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float tiempoTranscurrido = 0f;
    public TMP_Text tiempoText;
    private bool temporizadorIniciado = false;
    public GameObject panelVictoria;

    public GameObject parteFinal;
    private float tiempoFinal;

    public GameObject cuboFinal;


    void Update()
    {
        if (temporizadorIniciado)
        {
            tiempoTranscurrido += Time.deltaTime;
            ActualizarTiempoUI();
        }

        if (!parteFinal.activeSelf && !cuboFinal.activeSelf)
        {
            tiempoFinal = tiempoTranscurrido;
            PlayerPrefs.SetFloat("TiempoFinal", tiempoFinal);
            PlayerPrefs.Save();
            DetenerTemporizador();

            panelVictoria.SetActive(true);



        }

    }

    public void IniciarTemporizador()
    {
        if (!temporizadorIniciado)
        {

            tiempoTranscurrido = 0f;
            temporizadorIniciado = true;
        }
    }

    private void ActualizarTiempoUI()
    {
        tiempoText.text = "Tiempo: " + tiempoTranscurrido.ToString("F2");
    }


    private void DetenerTemporizador()
    {
        temporizadorIniciado = false;
    }


 

}