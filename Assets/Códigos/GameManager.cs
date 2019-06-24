// BIBLIOTECAS
using UnityEngine;

//GERENCIA O JOGO
public class GameManager : MonoBehaviour
{
    //VARIÁVEIS
    public static GameManager instance;                         //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 


    //REALIZA ISSO LOGO AO INICIAR
    void Awake()    
    {
        if (instance == null)                                   //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        Contador.instance.AtualizaAcai();
        Contador.instance.AtualizaPlay();      
    }
}
