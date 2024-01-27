using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;


public class Ball : MonoBehaviourPunCallbacks
{
    public Rigidbody2D corpoRigido;

    public float baseSpeed = 5f;
    public float maxSpeed = Mathf.Infinity;
    private bool scoreIncremented = false;
    public float currentSpeed { get; set; }
    private Vector2 initialPosition;

    private void Awake()
    {    
      initialPosition = new Vector2(0,0);       
    }

    private void Start()
    {
        initialPosition = new Vector2(0, 0);
        corpoRigido = GetComponent<Rigidbody2D>();
        AddStartingForce();
        transform.position = initialPosition;
    }

    public void ResetPosition()
    {
        corpoRigido.velocity = Vector2.zero;
        transform.position = initialPosition;
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1f : 1f;
        float y = Random.Range(-1f, 1f);

        Vector2 direction = new Vector2(x, y).normalized;
        corpoRigido.AddForce(direction * baseSpeed, ForceMode2D.Impulse);
        currentSpeed = baseSpeed;      
    }

    private void Update()
    {
        GameConnection gameConnection = UnityEngine.Object.FindObjectOfType<GameConnection>();

        if (transform.position.x >= 9)
        {            
            if (!scoreIncremented)
            {
                ResetPosition();
                gameConnection.PlayerScore += 1;
                gameConnection.remoteTextInstance.text = gameConnection.PlayerScore.ToString();
                scoreIncremented = true; // Marca que a pontuação foi incrementada
                Invoke("DelayedAddStartingForce", 1f);
            }
        }

        else if (transform.position.x <= -9)
        {
            if (!scoreIncremented)
            {
                ResetPosition();             
                gameConnection.PlayerScore2 += 1;
                gameConnection.remoteTextInstance2.text = gameConnection.PlayerScore2.ToString();
                scoreIncremented = true; // Marca que a pontuação foi incrementada
                Invoke("DelayedAddStartingForce", 1f);
            }
        }

        else
        {
            // Reinicia a variável quando a condição não é atendida
            scoreIncremented = false;
        }
    }

    private void DelayedAddStartingForce()
    {
        AddStartingForce();
    }
}
