using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class errorRE : MonoBehaviour
{
    public Material correcto;
    public Material error;
    private float timer = 1.0f;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("reticuloLiso"))
        {
            GetComponent<Renderer>().material = error;
            Invoke("ResetObjectHighlight", timer);
        }

    }
       void ResetObjectHighlight()
    {
        // Restaura el color del objeto
        GetComponent<Renderer>().material = correcto;
    }
}

