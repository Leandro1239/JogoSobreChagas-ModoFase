// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// TRATA A MOVIMENTAÇÃO DO PERSONAGEM
public class Movimentacao : MonoBehaviour {

    //VARIÁVEIS
    public Rigidbody2D player;                                          //JOGADOR
    public RawImage rImg;                                               //IMAGEM DE FUNDO QUE FICA MEXENDO
    private int forcapulo = 100, velocidade = 7, direcao = 0;           //FORÇA DE PULO, VELOCIDADE DA CORRIDA, ORIENTAÇÃO NO EIXO X
    public bool olhandodireita = true, pisandochao = false;            //VERIFICA ORIENTAÇÃO, VERIFICA SE ESTÁ NO CHÃO
    public static int PulaSom = 0;
    public Animator anime;

    //REALIZA ISSO LOGO AO INICIAR
    void Start()                                               
    {
        player = gameObject.GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    //MÉTODO QUE REPETE SEMPRE
    void Update()
    {
        Rect temp = new Rect(rImg.uvRect);          //RAW IMG                                    
        temp.x += direcao * 0.003f;                 //VELOCIDADE
        rImg.uvRect = temp;
        transform.Translate(new Vector3((direcao * velocidade) * Time.deltaTime, 0, 0));        //MOVE O JOGADOR
    
    //CONTROLANDO PELO TECLADO PARA TESTES
        if (Input.GetKey(KeyCode.Space))
        {
            Pula();
        }

    // Controla animação de correr
        if (direcao != 0 && pisandochao == true)
        {
            anime.SetBool("Idle", false);
            anime.SetBool("Run", true);
        }
    }

    //FUNÇÃO QUE VIRA PARA O OUTRO LADO
    void Flip()                                                 
    {
        olhandodireita = !olhandodireita;                       //INVERTE A ORIENTAÇÃO
        Vector3 theScale = transform.localScale;                //PEGA O VALOR DA ESCALA
        theScale.x *= -1;                                       //INVERTE A ESCALA
        transform.localScale = theScale;                        //VALIDA
    }

    //MÉTODO QUE VIRA PRO LADO
    public void Direita()                                       
    {
        direcao = 1;                                            //ATRIBUI VALOR POSITIVO PARA ANDAR NO EIXO X
        if (direcao > 0 && olhandodireita == false)
        { 
            Flip();                                             //VERIFICA SE ESTÁ ANDANDO NA DIREÇÃO DO EIXO POSITIVO
        }
    }

    //MÉTODO QUE VIRA PRO LADO
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
        anime.SetBool("Idle", true);
        anime.SetBool("Run", false);
        direcao = 0;                                            //PARADO NO EIXO X
    }

    //SAI DO CHÃO
    public void Pula()
    {
        // PULA PARADO
        if (direcao == 0 && pisandochao == true)
        {
            anime.SetBool("Hit", false);
            anime.SetBool("Idle", false);
            anime.SetBool("Jump", true);
            PulaSom += 1;
            player.AddForce(new Vector2(0, forcapulo));         //ADICIONA UMA FORÇA ATRAVÉS DA VARIÁVEL 'forcapulo'                            
            pisandochao = false;                                //SE PULOU, NÃO PDOE PULAR DE NOVO
        }

        // PULA CORRENDO
        if (direcao != 0 && pisandochao == true)
        {
            anime.SetBool("Hit", false);
            anime.SetBool("Idle", false);
            anime.SetBool("Run", false);
            anime.SetBool("Jump", true);
            PulaSom += 1;
            player.AddForce(new Vector2(0, forcapulo));         //ADICIONA UMA FORÇA ATRAVÉS DA VARIÁVEL 'forcapulo'                            
            pisandochao = false;                                //SE PULOU, NÃO PDOE PULAR DE NOVO
        }
    }

    //COMPARA TAG COM O CHÃO
    public void OnCollisionEnter2D(Collision2D Chao)            
    {
        if (Chao.gameObject.CompareTag("Chao"))
        {
            anime.SetBool("Hit", false);
            anime.SetBool("Idle", true);
            anime.SetBool("Jump", false);
            pisandochao = true;                                 //SE ´TA TOCANDO NO CHÃO, PULO LIBERADO
        }
    }
}     
