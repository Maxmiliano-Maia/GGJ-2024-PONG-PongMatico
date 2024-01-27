using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    // ... Outros métodos e variáveis existentes ...

    public void OnPlayButtonClicked()
    {
        // Ao clicar no botão "Play" no menu
        JoinRoomFromMenu();
    }

    // Método para entrar na sala
    private void JoinRoomFromMenu()
    {
        int roomName = 1;

        // Carregar a cena da sala (certifique-se de que ela está no Build Settings do Unity)
        SceneManager.LoadScene("Multiplayer");

        // Obter ou criar o objeto GameConnection
        GameConnection gameConnection = FindObjectOfType<GameConnection>();
        if (gameConnection == null)
        {
            // Se o objeto GameConnection não existir na cena da sala, crie um novo
            GameObject gameConnectionObj = new GameObject("GameConnection");
            gameConnection = gameConnectionObj.AddComponent<GameConnection>();
        }

        // Entrar na sala após um curto atraso
        StartCoroutine(DelayedJoinRoom(roomName));
    }

    private IEnumerator DelayedJoinRoom(int roomName)
    {
        yield return new WaitForSeconds(1f); // Ajuste conforme necessário

        // Entrar na sala
        FindObjectOfType<GameConnection>().JoinRoom(roomName);
    }

    // Método de espera para entrar na sala após um curto atraso

}
