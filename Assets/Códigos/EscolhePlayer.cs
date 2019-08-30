using UnityEngine;
using UnityEngine.UI;

public class EscolhePlayer : MonoBehaviour
{
    public static EscolhePlayer instance;
    
    private GameObject escolha1, escolha2, aparece, esconde;    // JOGADORES E OBJETOS
    private int troca = 1; 
    public static int escolheu = 1;      // VARIAVEIS DE CONTROLE DE TROCA

    // VERIFICAR A CENA QUE ESTÁ PARA INSTANCIAR O JOGADOR
    public void Update(){
        // PROCURA OS GAMEOBJECTS
        escolha1 = GameObject.Find("Jogador1");
        escolha2 = GameObject.Find("Jogador2");
        aparece = GameObject.Find("Aparece");
        esconde = GameObject.Find("Esconde");
    }

    // ALTERNA ENTRE DOIS CASOS DE ESCOLHA DE PERSONAGEM E APARECE NO MENU
    public void TrocaPersonagem(){
        switch (troca)
        {
            // PRIMEIRA ESCOLHA, MANDA O JOGADOR 1 PARA DENTRO DO CANVAS E ESCONDE O JOGADOR 2
            case 1:
                troca = 2;
                escolheu = 1;           // SERVE PARA SABER QUAL FOI A ESCOLHA FEITA
                escolha1.transform.position = new Vector3(aparece.transform.position.x, aparece.transform.position.y, aparece.transform.position.z);      
                escolha2.transform.position = new Vector3(esconde.transform.position.x, esconde.transform.position.y, esconde.transform.position.z);      
                break;

            // SEGUNDA ESCOLHA, MANDA O JOGADOR 2 PARA DENTRO DO CANVAS E ESCONDE O JOGADOR 1
            case 2:
                troca = 1;
                escolheu = 2;           // SERVE PARA SABER QUAL FOI A ESCOLHA FEITA
                escolha1.transform.position = new Vector3(esconde.transform.position.x, esconde.transform.position.y, esconde.transform.position.z); 
                escolha2.transform.position = new Vector3(aparece.transform.position.x, aparece.transform.position.y, aparece.transform.position.z);         
                break;
        }
    }
}
