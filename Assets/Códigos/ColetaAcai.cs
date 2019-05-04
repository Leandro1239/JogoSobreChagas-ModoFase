// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// CLASSE
public class ColetaAcai : MonoBehaviour
{
    //VARIÁVEIS
    public int AcaiFase;                                             //AÇAI
    public Text Coleta_Fase;                                        //TEXTO

    // VERIFICA SE PODE ACABAR A FASE
    public void OnCollisionEnter2D(Collision2D Pass)
    {
        if (Pass.gameObject.CompareTag("Saida"))
        {
            if (AcaiFase >= 5)
            {
                UIManager.instance.PassLevelUI();
            }
        }
    }

    // VERIFICA COLISÃO E COLETA E CONTA AÇAI
    public void OnTriggerEnter2D(Collider2D Coletar)                    
    {
        if (Coletar.gameObject.CompareTag("Coletor"))
        {
            ColectManager.instance.PegouAcai(1);                        //CHAMA O METODO 'PegouAcai' DA CLASSE 'ColectManager' E CONTA +1 EM SEU ARGUMENTO, ACUMULANDO PARA O TOTAL RESGATADO
            Destroy(Coletar.gameObject);                                //DESTROI O "Coletor", QUE É A TAG DO ACAI
            AcaiFase += 1;                                              //CONTA O AÇAI OBTIDO NA FASE
            Coleta_Fase.text = AcaiFase.ToString();                     //MOSTRA EM TEXTO 
        }
    }
}
