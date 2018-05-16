using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtualizarTextoInput : MonoBehaviour {
    [SerializeField]
    private Text textoBotao;

    private TeclaPressionada teclaUtilizada;

    private void Awake()
    {
        this.teclaUtilizada = this.GetComponent<TeclaPressionada>();
    }
    
    private void Start () {
        this.textoBotao.text = this.teclaUtilizada.textoTecla;
	}
	
	
}
