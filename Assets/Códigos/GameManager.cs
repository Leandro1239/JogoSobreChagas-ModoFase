using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;           //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    
    // ================== CONTROLA PRIMEIRA VEZ NO JOGO ====================== \\
    // SÓ VAI ATIVAR O PAINEL DE AVISO SE FOR ZERO, SE FOR 1 SIGNIFICA QUE JA FOI ATIVADO.
    public int ControleTutorial = 0, ControleColeta = 0, ControleDano = 0;  

    // =========================== Painel barbeiro ========================= \\
    public int toqueBarbeiro = 0, painelBarbeiro = 0;  // ATIVA PAINEL DE PRIMEIRO TOQUE NO BARBEIRO
    
    // ============================= AUDIOS ============================== \\
    public bool ligaSom = true;

    // Músicas
    public AudioClip[] clipsMusica;
    public AudioSource musicaBG;  

    // Sons
    public AudioClip[] clipsSons;
    public AudioSource sons;

    // =========================== TROCA DE PERSONAGEM ======================= \\
    public GameObject player1, player2;
    private GameObject achaJogador;
    
    private Scene cenaAtual;                // SABER QUAL CENA ESTÁ
    private bool jogadorAtivado;

    // =========================== TRADUÇÃO =========================== \\
    public int controleTraducao;

    // ====================== NÃO DESTROI O OBJETO =================== \\
    void Awake()    
    {
        // COMEÇA A MUSICA
        PlayMusica(0);
        AtualizaBarbeiro();        

        // TIRAR DOS COMENTÁRIOS PARA RESETAR OS VALORES
        // toqueBarbeiro *= 0; painelBarbeiro *= 0; Salva(toqueBarbeiro);

        if (instance == null)                                   //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update(){
    // ========================= ATIVA O PERSONAGEM ======================== \\
    // PEGA O PERSONAGEM ESCOLHIDO NO MENU E CRIA ELE NA FASE DO JOGO
        cenaAtual = SceneManager.GetActiveScene();      // PEGA A CENA ATUAL

        // CASO ESTEJA NA FASE DESEJADA, PROCURA O LOCAL DE CRIAÇÃO, COLOCA O JOGADOR LÁ E TROCA DE NOME
        if (cenaAtual.name  == "Fase-1" && jogadorAtivado == false){
            // INSTANCIA O JOGADOR 1 PARA A POSIÇÃO DO GAMEOBJECT DENTRO DA CENA
            if( EscolhePlayer.escolheu == 1){
                player1.SetActive(true);
                achaJogador = GameObject.Find("CriaJogador");
                achaJogador = Instantiate(player1, achaJogador.transform.position, achaJogador.transform.rotation);           
                achaJogador.name = "Player";
                jogadorAtivado = true;
            }

            // INSTANCIA O JOGADOR 1 PARA A POSIÇÃO DO GAMEOBJECT DENTRO DA CENA
            if(EscolhePlayer.escolheu == 2 ){
                player2.SetActive(true);
                achaJogador = GameObject.Find("CriaJogador");
                achaJogador = Instantiate(player2, achaJogador.transform.position, achaJogador.transform.rotation);
                achaJogador.name = "Player";
                jogadorAtivado = true;
            }
        }
        if (cenaAtual.name  == "Menu" || cenaAtual.name  == "SelecionarFases"){
            jogadorAtivado = false;
        }
    }

    // private void FixedUpdate() {
    // // ============================ TRADUCAO ============================== \\
    // if (controleTraducao == 0){
    //     Tradutor.instance.SetEnglish();
    // }else if(controleTraducao == 1){
    //     Tradutor.instance.SetPortuguese();
    // }
    // }

    //====================== CONTAGEM DE PRIMEIRO DANO ====================== \\
    //tocou É A VARIAVEL CRIADA PARA COMUNICAÇÃO ENTRE CÓDIGOS ATRAVÉS DO ARGUMENTO
    public void BarbeiroTocou()
    {
            painelBarbeiro = 1;
            toqueBarbeiro ++ ;
            Salva(toqueBarbeiro);                                   //SALVA
    }

    //GUARDA O VALOR DA VARIÁVEL NA CHAVE 'Tocou'
    public void Salva(int conta)
    {
        PlayerPrefs.SetInt("Tocou", conta);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'AcaiSalvo'
    public void AtualizaBarbeiro()
    {
        if (PlayerPrefs.HasKey("Tocou"))                
        {
            toqueBarbeiro = PlayerPrefs.GetInt("Tocou");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'AcaiTotal'
        }
        else
        {
            toqueBarbeiro = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("Tocou", toqueBarbeiro);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }
    
    // ========================== METODOS DOS AUDIO ========================= \\
    // SONS
    public void PlaySom(int index){
        sons.clip = clipsSons[index];
        sons.Play ();
    }

    // Músicas
    public void PlayMusica(int indexx){
        musicaBG.clip = clipsMusica[indexx];
        musicaBG.Play ();
    }

    // LIGA O SOM
    public void Liga(){
        musicaBG.volume = 1f;
        sons.volume = 1f;
        ligaSom = true;
    }

    // DESLIGA O SOM
    public void Desliga(){
        musicaBG.volume = 0f;
        sons.volume = 0f;
        ligaSom = false;
    }
}
