using UnityEngine.UI;
using UnityEngine;

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

    // ====================== NÃO DESTROI O OBJETO =================== \\
    void Awake()    
    {
        // COMEÇA A MUSICA
        PlayMusica(0);
        AtualizaBarbeiro();        

        // TIRAR DOS COMENTÁRIOS PARA RESETAR OS VALORES
         toqueBarbeiro *= 0; painelBarbeiro *= 0; Salva(toqueBarbeiro);

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

    //====================== CONTAGEM DE PRIMEIRO TOQUE ====================== \\
    //tocou É A VARIAVEL CRIADA PARA COMUNICAÇÃO ENTRE CÓDIGOS ATRAVÉS DO ARGUMENTO
    public void BarbeiroTocou()
    {
            painelBarbeiro = 1;
            toqueBarbeiro ++ ;
            Salva(toqueBarbeiro);                                   //SALVA
    }

    //GUARDA O VALOR DA VARIÁVEL NA CHAVE 'AcaiSalvo'
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

    // LIGA OU DESLIGA
    public void LigaDesliga(){
        if (ligaSom){
            musicaBG.volume = 0f;
            sons.volume = 0f;
            ligaSom = false;
        }
        else{
            musicaBG.volume = 1f;
            sons.volume = 1f;
            ligaSom = true;
        }
    }
}
