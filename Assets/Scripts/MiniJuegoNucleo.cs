using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniJuegoNucleo : MonoBehaviour
{
    public GameObject cuboCorrecto;
    public int puntos;

    void Start()
    {
        puntos = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("nucleO"))
        {
            other.gameObject.SetActive(false);
            cuboCorrecto.gameObject.SetActive(false);
            puntos++;
        }
    }
}