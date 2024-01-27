using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SocialPlatforms.Impl;
using Photon.Pun.Demo.PunBasics;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class GameConnection : MonoBehaviourPunCallbacks
{
    public Text chatLog;
    private Canvas canvas;
    public Text remoteTextPrefab; // Adicione esse campo para referenciar o prefab do texto remoto
    public Text remoteTextInstance;
    public Text remoteTextPrefab2; // Adicione esse campo para referenciar o prefab do texto remoto
    public Text remoteTextInstance2;
    
    private const string PlayerScoreKey = "PlayerScore";
    private const string PlayerScoreKey2 = "PlayerScore2";

    private const int NumberOfRooms = 10;
    //--------------------------

    public int PlayerScore
    {
        get
        {
            if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.CustomProperties != null)
            {
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(PlayerScoreKey))
                {
                    return (int)PhotonNetwork.CurrentRoom.CustomProperties[PlayerScoreKey];
                }
                else
                {
                    // Lida com a situação em que a chave PlayerScoreKey não existe nas propriedades personalizadas
                    // Pode retornar um valor padrão ou lançar uma exceção, dependendo da lógica do seu jogo.
                    return 1; // Valor padrão, mas ajuste conforme necessário.
                }
            }
            else
            {
                // Lida com a situação em que PhotonNetwork.CurrentRoom ou CustomProperties é null
                // Pode retornar um valor padrão ou lançar uma exceção, dependendo da lógica do seu jogo.
                return 0; // Valor padrão, mas ajuste conforme necessário.
            }
        }
        set
        {
            ExitGames.Client.Photon.Hashtable customProps = new ExitGames.Client.Photon.Hashtable();
            customProps[PlayerScoreKey] = value;
            PhotonNetwork.CurrentRoom.SetCustomProperties(customProps);
        }
    }

    public int PlayerScore2
    {
        get
        {
            if (PhotonNetwork.CurrentRoom != null && PhotonNetwork.CurrentRoom.CustomProperties != null)
            {
                if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey(PlayerScoreKey2))
                {
                    return (int)PhotonNetwork.CurrentRoom.CustomProperties[PlayerScoreKey2];
                }
                else
                {
                    // Lida com a situação em que a chave PlayerScoreKey não existe nas propriedades personalizadas
                    // Pode retornar um valor padrão ou lançar uma exceção, dependendo da lógica do seu jogo.
                    return 1; // Valor padrão, mas ajuste conforme necessário.
                }
            }
            else
            {
                // Lida com a situação em que PhotonNetwork.CurrentRoom ou CustomProperties é null
                // Pode retornar um valor padrão ou lançar uma exceção, dependendo da lógica do seu jogo.
                return 0; // Valor padrão, mas ajuste conforme necessário.
            }
        }
        set
        {
            ExitGames.Client.Photon.Hashtable customProps = new ExitGames.Client.Photon.Hashtable();
            customProps[PlayerScoreKey2] = value;
            PhotonNetwork.CurrentRoom.SetCustomProperties(customProps);
        }
    }

    void Update()
    {
        // Verifica se a tecla Escape foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void Awake()
    {
        chatLog.text = "Conectando no servidor...";
        PhotonNetwork.LocalPlayer.NickName = "Player" + Random.Range(0, 1000);
        PhotonNetwork.ConnectUsingSettings();
        Invoke("ClearChatLog", 5f);
    }

    private void ClearChatLog()
    {
        // Set the chatLog text to an empty string
        chatLog.text = "";
    }

    public void JoinRoom(int roomNumber)
    {
        string roomName = "Room" + roomNumber;
        PhotonNetwork.JoinRoom(roomName);
        chatLog.text += "Entrando na sala " + roomName + "...";
    }

    public void CreateRoom(int roomNumber)
    {
        string roomName = "Room" + roomNumber;
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(roomName, roomOptions, null);
        chatLog.text += "Criando sala " + roomName + "!";
    }

    //--------------------------------------------------------
    public override void OnConnectedToMaster()
    {
        chatLog.text += "Conectado no servidor!";
        if (PhotonNetwork.InLobby == false)
        {
            chatLog.text += "Entrando no Lobby...";
            PhotonNetwork.JoinLobby();
        }
    }

    //--------------------------------------------------------
    public override void OnJoinedLobby()
    {       
        chatLog.text += "Entrou no Lobby!";
        PhotonNetwork.JoinRoom("Maximus");
        chatLog.text += "Entrando na sala Maximus...";
    }

           
    //--------------------------------------------------------
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        
        chatLog.text += "Erro ao entrar na sala: " + message + " return code = " + returnCode;

        if (returnCode == ErrorCode.GameDoesNotExist)
        {
            RoomOptions room = new RoomOptions { MaxPlayers = 2 };
            PhotonNetwork.CreateRoom("Maximus", room, null);
            chatLog.text += "Criando sala Maximus!";
        }
    }

    //--------------------------------------------------------
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        chatLog.text += "Player entrou na sala: " + newPlayer.NickName;
        UpdatePlayersInRoom();
    }

    //--------------------------------------------------------
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        chatLog.text += "Player saiu na sala: " + otherPlayer.NickName;
        UpdatePlayersInRoom();
    }

    private void UpdatePlayersInRoom()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (gameManager != null)
        {
            gameManager.SetPlayersInRoom(PhotonNetwork.CurrentRoom.PlayerCount);
        }
    }

    //--------------------------------------------------------
    public override void OnLeftRoom()
    {
        chatLog.text += "Você saiu da sala...";
    }

    //--------------------------------------------------------
    public override void OnJoinedRoom()
    {
        chatLog.text += "Você entrou na sala: Maximus, como: " + PhotonNetwork.LocalPlayer.NickName;
        
        Vector3 position;
        Vector3 positionBall;
        Quaternion rotation;
        positionBall = new Vector3(0, 0, 0);
        rotation = Quaternion.Euler(Vector3.up * Random.Range(0, 0));
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        remoteTextInstance = Instantiate(remoteTextPrefab);
        remoteTextInstance.transform.SetParent(canvas.transform, false);
        remoteTextInstance2 = Instantiate(remoteTextPrefab2);
        remoteTextInstance2.transform.SetParent(canvas.transform, false);


        Vector3 positionPlacar1 = new Vector3(-50, -50, 0);

        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            // Jogador 1
            position = new Vector3(-8, 0, 0);

            // Instantiate "Player Paddle1" and set it as a child of the Canvas
            PhotonNetwork.Instantiate("Player Paddle1", position, rotation);
           
        }
        else
        {
            // Jogador 2
            position = new Vector3(8, 0, 0);
            // Instantiate "Player Paddle1" and set it as a child of the Canvas
            PhotonNetwork.Instantiate("Player Paddle1", position, rotation);
            PhotonNetwork.Instantiate("Ball1", positionBall, rotation);

        }
    }

    public void SairJogo()
    {
        // Sai do jogo
        SceneManager.LoadScene("Menu");

    }

}