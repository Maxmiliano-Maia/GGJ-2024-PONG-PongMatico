using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class ScoringZone_Colider2 : MonoBehaviour
{
    public UnityEvent scoreTrigger;
    public GameManagerSingle gamemanager;
    public GameConnection gameConnection;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Faça o que precisa ser feito quando a bola colide com o objeto
            scoreTrigger.Invoke();
            gamemanager.KnocOnBottom();

        }
    }

}

