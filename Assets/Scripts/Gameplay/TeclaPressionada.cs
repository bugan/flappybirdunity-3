using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TeclaPressionada : MonoBehaviour {
    public string textoTecla { get { return this.tecla.ToString(); } }

    [SerializeField]
    private KeyCode tecla;
    [SerializeField]
    private UnityEvent aoSerPressionada;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(this.tecla))
        {
            this.aoSerPressionada.Invoke();
        }
	}
}
