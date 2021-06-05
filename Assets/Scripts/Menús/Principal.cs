using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Principal : MonoBehaviour
{
    public void RegresarPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
        // SceneManager.LoadScene("Cargando", LoadSceneMode.Additive);
    }
}
