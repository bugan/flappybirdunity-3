using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorMultiplayer : Diretor {
    private InterfaceJogadorInativo interfaceJogadorInativo;
    private bool jogadorEstaMorto;
    private Jogador[] jogadores;
    private int pontosDesdeAMorte;

    [SerializeField]
    private int obstaculosParaRessucitar;

    protected override void Start()
    {
        base.Start();
        this.interfaceJogadorInativo = GameObject.FindObjectOfType<InterfaceJogadorInativo>();
        this.jogadores = GameObject.FindObjectsOfType<Jogador>();
    }

    public override void ReiniciarJogo()
    {
        base.ReiniciarJogo();
        pontosDesdeAMorte = 0;
        jogadorEstaMorto = false;
    }

    protected override void ReiniciarAvioes()
    {
        foreach(Jogador jogador in this.jogadores)
        {
            jogador.Ativar();
        }
    }

    public void HabilitarInterfaceDeAviaoInativo(Camera CameraDoJogador)
    {
        if (this.jogadorEstaMorto)
        {
            this.FinalizarJogo();
            this.interfaceJogadorInativo.AtivarAviao();
        }
        else
        {
            this.pontosDesdeAMorte = 0;
            this.jogadorEstaMorto = true;
            this.atualizarInterfaceInativo();
            this.interfaceJogadorInativo.DesativarAviao(CameraDoJogador);
        }
    }


    public void RemoverInterfaceDeAviaoInativo()
    {
        this.jogadorEstaMorto = false;
        this.interfaceJogadorInativo.AtivarAviao();
    }

    public void VerificarSePrecisaReviver()
    {
        this.pontosDesdeAMorte++;
        this.atualizarInterfaceInativo();
        if (this.jogadorEstaMorto)
        {
            

            if (this.pontosDesdeAMorte >= this.obstaculosParaRessucitar)
            {
                this.RemoverInterfaceDeAviaoInativo();
                this.ReiniciarAvioes();
            }
        }
    }

    private void atualizarInterfaceInativo()
    {
        this.interfaceJogadorInativo.obstaculosParaRessucitar = this.obstaculosParaRessucitar - this.pontosDesdeAMorte;
    }
}
