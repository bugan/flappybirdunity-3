using UnityEngine;
using UnityEngine.SceneManagement;

public class CarregadorDeCenas : MonoBehaviour {

	public void CarregarCena(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
