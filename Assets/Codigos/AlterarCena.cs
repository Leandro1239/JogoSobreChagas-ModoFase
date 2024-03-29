﻿// BIBLIOTECAS
using UnityEngine;
using UnityEngine.SceneManagement;


// FAZ MÉTODOS DE TROCAR DE CENÁRIO
public class AlterarCena : MonoBehaviour //Troca de cenário de acordo com o número somado
{            
    Somador Somador_R = new Somador();
    Contador Contador_R = new Contador();

    // ========================== VOLTAR ================================== \\
    public void Voltar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Time.timeScale = 1;
    }

    public void Voltar2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        Time.timeScale = 1;
    }

    public void Voltar3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
        Time.timeScale = 1;
    }

    public void Voltar4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
        Time.timeScale = 1;
    }

    public void Voltar5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 5);
        Time.timeScale = 1;
    }

    public void Voltar6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 6);
        Time.timeScale = 1;
    }

    public void Voltar7()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 7);
        Time.timeScale = 1;
    }

    public void Voltar8()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 8);
        Time.timeScale = 1;
    }

    public void Voltar9()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 9);
        Time.timeScale = 1;
    }

    public void Voltar10()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 10);
        Time.timeScale = 1;
    }
    
    // ========================== AVANÇAR ================================== \\
    public void Avançar1()
    {
        Somador_R.AcaiFase = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1;
    }

    public void Avançar2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        Time.timeScale = 1;
    }

    public void Avançar3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
        Time.timeScale = 1;
    }

    public void Avançar4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
        Time.timeScale = 1;
    }

    public void Avançar5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
        Time.timeScale = 1;
    }

    public void Avançar6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);
        Time.timeScale = 1;
    }

    public void Avançar7()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);
        Time.timeScale = 1;
    }

    public void Avançar8()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);
        Time.timeScale = 1;
    }

    public void Avançar9()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
        Time.timeScale = 1;
    }

    public void Avançar10()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);
        Time.timeScale = 1;
    }

    //FECHA O JOGO
    public void Sair ()             
    {
        Application.Quit();
    }

    //RECARREGA A CENA
    public void Repetir()           
    {
        Somador_R.AcaiFase = 0;
        Contador_R.Jogou(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
