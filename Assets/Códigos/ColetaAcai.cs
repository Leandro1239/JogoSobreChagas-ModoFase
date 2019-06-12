// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// COLETA O AÇAI EM CADA FASE
public class ColetaAcai : MonoBehaviour
{
    //VARIÁVEIS
    public static ColetaAcai Instance;                              //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    public static int Total = 0, AcaiFase = 0;                      //AÇAI
    public Text Coleta_Fase;                                        //TEXTO

    //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    void Awake()
    {
        Instance = this;                                            
    }

    public void Update()
    {
        GuardaValor();
    }

    public void GuardaValor()
    {
        Total = Contador.AcaiTotal + AcaiFase;
    }

    // VERIFICA COLISÃO E COLETA E CONTA AÇAI
    public void OnTriggerEnter2D(Collider2D Coletar)                    
    {
        if (Coletar.gameObject.CompareTag("Coletor"))
        {
            //Contador.instance.PegouAcai(1);                             //CHAMA O METODO 'PegouAcai' DA CLASSE 'ColectManager' E CONTA +1 EM SEU ARGUMENTO, ACUMULANDO PARA O TOTAL RESGATADO
            Destroy(Coletar.gameObject);                                //DESTROI O "Coletor", QUE É A TAG DO ACAI
            AcaiFase += 1;                                              //CONTA O AÇAI OBTIDO NA FASE
            Coleta_Fase.text = AcaiFase.ToString();                     //MOSTRA EM TEXTO 
        }
    }
}
