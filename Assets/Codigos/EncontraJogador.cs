using UnityEngine;
using UnityEngine.UI;

public class EncontraJogador : MonoBehaviour
{  
    private GameObject escolha1, escolha2, aparece, esconde;    // JOGADORES E OBJETOS
    public int escolheu = 1;      // VARIAVEIS DE CONTROLE DE TROCA
    public Button J1, J2; 

    public void jogador1(){
        escolheu = 1;
        J1.interactable = false;
        J2.interactable = true;
    }

    public void jogador2(){
        escolheu = 2;
        J1.interactable = true;
        J2.interactable = false;
    }
}
