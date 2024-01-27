using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.SocialPlatforms.Impl;

public class GameManagerSingle : MonoBehaviour
{
    [SerializeField] private BallSingle ball;
    [SerializeField] private Paddle playerPaddle;
    [SerializeField] private Paddle computerPaddle;
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;
    [SerializeField] private Text quest;
    [SerializeField] private GameObject questPanel;

    private int playerScore;
    private int computerScore;
    
    // Array para armazenar as 100 perguntas
    private string[] perguntas = new string[37];
    //Analisa se a pergunta é verdadeira o falsa;
    private bool[] respostaPadrao = new bool[37];
    private int perguntaAtualIndex = 0;
    private bool respostafoidada = false;
    private int tempoQuest;

    private int KnocTop =0;
    private int KnocBottom = 0;

        private void Start()
    {
        NewGame();
        perguntas[0] = "Thor é um deus nórdico e membro dos Vingadores. Se todos os membros dos Vingadores são heróis, então Thor é um herói. Verdadeiro ou falso?";
        respostaPadrao[0] = true;
        
        perguntas[1] = "Se o gato da Alice pode aparecer e desaparecer à vontade, e o Coelho Branco está sempre atrasado, o coelho sempre chega antes que o gato?";
        respostaPadrao[1] = false;
        
        perguntas[2] = "Se todas as rosas são flores e algumas flores desbotam facilmente, então é possível afirmar que algumas rosas desbotam facilmente. Verdadeiro ou falso?";
        respostaPadrao[2] = true;
        
        perguntas[3] = "Se João está sempre feliz nas segundas-feiras e hoje é segunda-feira, então João está feliz hoje. Verdadeiro ou falso?";
        respostaPadrao[3] = true;
        
        perguntas[4] = "Se todos os pássaros têm penas e o pinguim é uma ave, então o pinguim tem penas. Verdadeiro ou falso?";
        respostaPadrao[4] = true;

        perguntas[5] = "Se água ferve a 100 graus Celsius ao nível do mar, e esta panela está ao nível do mar, então a água nesta panela ferverá a 100 graus Celsius. Verdadeiro ou falso?";
        respostaPadrao[5] = true;

        perguntas[6] = "Se nenhum mamífero pode voar e alguns morcegos são mamíferos, então nenhum morcego pode voar. Verdadeiro ou falso?";
        respostaPadrao[6] = false;

        perguntas[7] = "Se todas as maçãs são frutas e algumas frutas são ácidas, então é possível afirmar que algumas maçãs são ácidas. Verdadeiro ou falso?";
        respostaPadrao[7] = true;

        perguntas[8] = "Se um triângulo tem três lados e este polígono tem três lados, então este polígono é um triângulo. Verdadeiro ou falso?";
        respostaPadrao[8] = false;

        perguntas[9] = "Se Pedro sempre estuda para suas provas e hoje é dia de prova, então Pedro está estudando agora. Verdadeiro ou falso?";
        respostaPadrao[9] = true;

        perguntas[10] = "Se nenhum vegetal é doce e algumas frutas são doces, então é possível afirmar que nenhuma fruta é um vegetal. Verdadeiro ou falso?";
        respostaPadrao[10] = false;

        perguntas[11] = "Se todos os triângulos têm três lados e este polígono tem quatro lados, então este polígono é um quadrado. Verdadeiro ou falso?";
        respostaPadrao[11] = true;

        perguntas[12] = "Se Ana é mais alta que Maria e Maria é mais alta que João, então é possível afirmar que Ana é mais alta que João. Verdadeiro ou falso?";
        respostaPadrao[12] = true;

        perguntas[13] = "Se todos os alunos que estudam muito tiram boas notas e João tirou uma boa nota, então é possível afirmar que João estuda muito. Verdadeiro ou falso?";
        respostaPadrao[13] = true;

        perguntas[14] = "Se todas as folhas de carvalho são verdes e este objeto é verde, então é possível afirmar que este objeto é uma folha de carvalho. Verdadeiro ou falso?";
        respostaPadrao[14] = false;

        perguntas[15] = "Se todos os quadrados têm quatro lados e este polígono tem cinco lados, então este polígono é um pentágono. Verdadeiro ou falso?";
        respostaPadrao[15] = true;

        perguntas[16] = "Se alguns mamíferos botam ovos e o ornitorrinco é um mamífero, então o ornitorrinco bota ovos. Verdadeiro ou falso?";
        respostaPadrao[16] = true;

        perguntas[17] = "Se nenhum animal é capaz de voar e o avestruz é um animal, então o avestruz não pode voar. Verdadeiro ou falso?";
        respostaPadrao[17] = false;

        perguntas[18] = "Se todos os seres humanos são mortais e Maria é um ser humano, então Maria é mortal. Verdadeiro ou falso?";
        respostaPadrao[18] = true;

        perguntas[19] = "Se todas as ondas sonoras são invisíveis e este som é invisível, então este som é uma onda sonora. Verdadeiro ou falso?";
        respostaPadrao[19] = false;

        perguntas[20] = "Se nenhum planeta é feito de chocolate e a Terra é um planeta, então a Terra não é feita de chocolate. Verdadeiro ou falso?";
        respostaPadrao[20] = true;

        perguntas[21] = "Se todas as chaves abrem fechaduras e esta ferramenta abre fechaduras, então esta ferramenta é uma chave. Verdadeiro ou falso?";
        respostaPadrao[21] = true;

        perguntas[22] = "Se alguns pássaros não voam e este pássaro não voa, então é possível afirmar que este pássaro é um dos que não voam. Verdadeiro ou falso?";
        respostaPadrao[22] = true;

        perguntas[23] = "Se todas as noites têm estrelas e hoje é noite, então hoje tem estrelas. Verdadeiro ou falso?";
        respostaPadrao[23] = false;

        perguntas[24] = "Se nenhum carro é vivo e este carro está em movimento, então é possível afirmar que este carro está vivo. Verdadeiro ou falso?";
        respostaPadrao[24] = false;

        perguntas[25] = "Se todos os filmes são longos e este vídeo é longo, então é possível afirmar que este vídeo é um filme. Verdadeiro ou falso?";
        respostaPadrao[25] = false;

        perguntas[26] = "Se alguns músicos são talentosos e João é um músico, então é possível afirmar que João é talentoso. Verdadeiro ou falso?";
        respostaPadrao[26] = false;

        perguntas[27] = "Se nenhum reptil é mamífero e alguns animais peludos são mamíferos, então é possível afirmar que nenhum animal peludo é um réptil. Verdadeiro ou falso?";
        respostaPadrao[27] = true;

        perguntas[28] = "Se todas as flores precisam de água para sobreviver e esta planta não é uma flor, então é possível afirmar que esta planta não precisa de água. Verdadeiro ou falso?";
        respostaPadrao[28] = false;

        perguntas[29] = "Se todo rei governa um reino e esta pessoa governa um reino, então é possível afirmar que esta pessoa é um rei. Verdadeiro ou falso?";
        respostaPadrao[29] = false;

        perguntas[30] = "Se todos os computadores processam dados e esta máquina processa dados, então é possível afirmar que esta máquina é um computador. Verdadeiro ou falso?";
        respostaPadrao[30] = true;

        perguntas[31] = "Se nenhum inseto é mamífero e esta criatura é um mamífero, então é possível afirmar que esta criatura não é um inseto. Verdadeiro ou falso?";
        respostaPadrao[31] = true;

        perguntas[32] = "Se todas as abelhas produzem mel e esta criatura produz mel, então é possível afirmar que esta criatura é uma abelha. Verdadeiro ou falso?";
        respostaPadrao[32] = false;

        perguntas[33] = "Se todo herói usa capa e esta pessoa usa uma capa, então é possível afirmar que esta pessoa é um herói. Verdadeiro ou falso?";
        respostaPadrao[33] = false;

        perguntas[34] = "Se nenhuma planta é carnívora e esta planta é carnívora, então é possível afirmar que esta planta não é uma planta. Verdadeiro ou falso?";
        respostaPadrao[34] = false;

        perguntas[35] = "Se todo livro tem páginas e esta publicação tem páginas, então é possível afirmar que esta publicação é um livro. Verdadeiro ou falso?";
        respostaPadrao[35] = false;

        perguntas[36] = "Se todos os rios correm para o mar e este fluxo de água vai para o mar, então é possível afirmar que este fluxo de água é um rio. Verdadeiro ou falso?";
        respostaPadrao[36] = true;
        StartCoroutine(GerarPerguntasAIntervalos());
    }
    
