// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// TRATA OS DANOS QUE O PERSONAGEM TOMA
public class Sintoma : MonoBehaviour {

    //VARIÁVEIS
    public static Sintoma instance;                                         //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    
    // CONTROLE DE VIDA
    private int ValorAtual = 3, Dano = 1, Energia = 1;    //VALOR TOTAL DA VIDA, VALOR QUANDO LEVA DANO, VALOR QUANDO RECUPERA VIDA
    public static int Morreu = 0;                   // 1=MORTO, 0=VIVO
    
    // TEXTO E IMAGEM
    private Text Saude;                                                      //RECEBE O TEXTO ONDE ESCREVE O ATUAL ESTADO
    //public Image Cora1, Cora2, Cora3;                                       //IMAGENS DOS CORAÇÕES PARA MOSTRAR QUE PERDEU VIDA
    private GameObject cora1, cora2, cora3;

    // ANIMAÇÃO
    public static int damage = 0;               // CONTROLE DE ANIMAÇÃO DE HIT


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
            ControlaAudio.instance.PlaySom(1);              // Gerenciador de Áudio
            ControlaPaineis.instance.BarbeiroTocou();
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
        if (ValorAtual >= 0)
        {
            ValorAtual -= Dano;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
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
        Saude = GameObject.Find("EstadoSaude_text").GetComponent<Text>();
        cora1 = GameObject.Find("Coracao1");
        cora2 = GameObject.Find("Coracao2");
        cora3 = GameObject.Find("Coracao3");

        if (ValorAtual == 3)
        {
            Saude.text = "Saudável";
            cora1.gameObject.SetActive(true);
            cora2.gameObject.SetActive(true);
            cora3.gameObject.SetActive(true);
        }

        if (ValorAtual == 2)
        {
            Saude.text = "Doente";
            cora3.gameObject.SetActive(false);
        }

        if (ValorAtual == 1)
        {
            Saude.text = "Muito Doente";
            cora2.gameObject.SetActive(false);
        }

        if (ValorAtual == 0)
        {
            Saude.text = "Perdeu";
            Morreu = 1;
            cora1.gameObject.SetActive(false);
        }
    }
}
