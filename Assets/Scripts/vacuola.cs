using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Lean.Touch;
using Lean.Common;
using CW.Common;
using UnityEngine.UI;

public class vacuola : MonoBehaviour
{
    public GameObject objectToTouch; // Objeto 3D a tocar
    public Animator anim;
    private bool isTouched = false; // Controla si el objeto ha sido tocado
    public AudioSource audioSource;

    private bool objectHighlighted = false; // indica si el objeto está resaltado
    private float highlightTime = 25f; // tiempo en segundos que el objeto estará resaltado
    public Material highlightColor; // color de resaltado del objeto

    public Material vacuolaM;
    public Material vacuolaM2;

    public GameObject descriptionPanel; // panel que contiene el texto de la descripción
    public Button closeButton; // botón para cerrar el panel
    private float displayTime = 25f; // tiempo que se muestra el panel en segundos

    private bool isPanelActive = false;
    private float timer = 0f;

    public GameObject children;
    void Start()
    {
       
            children=objectToTouch.transform.GetChild(0).gameObject;
            descriptionPanel.SetActive(false);
            closeButton.onClick.AddListener(ClosePanel);
        
     
    }

    void Update()
    {
        if (isPanelActive)
        {
            // incrementar el temporizador y cerrar el panel si se ha agotado el tiempo
            timer += Time.deltaTime;
            if (timer >= displayTime)
            {
                ClosePanel();
            }
        }
    }

    void OnEnable()
    {
        // Suscribirse a los eventos de toque de LeanTouch
        LeanTouch.OnFingerTap += OnFingerTap;
        LeanTouch.OnFingerUp += OnFingerUp;
    }

    void OnDisable()
    {
        // Cancelar la suscripción a los eventos de toque de LeanTouch
        LeanTouch.OnFingerTap -= OnFingerTap;
        LeanTouch.OnFingerUp -= OnFingerUp;
    }

    void OnFingerTap(LeanFinger finger)
    {
        // Comprobar si se ha tocado el objeto
        if (isTouched) return;

        RaycastHit hit;
        if (Physics.Raycast(finger.GetRay(), out hit))
        {
            if (hit.transform.gameObject == objectToTouch && anim.GetCurrentAnimatorStateInfo(0).IsName("Nada")
)
            {
                Debug.Log("¡Se tocó el objeto " + objectToTouch.name + "!");
                isTouched = true;
                anim.Play("vacuola");
                PlaySound();

                if (!objectHighlighted)
                {
                    objectToTouch.GetComponent<Renderer>().material = highlightColor;
                    children.GetComponent<Renderer>().material = highlightColor;
                    objectHighlighted = true;
                    Invoke("ResetObjectHighlight", highlightTime);
                }

                descriptionPanel.SetActive(true);
                isPanelActive = true;
                timer = 0f;
            }
            else if (hit.transform.gameObject != objectToTouch)
            {
                ClosePanel();
            }
        }
    }

    void OnFingerUp(LeanFinger finger)
    {
        // Reiniciar la variable isTouched
        isTouched = false;
    }

    void PlaySound()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }

    void ResetObjectHighlight()
    {
        // Restaura el color del objeto
        children.GetComponent<Renderer>().material = vacuolaM2;
        objectToTouch.GetComponent<Renderer>().material = vacuolaM;
        objectHighlighted = false;
    }
    void ClosePanel()
    {
        // ocultar el panel y reiniciar el temporizador
        descriptionPanel.SetActive(false);
        isPanelActive = false;
        timer = 0f;
        ResetObjectHighlight();
        audioSource.Stop();
        anim.Play("Nada");
        isTouched = false;

    }

}
