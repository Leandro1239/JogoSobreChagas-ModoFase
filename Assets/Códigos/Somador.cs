// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// COLETA O AÇAI EM CADA FASE
public class Somador : MonoBehaviour
{
    //VARIÁVEIS
    public static Somador Instance;                              //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    public static int Total = 0, AcaiFase = 0;                      //AÇAI
    public Text Coleta_Fase;                                        //TEXTO

    //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    void Awake()
    {
        Instance = this;                                            
    }

    // VERIFICA COLISÃO E COLETA E CONTA AÇAI
    public void OnTriggerEnter2D(Collider2D Coletar)                    
    {
        if (Coletar.gameObject.CompareTag("Coletor"))
        {
            Contador.instance.PegouAcai(1);                             //CHAMA O METODO 'PegouAcai' DA CLASSE 'ColectManager' E CONTA +1 EM SEU ARGUMENTO, ACUMULANDO PARA O TOTAL RESGATADO
            Destroy(Coletar.gameObject);                                //DESTROI O "Coletor", QUE É A TAG DO ACAI
            AcaiFase += 1;                                              //CONTA O AÇAI OBTIDO NA FASE
            Coleta_Fase.text = AcaiFase.ToString();                     //MOSTRA EM TEXTO 
        }
    }

    //SOMA 1 NO MÉTODO 'Jogou' DO CONTADOR, APLICADO NO BOTÃO DE PLAY E DE RESET PARA CONTAR JOGADAS
    public void SomaJogou()
    {
        Contador.instance.Jogou(1);
    }

    //ATUALIZA OS VALORES DOS RECORDES NOS TEXTOS DE MENU
    public void Recorde()
    {
        UIManager.instance.AtualizaTXT();
    }
}
