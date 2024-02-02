using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    Material material;
    Shader shader;
    [SerializeField] float Alpha = 0;
    void Start()
    {
        material =transform.GetComponent<Renderer>().material;
        print(material);
        shader = Shader.Find("Custom/SphereShader");
        print(shader);
    }

    // Update is called once per frame
    void Update()
    {
        Alpha = Random.Range(0f,100f)/100f;
        //print(Alpha);
        material.SetFloat("_Alpha", Alpha);
        //print(material.GetFloat("_Alpha"));

    }
}
