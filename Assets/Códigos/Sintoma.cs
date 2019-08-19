// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// TRATA OS DANOS QUE O PERSONAGEM TOMA
public class Sintoma : MonoBehaviour {

    //VARIÁVEIS
    public static Sintoma instance;                                         //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    
    // CONTROLE DE VIDA
    public int ValorAtual = 3, Dano = 1, Energia = 1;    //VALOR TOTAL DA VIDA, VALOR QUANDO LEVA DANO, VALOR QUANDO RECUPERA VIDA
    public static int Morreu = 0;                   // 1=MORTO, 0=VIVO
    
    // TEXTO E IMAGEM
    public Text Saude;                                                      //RECEBE O TEXTO ONDE ESCREVE O ATUAL ESTADO
    public Image Cora1, Cora2, Cora3;                                       //IMAGENS DOS CORAÇÕES PARA MOSTRAR QUE PERDEU VIDA
    
    // ANIMAÇÃO
    public static int damage = 0;               // CONTROLE DE ANIMAÇÃO DE HIT
    public Animator anime;

    // ATIVA A ANIMAÇÃO
    public void Start()
    {
        anime = GetComponent<Animator>();
    }

    // ============================ COLISÕES ================================= \\
    //COLISÃO COM INIMIGO
    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            // ANIMAÇÃO HIT
            damage = 1;

            // DESTROI O OBJETO E PERDE VIDA
            Destroy(Dano.gameObject);                       //DESTROI O INIMIGO QUANDO TOCA
            VidaPerde();                                    //CHAMA O METODO 'VidaPerde'
            
            // EMITE SOM E CONTA TOQUES NO BARBEIRO
            GameManager.instance.PlaySom(1);              // Gerenciador de Áudio
            GameManager.instance.BarbeiroTocou();
        }
    }

    //COLISÃO COM REMÉDIO
    public void OnTriggerEnter2D(Collider2D Vida)                         //GANHA VIDA AO PASSAR NA BARRACA
    {
        if (Vida.gameObject.CompareTag("Vida"))
        {
            VidaGanha();                                    //CHAMA O METODO 'VidaGanha'
            Destroy(Vida.gameObject);                       //DESTROI A CURA
        }
    }

    // ========================= GERENCIA DE VIDA ========================== \\
    //MÉTODO QUE FAZ PERDER VIDA
    public void VidaPerde()                                 
    {
        if (ValorAtual > 0)
        {
            ValorAtual -= Dano;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
        if (ValorAtual == 0)
        {
            Morreu = 1;
            Cora1.fillAmount = 0;
            Cora2.fillAmount = 0;
            Cora3.fillAmount = 0;
        }
    }

    //MÉTODO QUE FAZ GANHARR VIDA
    public void VidaGanha()                                 
    {
        if (ValorAtual < 3)
        {
            ValorAtual += Energia;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
    }

    // ========================== ESCREVE NA TELA =========================== \\
    //MÉTODO QUE VERIFICA O ESTADO DE SAÚDE PARA ESCREVER NA TELA
    public void EstadoSaude()                               //DIFINE TODOS OS ESTADOS E O QUE ACONTECE NELES
    {
        if (ValorAtual == 3)
        {
            Saude.text = "Saudável";
            Cora1.fillAmount = 1;
            Cora2.fillAmount = 1;
            Cora3.fillAmount = 1;
        }

        if (ValorAtual == 2)
        {
            Saude.text = "Doente";
            Cora1.fillAmount = 1;
            Cora2.fillAmount = 1;
            Cora3.fillAmount = 0;
        }

        if (ValorAtual == 1)
        {
            Saude.text = "Muito Doente";
            Cora1.fillAmount = 1;
            Cora2.fillAmount = 0;
            Cora3.fillAmount = 0;
        }
    }
}
