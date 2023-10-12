using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaPlaneta : MonoBehaviour
{
    public Transform planeta;
    public float velocidadOrbita = 0.5f;

    void Update()
    {
        float angulo = Time.time * velocidadOrbita;

        Quaternion rotacion = Quaternion.Euler(angulo, 0,0);

        Vector3 posicionRelativa = rotacion * (transform.position - planeta.position);

        transform.position = planeta.position + posicionRelativa;
    }
}
