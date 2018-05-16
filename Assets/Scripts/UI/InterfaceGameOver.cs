using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceGameOver : MonoBehaviour {
    [SerializeField]
    protected GameObject imagemGameOver;

    public virtual void MostrarInterface()
    {
        this.imagemGameOver.SetActive(true);
    }

    public virtual void EsconderInterface()
    {
        this.imagemGameOver.SetActive(false);
    }

}
