// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;
using System;

// TRATA A MOVIMENTAÇÃO DO PERSONAGEM
public class Movimentacao : MonoBehaviour 
{
    public static Movimentacao instance; 
    
    //PLAYER
    GameObject player;                                                          //JOGADOR
    
    // IMAGEM DE FUNDO
    public RawImage rImg;                                                               //IMAGEM DE FUNDO QUE FICA MEXENDO
    
    // CONTROLE DE PULO E VELOCIDADE
    private int forcapulo = 100, velocidade = 7, direcao = 0;                          //FORÇA DE PULO, VELOCIDADE DA CORRIDA, ORIENTAÇÃO NO EIXO X
    private bool olhandodireita = true;                                            //VERIFICA ORIENTAÇÃO, VERIFICA SE ESTÁ NO CHÃO     

    // GAME OBJECT QUE CHECA O CHÃO
    public bool noChao = false;
    private float raioChao = 0.4f;
    public LayerMask oChao;
    public Transform checaChao;

    // ANIMAÇÃO
    private Animator anime;

    //ACHA O PLAYER E A ANIMAÇÃO
    void Start()                                               
    { 
        anime = GetComponent<Animator>();
    }

    //MÉTODO QUE REPETE SEMPRE
    void Update()
    {
        /* MOVIMENTA O FUNDO
        Rect temp = new Rect(rImg.uvRect);                  //RAW IMG                                    
        temp.x += 1.001f + (1.005f * direcao);              //VELOCIDADE DE MOVIMENTO DA TELA DE FUNDO
        rImg.uvRect = temp;
        */
        transform.Translate(new Vector3((direcao * velocidade) * Time.deltaTime, 0, 0));        //MOVE O JOGADOR
        noChao = Physics2D.OverlapCircle(checaChao.position, raioChao, oChao);                  // DEFINE O TAMANHO DO RAIO DO 'CHECACHAO'

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
        if (Sintoma.damage == 1)
        {
            anime.SetBool("Hit", true);
            Sintoma.damage = 0;
        }
        else if (Sintoma.damage == 0)
        {
            anime.SetBool("Hit", false);
        }
    }

    // ====================== FUNÇÕES DE MOVIMENTO ========================== \\
    // GIRA O PERSONAGEM
    void Flip()                                                 
    {
        olhandodireita = !olhandodireita;                       //INVERTE A ORIENTAÇÃO
        Vector3 theScale = transform.localScale;                //PEGA O VALOR DA ESCALA
        theScale.x *= -1;                                       //INVERTE A ESCALA
        transform.localScale = theScale;                        //VALIDA
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
            GameManager.instance.PlaySom(2);                // Gerenciador de Áudio
            //player.AddForce(new Vector2(0, forcapulo), ForceMode2D.Impulse);         //ADICIONA UMA FORÇA ATRAVÉS DA VARIÁVEL 'forcapulo'                            
            noChao = false;
        }
    }
}