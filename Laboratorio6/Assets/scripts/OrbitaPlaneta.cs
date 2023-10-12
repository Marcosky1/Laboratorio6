using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitaPlaneta : MonoBehaviour
{
    public Transform planeta;
    public float velocidadOrbita = 2.5f;
    private Vector3 offset;

    void Start()
    {
        offset = transform.position - planeta.position;
    }

    void Update()
    {
        float tiempo = Time.time * velocidadOrbita;
        float y = Mathf.Cos(tiempo) * offset.y - Mathf.Sin(tiempo) * offset.z;
        float z = Mathf.Sin(tiempo) * offset.y + Mathf.Cos(tiempo) * offset.z;

        transform.position = new Vector3(offset.x, y, z) + planeta.position;
    }
}
