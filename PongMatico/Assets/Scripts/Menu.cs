using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
  
    public void GerentedeCena(string cena)
    {
        SceneManager.LoadScene(cena);
    }

    public void AbrirURL()
    {
        // Abre a URL no navegador padr�o
        Application.OpenURL("https://pongmatico.web.app/Privacy%20Policy.html");
    }

    public void SairJogo()
    {
        Application.Quit();
    }

}
