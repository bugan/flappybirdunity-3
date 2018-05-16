using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceJogadorInativo : MonoBehaviour
{
    [SerializeField]
    private GameObject fundoInativo;
    [SerializeField]
    private Text obstaculosRestantes;

    public int obstaculosParaRessucitar
    {
        set
        {
            this.quantidadeRestanteDeObstaculosParaRessucitar = value;
            this.AtualizarTextoInterface();
        }
    }
    private int quantidadeRestanteDeObstaculosParaRessucitar;

    private Canvas canvas;

    private void Awake()
    {
        this.canvas = this.GetComponent<Canvas>();
    }

    public void DesativarAviao(Camera camera)
    {
        this.UsarCamera(camera);
        this.fundoInativo.SetActive(true);
        this.AtualizarTextoInterface();
    }

    public void AtivarAviao()
    {
        this.fundoInativo.SetActive(false);
    }

    private void UsarCamera(Camera camera)
    {
        this.canvas.worldCamera = camera;
    }

    private void AtualizarTextoInterface()
    {
        this.obstaculosRestantes.text = this.quantidadeRestanteDeObstaculosParaRessucitar.ToString();
    }
}
