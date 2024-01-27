using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    // ... Outros m�todos e vari�veis existentes ...

    public void OnPlayButtonClicked()
    {
        // Ao clicar no bot�o "Play" no menu
        JoinRoomFromMenu();
    }

    // M�todo para entrar na sala
    private void JoinRoomFromMenu()
    {
        int roomName = 1;

        // Carregar a cena da sala (certifique-se de que ela est� no Build Settings do Unity)
        SceneManager.LoadScene("Multiplayer");

        // Obter ou criar o objeto GameConnection
        GameConnection gameConnection = FindObjectOfType<GameConnection>();
        if (gameConnection == null)
        {
            // Se o objeto GameConnection n�o existir na cena da sala, crie um novo
            GameObject gameConnectionObj = new GameObject("GameConnection");
            gameConnection = gameConnectionObj.AddComponent<GameConnection>();
        }

        // Entrar na sala ap�s um curto atraso
        StartCoroutine(DelayedJoinRoom(roomName));
    }

    private IEnumerator DelayedJoinRoom(int roomName)
    {
        yield return new WaitForSeconds(1f); // Ajuste conforme necess�rio

        // Entrar na sala
        FindObjectOfType<GameConnection>().JoinRoom(roomName);
    }

    // M�todo de espera para entrar na sala ap�s um curto atraso

}
