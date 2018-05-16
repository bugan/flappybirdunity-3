using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diretor : MonoBehaviour
{
    private Aviao[] avioes;
    private Pontuacao[] pontucoes;
    private InterfaceGameOver interfaceGameOver;
    private ControleDeDificuldade controleDeDificuldade;
    protected virtual void Start()
    {
        
        this.pontucoes = GameObject.FindObjectsOfType<Pontuacao>();
        this.interfaceGameOver = GameObject.FindObjectOfType<InterfaceGameOver>();
        this.avioes = GameObject.FindObjectsOfType<Aviao>();
        this.controleDeDificuldade = GameObject.FindObjectOfType<ControleDeDificuldade>();



    }

    public void FinalizarJogo()
    {
        Time.timeScale = 0;

        foreach (Pontuacao pontuacao in this.pontucoes)
        {
            pontuacao.SalvarRecorde();
        }
        this.interfaceGameOver.MostrarInterface();
    }

    public virtual void ReiniciarJogo()
    {
        this.interfaceGameOver.EsconderInterface();
        Time.timeScale = 1;
        this.DestruirObstaculos();
        this.ReiniciarAvioes();
        this.ReiniciarPontos();
        this.controleDeDificuldade.Reiniciar(); 
    }

    private void ReiniciarPontos()
    {
        foreach (Pontuacao pontuacao in this.pontucoes)
        {
            pontuacao.Reiniciar();
        }
    }

    private void DestruirObstaculos()
    {
        Obstaculo[] obstaculos = GameObject.FindObjectsOfType<Obstaculo>();
        foreach (Obstaculo obstaculo in obstaculos)
        {
            obstaculo.Destruir();
        }
    }

    protected virtual void ReiniciarAvioes()
    {

        foreach (Aviao aviao in this.avioes)
        {
            aviao.Reiniciar();
        }
    }
}
