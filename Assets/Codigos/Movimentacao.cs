﻿// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;
using System;

// TRATA A MOVIMENTAÇÃO DO PERSONAGEM
public class Movimentacao : MonoBehaviour 
{
    ControlaAudio ControlaAudio_R = new ControlaAudio();
    Sintoma Sintoma_R = new Sintoma();
    
    //PLAYER
    private GameObject player;                                                          //JOGADOR
    
    // CONTROLE DE PULO E VELOCIDADE
    private int /*forcapulo = 100,*/ velocidade = 7, direcao = 0;                          //FORÇA DE PULO, VELOCIDADE DA CORRIDA, ORIENTAÇÃO NO EIXO X
    private bool olhandodireita = true;                                            //VERIFICA ORIENTAÇÃO, VERIFICA SE ESTÁ NO CHÃO     

    // GAME OBJECT QUE CHECA O CHÃO
    public bool noChao = false;
    private float raioChao = 0.4f;
    private Transform checaChao;
    public LayerMask oChao;

    // ANIMAÇÃO
    public Animator anime;

    //MÉTODO QUE REPETE SEMPRE
    void Update()
    {        
        //MOVE O JOGADOR
        player = GameObject.Find("Player");
        player.transform.Translate(new Vector3((direcao * velocidade) * Time.deltaTime, 0, 0));       

        // Checa o Chão
        checaChao = player.transform.Find("ChecaChão");
        noChao = Physics2D.OverlapCircle(checaChao.position, raioChao, oChao);           // DEFINE O TAMANHO DO RAIO DO 'CHECACHAO'

        // Animação
        anime = player.GetComponent<Animator>();

        //CONTROLANDO PELO TECLADO PARA TESTES
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Pula();
        }

        // ANIMAÇÃO RUN
        if (direcao != 0 && noChao)
        {
            anime.SetBool("Run", true);
            anime.SetBool("Idle", false);
            anime.SetBool("Jump", false);
        }

        // ANIMAÇÃO IDLE
        if (direcao == 0 && noChao)
        {
            anime.SetBool("Run", false);
            anime.SetBool("Idle", true);
            anime.SetBool("Jump", false);
        }

        // ANIMAÇÃO HIT
        if (Sintoma_R.damage == 1)
        {
            anime.SetBool("Hit", true);
            Sintoma_R.damage = 0;
        }
        else if (Sintoma_R.damage == 0)
        {
            anime.SetBool("Hit", false);
        }
    }

    // ====================== FUNÇÕES DE MOVIMENTO ========================== \\
    // GIRA O PERSONAGEM
    void Flip()                                                 
    {
        olhandodireita = !olhandodireita;                       //INVERTE A ORIENTAÇÃO
        Vector3 theScale = player.transform.localScale;                //PEGA O VALOR DA ESCALA
        theScale.x *= -1;                                       //INVERTE A ESCALA
        player.transform.localScale = theScale;                        //VALIDA
    }

    //VIRA PARA A DIREITA
    public void Direita()                                       
    {
        direcao = 1;                                            //ATRIBUI VALOR POSITIVO PARA ANDAR NO EIXO X
        if (direcao > 0 && olhandodireita == false)
        { 
            Flip();                                             //VERIFICA SE ESTÁ ANDANDO NA DIREÇÃO DO EIXO POSITIVO
        }
    }

    //VIRA PARA A ESQUERDA
    public void Esquerda()                                      
    {
        direcao = -1;                                           //ATRIBUI VALOR NEGATIVO PARA ANDAR NO EIXO X
        if (direcao < 0 && olhandodireita == true)
        {
            Flip();                                             //VERIFICA SE ESTÁ ANDANDO NA DIREÇÃO DO EIXO NEGATIVO
        }
    }

    //PARA DE ANDAR
    public void Para()                                          
    {
        direcao = 0;                                            //PARADO NO EIXO X
    }

    //SAI DO CHÃO
    public void Pula()
    {
        if (noChao)
        {
            // ANIMAÇÃO JUMP
            anime.SetBool("Jump", true);
            anime.SetBool("Run", false);
            anime.SetBool("Idle", false);

            // ADICIONA O SOM, A FORÇA DE PULO E FAZ COM QUE NÃO PULE EM SEGUIDA
            ControlaAudio_R.PlaySom(2);                // Gerenciador de Áudio
            noChao = false;
        }
    }
}