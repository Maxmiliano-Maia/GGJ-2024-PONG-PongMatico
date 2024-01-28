using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class skip : MonoBehaviour
{
    public GameObject botao;
    // Start is called before the first frame update
    void Start()
    {
        botao.SetActive(false);
        Invoke("exibir_botao", 20f);
        Invoke("skip_scene", 88f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skip_scene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void exibir_botao()
    {
        botao.SetActive(true);
    }
}
