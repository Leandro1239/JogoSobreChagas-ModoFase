// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// TRATA OS DANOS QUE O PERSONAGEM TOMA
public class Sintoma : MonoBehaviour {

    //VARIÁVEIS
    public static Sintoma instance;                                         //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    public int ValorAtual = 3, Dano = 1, Energia = 1, controleBarbeiro = 0;    //VALOR TOTAL DA VIDA, VALOR QUANDO LEVA DANO, VALOR QUANDO RECUPERA VIDA
    public int painelBarbeiro = 0;                              // ATIVA PAINEL DE PRIMEIRO TOQUE NO BARBEIRO
    public static int Morreu = 0;
    public Text Saude;                                                      //RECEBE O TEXTO ONDE ESCREVE O ATUAL ESTADO
    public Image Cora1, Cora2, Cora3;                                       //IMAGENS DOS CORAÇÕES PARA MOSTRAR QUE PERDEU VIDA
    public Animator anime;

    public void Start()
    {
        anime = GetComponent<Animator>();
    }

    public void Awake() 
    {
        AtualizaBarbeiro();
        
        // TIRAR DOS COMENTÁRIOS PARA RESETAR OS VALORES
        // controleBarbeiro *= 0; painelBarbeiro *= 0; Salva(controleBarbeiro);

        if (instance == null)                       
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //====================== CONTAGEM DE PRIMEIRO TOQUE ====================== \\
    //tocou É A VARIAVEL CRIADA PARA COMUNICAÇÃO ENTRE CÓDIGOS ATRAVÉS DO ARGUMENTO
    public void BarbeiroTocou(int Apanhou)
    {
        if (ValorAtual < 3 && controleBarbeiro == 0){
            painelBarbeiro = 1;
            controleBarbeiro += Apanhou;
            Salva(controleBarbeiro);                                   //SALVA
        } 
    }

    //GUARDA O VALOR DA VARIÁVEL NA CHAVE 'AcaiSalvo'
    public void Salva(int Apanhou)
    {
        PlayerPrefs.SetInt("Tocou", controleBarbeiro);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'AcaiSalvo'
    public void AtualizaBarbeiro()
    {
        if (PlayerPrefs.HasKey("Tocou"))                
        {
            controleBarbeiro = PlayerPrefs.GetInt("Tocou");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'AcaiTotal'
        }
        else
        {
            controleBarbeiro = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("Tocou", controleBarbeiro);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }



    // ============================ COLISÕES ================================= \\
    //COLISÃO COM INIMIGO
    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            anime.SetBool("Hit", true);
            GameManager.instance.PlaySom(1);              // Gerenciador de Áudio
            Destroy(Dano.gameObject);                       //DESTROI O INIMIGO QUANDO TOCA
            VidaPerde();                                    //CHAMA O METODO 'VidaPerde'
            BarbeiroTocou(1);
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
