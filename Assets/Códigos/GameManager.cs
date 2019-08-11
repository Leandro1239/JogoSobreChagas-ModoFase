using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;           //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
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