    IEnumerator GerarPerguntasAIntervalos()
    {
        while (perguntaAtualIndex < perguntas.Length)
        {
            //Gerar intervalo de tempo aleatório
            System.Random random = new System.Random();
            tempoQuest = random.Next(30, 45);
            yield return new WaitForSeconds(tempoQuest); // Espera por segundos

            // Chama a função para exibir a pergunta
            ExibirPergunta(perguntas[perguntaAtualIndex]);
            // Agora, espere mais 5 segundos antes de chamar a próxima pergunta
            yield return new WaitForSeconds(6f);
     
            // Move para a próxima pergunta no array
            if (respostafoidada == true && perguntaAtualIndex <= perguntas.Length)
            {
                perguntaAtualIndex++;
                Invoke("DesativarQuestPanel", 2f);
            }
            respostafoidada = false;
        }
    }

    void ExibirPergunta(string pergunta)
    {
        questPanel.SetActive(true);
        quest.text = pergunta;
    }

    private void Update()
    {
        
        float elapsedTime = Time.time;
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            VoltarMenu();
        }
       if (KnocTop >= 6 && KnocBottom >=6 ) 
        {
            NewRound();
        } 
       
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        NewRound();
    }

    public void NewRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        CancelInvoke();
        KnocBottom = 0;
        KnocTop = 0;
        Invoke(nameof(StartRound), 1f);
    }

    public void StartRound()
    {
        ball.AddStartingForce();
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);
        NewRound();
    }

    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);
        NewRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

    public void VoltarMenu()
    {
        // Muda para a cena especificada pelo nome
        SceneManager.LoadScene("Menu");
    }

    public void verdadeiro()
    {
        respostafoidada = true;
        if (respostaPadrao[perguntaAtualIndex] == true){
            SetPlayerScore(playerScore + 2);
            quest.text = "Parabéns!";
            NewRound();
            
        }
        else if (respostaPadrao[perguntaAtualIndex] == false)
        {
            SetPlayerScore(playerScore + -2);
            quest.text = "Que pena você errou";
            NewRound();          
        }
    }

    public void falso()
    {
        respostafoidada = true;     
        if (respostaPadrao[perguntaAtualIndex] == true)
        {
            SetPlayerScore(playerScore - 2);
            quest.text = "Que pena você errou";
            NewRound();           
        }

        else if (respostaPadrao[perguntaAtualIndex] == false)
        {
            SetPlayerScore(playerScore + 2);
            quest.text = "Parabéns!";
            NewRound();          
        }
    }

    void DesativarQuestPanel()
    {
        questPanel.SetActive(false);
    }

    public void KnocOnTop()
    {
        KnocTop += 1;
    }

    public void KnocOnBottom()
    {
        KnocBottom += 1;
    }
}
