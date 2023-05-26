using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MIniJuegoREL : MonoBehaviour
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
        if (other.gameObject.CompareTag("reticuloLiso"))
        {
            Destroy(other.gameObject);
            Destroy(cuboCorrecto);
            siguienteParte.SetActive(true);
            puntos++;
        }
    }
}
