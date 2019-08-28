using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolhePlayer : MonoBehaviour
{
    public static EscolhePlayer instance;

    // JOGADORES
    public GameObject player1, player2; 
    public GameObject escolha1, escolha2;

    // OBJETO VAZIO QUE CRIA O JOGADOR, ESTÁ NA FASE
    private GameObject achaJogador;

    // VARIAVEIS DE CONTROLE DE TROCA
    public int troca = 1, escolheu = 0;
    private bool controle = true;

    // SABER QUAL CENA ESTÁ
    private Scene cenaAtual;

    //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
    public void Awake(){
        if (instance == null)                           
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
        escolha1 = GameObject.Find("Jogador1");
        escolha2 = GameObject.Find("Jogador2");

        //SE NAO ESCOLHEU NADA, PEGA A ESCOLHA PADRÃO
        if (escolheu == 0){
            escolha1.gameObject.SetActive(true);
            escolha2.gameObject.SetActive(false);
        }
        // CASO ESTEJA NA FASE DESEJADA, PROCURA O LOCAL DE CRIAÇÃO, COLOCA O JOGADOR LÁ E TROCA DE NOME
        if (cenaAtual.name  == "Fase-1" && controle == true){
            // JOGADOR 1
            if(escolheu == 1){
                achaJogador = GameObject.Find("CriaJogador");
                achaJogador = Instantiate(player1, achaJogador.transform.position, achaJogador.transform.rotation);           
                achaJogador.name = "Player";
                controle = false;
            }

            // JOGADOR 2
            if(escolheu == 2){
                achaJogador = GameObject.Find("CriaJogador");
                achaJogador = Instantiate(player2, achaJogador.transform.position, achaJogador.transform.rotation);
                achaJogador.name = "Player";
                controle = false;
            }
        }
    }

    // ALTERNA ENTRE DOIS CASOS DE ESCOLHA DE PERSONAGEM
    public void TrocaPersonagem(){
        escolha1 = GameObject.Find("Jogador1");
        escolha2 = GameObject.Find("Jogador2");

        switch (troca)
        {
            case 1:
                troca = 2;
                escolheu = 2;
                escolha1.gameObject.SetActive(false);
                escolha2.gameObject.SetActive(true);
                break;

            case 2:
                troca = 1;
                escolheu = 1;
                escolha1.gameObject.SetActive(true);
                escolha2.gameObject.SetActive(false);
                break;
        }
    }
}
