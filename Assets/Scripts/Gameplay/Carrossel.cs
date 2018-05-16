using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrossel : MonoBehaviour {
    [SerializeField]
    private VariavelCompartilhadaFloat velocidade;
    [SerializeField]
    private float numeroDeRepeticoes = 1;

    private Vector3 posicaoInicial;
    private float tamanhoRealDaImagem;

    private void Awake()
    {
        this.posicaoInicial = this.transform.position;
        float tamanhoDaImagem = this.GetComponent<SpriteRenderer>().size.x;
        float escala = this.transform.localScale.x;
        this.tamanhoRealDaImagem = tamanhoDaImagem * escala;
    }
    void Update () {
        float deslocamento = Mathf.Repeat(this.velocidade.valor * Time.time, this.tamanhoRealDaImagem / numeroDeRepeticoes);
        this.transform.position = this.posicaoInicial + Vector3.left * deslocamento;
	}
}
