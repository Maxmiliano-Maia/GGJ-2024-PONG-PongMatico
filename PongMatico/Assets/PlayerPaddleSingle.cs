using UnityEngine;

public class PlayerPaddleSingle : Paddle
{
    private float velocidade = 8f;
    private Vector2 direcao;
    private Rigidbody2D rigido;

    private void Awake()
    {
        rigido = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direcao = Vector2.up;
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direcao = Vector2.down;
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            direcao = touch.deltaPosition.normalized * speed * 1.5f;
        }

        else
        {
            direcao = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (direcao.sqrMagnitude != 0)
        {
            rigido.AddForce(direcao * velocidade);
        }
    }

}
