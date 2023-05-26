using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinijuegoMito : MonoBehaviour
{
    public GameObject cuboCorrecto;
    public GameObject siguienteParte;
    public int puntos;

    void Start()
    {
        puntos = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("mitocondria"))
        {
            Destroy(other.gameObject);
            Destroy(cuboCorrecto);
            siguienteParte.SetActive(true);
            puntos++;
        }
    }
}