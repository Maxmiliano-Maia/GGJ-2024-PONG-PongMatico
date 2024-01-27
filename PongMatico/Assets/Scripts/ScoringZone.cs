using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoringZone : MonoBehaviour
{
    public UnityEvent scoreTrigger;
    public GameManagerSingle gamemanager;
    public GameConnection gameConnection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            // Faça o que precisa ser feito quando a bola colide com o objeto
            scoreTrigger.Invoke();
            gamemanager.StartRound();
           
        }
    }

}

