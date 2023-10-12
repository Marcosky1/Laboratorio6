using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoTierra : MonoBehaviour
{
    public float VRotacion = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(VRotacion,0,0)*Time.deltaTime);
    }

}
