using UnityEngine;

public class EncontraImgAudio : MonoBehaviour
{
    ControlaAudio ControlaAudio_R = new ControlaAudio();

    public int liga_Desliga = 1, estadoAtual;
    //public Image imgOn, imgOff;

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
            ControlaAudio_R.Liga();
        }
        if (estadoAtual == 0)  
        {
            liga_Desliga = 0;
            ControlaAudio_R.Desliga();                                
        }
    }

    // MÉTODO QUE LIGA E DESLIGA O SOM E ALTERA A IMAGEM
    public void OnOffSom(){
        switch (liga_Desliga)
        {
            case 0: liga_Desliga = 1;
                    Salva(liga_Desliga);
                    ControlaAudio_R.Liga();
                    Debug.Log("caso 0");
                    break;

            case 1: liga_Desliga = 0;
                    Salva(liga_Desliga);
                    ControlaAudio_R.Desliga();
                    Debug.Log("caso 1");
                    break;
        }
    }
}
