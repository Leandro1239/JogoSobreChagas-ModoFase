// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaAudio : MonoBehaviour
{
    public static ControlaAudio instance;           //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    private int controle = 0;
    
    // Músicas
    public AudioClip[] clipsMusica;
    public AudioSource musicaBG;  

    // Sons
    public AudioClip[] clipsSons;
    public AudioSource sons;

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
        switch (controle)
        {
            case 0: Desliga();
                    EncontraImgAudio.instance.imgOn.fillAmount = 1;
                    EncontraImgAudio.instance.imgOff.fillAmount = 0;
                    controle = 1;
                    break;
            case 1: Liga();
                    EncontraImgAudio.instance.imgOn.fillAmount = 1;
                    EncontraImgAudio.instance.imgOff.fillAmount = 0;
                    controle = 0;
                    break;
        }
    }
}
