using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patlama_efekti : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        Invoke("pasif_ol", 0.5f);
    }

   void pasif_ol()
    {
        gameObject.SetActive(false);
    }
}
