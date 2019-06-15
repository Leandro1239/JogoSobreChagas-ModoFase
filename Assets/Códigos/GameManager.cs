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

    //MÉTODO QUE CHAMA UM MÉTODO DE OUTRA CLASSE
    public void GameOver()
    {
        UIManager.instance.GameOverUI();
    }

    //MÉTODO QUE CHAMA UM MÉTODO DE OUTRA CLASSE
    public void AvisoTutorial()
    {
        UIManager.instance.Tutorial();
    }

    //MÉTODO QUE CHAMA UM MÉTODO DE OUTRA CLASSE
    public void PassLevel()
    {
        UIManager.instance.PassLevelUI();
    }

    //MÉTODO QUE CHAMA UM MÉTODO DE OUTRA CLASSE
    public void Pause()
    {
        UIManager.instance.PauseUI();
    }
}
