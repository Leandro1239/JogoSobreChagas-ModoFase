// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

public class ControlaAudio : MonoBehaviour
{
    private int controle = 0;
    public Image imgOn, imgOff;

    // COMEÇA COM A IMAGEM DO SOM LIGADA
    private void Start() {
        imgOn.fillAmount = 1;
        imgOff.fillAmount = 0;
    }

    // MÉTODO QUE LIGA E DESLIGA O SOM PEGANDO DE OUTRA CLASSE E DESATIVA A IMAGEM DO MENU
    public void OnOffSom(){
        switch (controle)
        {
            case 0: GameManager.instance.Desliga();
                    controle = 1;
                    imgOn.fillAmount = 0;
                    imgOff.fillAmount = 1;
                    break;
            case 1: GameManager.instance.Liga();
                    controle = 0;
                    imgOn.fillAmount = 1;
                    imgOff.fillAmount = 0;
                    break;
        }
    }
}
