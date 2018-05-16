using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    private DiretorMultiplayer diretor;

    private GeradorDeObstaculos geradorObstaculos;
    private Aviao aviao;
    private Camera minhaCamera;
    private Carrossel[] cenarios;

    private bool estaMorto;

    private void Start()
    {
        this.diretor = GameObject.FindObjectOfType<DiretorMultiplayer>();
        this.aviao = this.GetComponentInChildren<Aviao>();
        this.minhaCamera = this.GetComponentInChildren<Camera>();
        this.geradorObstaculos = this.GetComponentInChildren<GeradorDeObstaculos>();
        this.cenarios = this.GetComponentsInChildren<Carrossel>();
    }

    public void Desativar()
    {
        this.diretor.HabilitarInterfaceDeAviaoInativo(this.minhaCamera);
        this.geradorObstaculos.Parar();
        foreach (Carrossel carrossel in this.cenarios)
        {
            carrossel.enabled = false;
        }

        this.estaMorto = true;
    }

    public void Ativar()
    {
        if (this.estaMorto)
        {
            this.aviao.Reiniciar();
            this.geradorObstaculos.Recomecar();
            foreach (Carrossel carrossel in this.cenarios)
            {
                carrossel.enabled = true;
            }
            this.estaMorto = false;
        }
    }
}
