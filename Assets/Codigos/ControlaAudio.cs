// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaAudio : MonoBehaviour
{
    public static ControlaAudio instance;           //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES
    public int liga_Desliga = 1, estadoAtual;
    
    // Músicas
    public AudioClip[] clipsMusica;
    public AudioSource musicaBG;  

    // Sons
    public AudioClip[] clipsSons;
    public AudioSource sons;

    // COMEÇA ATIVANDO A MÚSICA
    public void Start() {
        PlayMusica(0);
    }
    
    // VERIFICA O ULTIMO ESTADO DA MUSICA, LIGADO OU DESLIGADO
    public void Update() {
        AtualizaEstadoSom();
    }

    // SALVA O ESTADO DA MUSICA
    public void Salva(int estado)
    {
        PlayerPrefs.SetInt("EstadoSom", estado);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'EstadoSom'
    public void AtualizaEstadoSom()
    {
        estadoAtual = PlayerPrefs.GetInt("EstadoSom");

        if (estadoAtual == 1)                
        {
            liga_Desliga = 1;    
            Liga();
        }
        if (estadoAtual == 0)  
        {
            liga_Desliga = 0;
            Desliga();                                  
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
    }

    // DESLIGA O SOM
    public void Desliga(){
        musicaBG.volume = 0f;
        sons.volume = 0f;
    }

    // MÉTODO QUE LIGA E DESLIGA O SOM E ALTERA A IMAGEM
    public void OnOffSom(){
        switch (liga_Desliga)
        {
            case 0: Liga();
                    liga_Desliga = 1;
                    Salva(liga_Desliga);
                    break;

            case 1: Desliga();
                    liga_Desliga = 0;
                    Salva(liga_Desliga);
                    break;
        }
    }
}
