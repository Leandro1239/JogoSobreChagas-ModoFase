using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolhePlayer : MonoBehaviour
{
    public static EscolhePlayer instance;
    public GameObject player1, player2;
    private GameObject achaJogador;
    int troca = 1;
    public bool controle = true;
    private Scene cenaAtual;

    public void Start(){
        player1.gameObject.SetActive(true);
        player2.gameObject.SetActive(false);
    }

    public void Awake(){
        if (instance == null)                           //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

// VERIFICAR A CENA QUE ESTÁ PARA INSTANCIAR O JOGADOR
public void Update(){
    cenaAtual = SceneManager.GetActiveScene();
    Debug.Log("Name: " + cenaAtual.name);

    if (cenaAtual.name  == "Fase-1" && controle == true){
        achaJogador = GameObject.Find("CriaJogador");
        achaJogador = Instantiate(player1, achaJogador.transform.position, achaJogador.transform.rotation);
        achaJogador.name = "Player";
        controle = false;
    }
}

    public void TrocaPersonagem(){
        switch (troca)
        {
            case 1:
                troca = 2;
                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(true);
                break;

            case 2:
                troca = 1;
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(false);
                break;
        }
    }
}
