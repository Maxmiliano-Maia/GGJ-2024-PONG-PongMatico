using Photon.Pun;
using UnityEngine;


public class PlayerPaddle : Paddle
{
    private float velocidade = 8f;
    private Vector2 direcao;
    private Rigidbody2D rigido;
    PhotonView photonView;
    private void Awake()
    {
        rigido = GetComponent<Rigidbody2D>();
      
    }

    void Start()
    {
        photonView = GetComponent<PhotonView>();
    }

    private void Update()
    {
          
            if (photonView.IsMine)
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
                direcao = touch.deltaPosition.normalized * speed*1.5f;
                }

            else
                {
                    direcao = Vector2.zero;
                }
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
