using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class IniciarJuego : MonoBehaviour
{
    public void IrMapa()
    {
        SceneManager.LoadScene("Scene");
        // SceneManager.LoadScene("Cargando", LoadSceneMode.Additive);
    }
}
