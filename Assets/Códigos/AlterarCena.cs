// BIBLIOTECAS
using UnityEngine;
using UnityEngine.SceneManagement;

// CLASSE
public class AlterarCena : MonoBehaviour {            //Troca de cenário de acordo com o número somado

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

    public void Avançar1()
    {
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

    //FECHA O JOGO
    public void Sair ()             
    {
        Application.Quit();
    }

    //RECARREGA A CENA
    public void Repetir()           
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UIManager.instance.DesativaPainel();
        Time.timeScale = 1;
    }

    public void Pause()
    {
        UIManager.instance.PauseUI();
    }

    public void Continue()
    {
        UIManager.instance.ContinueUI();
    }
}
