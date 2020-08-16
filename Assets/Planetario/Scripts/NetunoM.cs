using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetunoM : MonoBehaviour
{
    public GameObject planeta;
    public GameObject sol;
    public float velocidadeRotacao;
    public float velocidadeTranslacao;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Orbita();
    }

    void Orbita()
    {
        transform.RotateAround(planeta.transform.position, Vector3.up, velocidadeRotacao * Time.deltaTime);
        transform.RotateAround(sol.transform.position, Vector3.down, velocidadeTranslacao * Time.deltaTime);
    }
}
