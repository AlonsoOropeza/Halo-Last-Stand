using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class Tutorial : MonoBehaviour
{
    public void IrTutorial()
    {
        SceneManager.LoadScene("MenuTutorial");
        // SceneManager.LoadScene("Cargando", LoadSceneMode.Additive);
    }
}
