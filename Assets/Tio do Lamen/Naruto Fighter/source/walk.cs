using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public GameObject naruto;
    public float velocidade = 0.01f;
    public float tempo = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {

        naruto.transform.position += Vector3.forward * velocidade * Time.deltaTime;
        
         
    }


}
