using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Aviao))]
public class ControleDoComputador : MonoBehaviour
{
    [SerializeField]
    private float intervaloEntreImpulsos;
    private Aviao aviaoQueEuControlo;


    private void Awake()
    {
        this.aviaoQueEuControlo = this.GetComponent<Aviao>();
        StartCoroutine(this.Impulsionar());
    }
    
    private IEnumerator Impulsionar()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.intervaloEntreImpulsos);
            this.aviaoQueEuControlo.DarImpulso();
        }
    }
}
