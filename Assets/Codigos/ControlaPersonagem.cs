using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaPersonagem : MonoBehaviour
{
    EncontraJogador EncontraJogador_R = new EncontraJogador();

    // =========================== TROCA DE PERSONAGEM ======================= \\
    public GameObject player1, player2;
    private GameObject achaJogador;
    
    private Scene cenaAtual;                // SABER QUAL CENA ESTÁ
    private bool jogadorAtivado;

    // ========================= ATIVA O PERSONAGEM ======================== \\
    public void Update(){
        // PEGA O PERSONAGEM ESCOLHIDO NO MENU E CRIA ELE NA FASE DO JOGO
            cenaAtual = SceneManager.GetActiveScene();      // PEGA A CENA ATUAL

            // CASO ESTEJA NA FASE DESEJADA, PROCURA O LOCAL DE CRIAÇÃO, COLOCA O JOGADOR LÁ E TROCA DE NOME
            if (cenaAtual.name  == "Fase-1" && jogadorAtivado == false){
                // INSTANCIA O JOGADOR 1 PARA A POSIÇÃO DO GAMEOBJECT DENTRO DA CENA
                if(EncontraJogador_R.escolheu == 1){
                    player1.SetActive(true);
                    achaJogador = GameObject.Find("CriaJogador");
                    achaJogador = Instantiate(player1, achaJogador.transform.position, achaJogador.transform.rotation);           
                    achaJogador.name = "Player";
                    jogadorAtivado = true;
                }

                // INSTANCIA O JOGADOR 1 PARA A POSIÇÃO DO GAMEOBJECT DENTRO DA CENA
                if(EncontraJogador_R.escolheu == 2 ){
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
}
