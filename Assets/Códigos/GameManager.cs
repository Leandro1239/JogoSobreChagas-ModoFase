﻿// BIBLIOTECAS
using UnityEngine;

// CLASSE
public class GameManager : MonoBehaviour
{
    //VARIÁVEIS
    public static GameManager instance;

    //REALIZA ISSO LOGO AO INICIAR
    void Awake()    
    {
        if (instance == null)                                //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //REALIZA ISSO LOGO AO INICIAR
    private void Start()
    {
        ColectManager.instance.GameStartScore();            //INICIA O MÉTODO 'GameStartScore' DA CLASSE 'ColectManager'
    }

    //MÉTODO QUE REPETE SEMPRE
    void Update()
    {
        ColectManager.instance.UpdateScore();               //INICIA O MÉTODO 'UpdateScore' DA CLASSE 'ColectManager'
        UIManager.instance.UpdateUI();                      //INICIA O MÉTODO 'UpdateUI' DA CLASSE 'UIManager'
    }

    //MÉTODO QUE CHAMA UM MÉTODO DE OUTRA CLASSE
    public void GameOver()
    {
        UIManager.instance.GameOverUI();
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
