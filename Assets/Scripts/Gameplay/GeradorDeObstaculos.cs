using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeObstaculos : MonoBehaviour
{
    [SerializeField]
    private float tempoParaGerarFacil;
    [SerializeField]
    private float tempoParaGerarDificil;

    [SerializeField]
    private GameObject manualDeIntrucoes;

    private ControleDeDificuldade controleDeDificuldade;
    private List<GameObject> meusObstaculos;
    private float cronometro;
    private bool parado;


    private void Awake()
    {
        this.cronometro = this.tempoParaGerarFacil;
        this.meusObstaculos = new List<GameObject>();
    }

    private void Start()
    {
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();
    }

    private void Update()
    {
        if (this.parado)
        {
            return;
        }

        this.cronometro -= Time.deltaTime;
        if (this.cronometro < 0)
        {
            var obstaculo = GameObject.Instantiate(this.manualDeIntrucoes, this.transform.position, Quaternion.identity);
            this.meusObstaculos.Add(obstaculo);

            this.cronometro = Mathf.Lerp(this.tempoParaGerarFacil,
                                         this.tempoParaGerarDificil,
                                         this.controleDeDificuldade.Dificuldade
                );
        }
    }

    public void Parar()
    {
        this.parado = true;
        this.DestruirObstaculo();
    }

    public void Recomecar()
    {
        this.parado = false;
    }

    private void DestruirObstaculo()
    {
        foreach(var obstaculo in this.meusObstaculos)
        {
            Destroy(obstaculo);
        }
    }
}
