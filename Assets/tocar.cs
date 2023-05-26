using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

using Vuforia;
using UnityEngine;
using Lean.Touch;
using Lean.Common;
using CW.Common;

public class tocar : MonoBehaviour, IPointerDownHandler
{
    public Animator animator; // Animator del modelo 3D
    public AudioSource audioSource; // AudioSource para el audio asociado a la animación

    private bool isAnimating = false; // Bandera para saber si la animación está en proceso

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isAnimating) // Verificar si no está en proceso la animación
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(eventData.position);

            if (Physics.Raycast(ray, out hit))
            {
                // Verificar si el objeto tocado es parte del modelo 3D de la célula
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Cell"))
                {
                    // Cambiar el material del objeto tocado para que resalte en otro color
                    hit.transform.GetComponent<Renderer>().material.color = Color.red;

                    // Iniciar la animación
                    animator.SetTrigger(hit.transform.name);
                    audioSource.Play();

                    // Activar la bandera de animación en proceso
                    isAnimating = true;

                    // Esperar al final del audio para detener la animación
                    Invoke("StopAnimation", audioSource.clip.length);
                }
            }
        }
    }

    void StopAnimation()
    {
        // Detener la animación
        animator.enabled = false;
        animator.enabled = true;

        // Restablecer el material del objeto tocado a su estado original
        foreach (Transform child in transform)
        {
            child.GetComponent<Renderer>().material.color = Color.white;
        }

        // Desactivar la bandera de animación en proceso
        isAnimating = false;
    }
}


