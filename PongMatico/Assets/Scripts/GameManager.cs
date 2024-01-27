using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    [SerializeField] private Ball ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;

    private int computerScore;

    private int playersInRoom = 0;

    public void SetPlayersInRoom(int count)
    {
        playersInRoom = count;

        // Iniciar o round apenas se houver pelo menos dois jogadores
        if (playersInRoom >= 2)
        {
            ball.AddStartingForce();
        }
        else
        {
            // Se houver menos de dois jogadores, reiniciar o jogo
            NewGame();
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }

    }

    public void NewGame()
    {
        //SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();       
    }

    public void StartRound()
    {      
        ball.AddStartingForce();       
    }

    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);
        NewRound();
    }

  

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}