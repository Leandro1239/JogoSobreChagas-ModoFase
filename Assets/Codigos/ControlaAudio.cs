// BIBLIOTECAS
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{    
    //EncontraImgAudio EncontraImgAudio_R = new EncontraImgAudio();

    // Músicas
    public AudioClip[] clipsMusica;
    public AudioSource musicaBG;  

    // Sons
    public AudioClip[] clipsSons;
    public AudioSource sons;

    // COMEÇA ATIVANDO A MÚSICA
    public void Start() {
        PlayMusica(0);
       // EncontraImgAudio_R.AtualizaEstadoSom();
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
}
