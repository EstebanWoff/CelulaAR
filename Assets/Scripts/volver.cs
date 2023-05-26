using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class volver : MonoBehaviour
{
    // Start is called before the first frame update
    public void funVolver()
    {
        SceneManager.LoadScene("menu");
    }
       public void funIr()
    {
        SceneManager.LoadScene("EvalucionFinal");
    }
}

