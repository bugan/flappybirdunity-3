using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Pontuacao : MonoBehaviour {
    public int Pontos{ get;private  set; }

    [SerializeField]
    private Text textoPontuacao;
    [SerializeField]
    private UnityEvent aoPontuar;

   
    public void AdicionarPontos()
    {
        this.Pontos++;
        this.textoPontuacao.text = this.Pontos.ToString();
        this.aoPontuar.Invoke();
    }

    public void Reiniciar()
    {
        this.Pontos = 0;
        this.textoPontuacao.text = this.Pontos.ToString();
    }

    public void SalvarRecorde()
    {
        int recordeAtual = PlayerPrefs.GetInt("recorde");
        
        if (this.Pontos > recordeAtual)
        {
            PlayerPrefs.SetInt("recorde", this.Pontos);
        }
    }
}
