// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// COLETA O AÇAI EM CADA FASE
public class Somador : MonoBehaviour
{
    // VARIÁVEIS
    public static Somador Instance;                              // INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    public static int AcaiFase = 0;                              // AÇAI

    // TEXTOS NA TELA
    public Text Coleta_Fase;
    private Text CT, PT;

    // VARIAVEL QUE ESCREVE UM TEXTO
    private string Coleta_Total, Play_Total;

    // VERIFICA COLISÃO E COLETA E CONTA AÇAI
    public void OnTriggerEnter2D(Collider2D Coletar)              
    {
        if (Coletar.gameObject.CompareTag("Coletor"))
        {
            ControlaAudio.instance.PlaySom(0);                      // ATIVA O GERENCIADOR DE ÁUDIO
            Contador.instance.PegouAcai(1);                       // CHAMA O METODO 'PegouAcai' DA CLASSE 'ColectManager' E CONTA +1 EM SEU ARGUMENTO, ACUMULANDO PARA O TOTAL RESGATADO
            Destroy(Coletar.gameObject);                          // DESTROI O "Coletor", QUE É A TAG DO ACAI
            AcaiFase += 1;                                        // CONTA O AÇAI OBTIDO NA FASE
            Coleta_Fase = GameObject.Find("FaseAçai_text").GetComponent<Text>();
            Coleta_Fase.text = AcaiFase.ToString();               // MOSTRA EM TEXTO 
        }
    }

    // SOMA 1 NO MÉTODO 'Jogou' DO CONTADOR, APLICADO NO BOTÃO DE PLAY E DE RESET PARA CONTAR JOGADAS
    public void SomaJogou()
    {
        Contador.instance.Jogou(1);
    }

    // ATUALIZA OS VALORES DOS RECORDES NOS TEXTOS DE MENU
    public void Recorde()
    {
        // VALORES DE COLETA
        Coleta_Total = string.Format("{0}", Contador.instance.AcaiTotal);
        CT = GameObject.Find("CQts_txt").GetComponent<Text>();
        CT.text = Coleta_Total;
        
        // VALORES DE JOGADAS
        Play_Total = string.Format("{0}", Contador.instance.PlayTotal);
        PT = GameObject.Find("PQts_txt").GetComponent<Text>();
        PT.text = Play_Total;
    }
}
