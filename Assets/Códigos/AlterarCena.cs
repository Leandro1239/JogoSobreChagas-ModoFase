// BIBLIOTECAS
using UnityEngine;
using UnityEngine.SceneManagement;

// FAZ MÉTODOS DE TROCAR DE CENÁRIO
public class AlterarCena : MonoBehaviour {            //Troca de cenário de acordo com o número somado

    public static AlterarCena instance;

    // VOLTAR

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
    // AVANÇAR

    public void Avançar1()
    {
        ColetaAcai.AcaiFase = 0;
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
        ColetaAcai.AcaiFase = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Continue();
    }

    //CHAMA O PAINEL DE PAUSE
    public void Pause()
    {
        UIManager.instance.PauseUI();
    }

    //CHAMA O PAINEL DE CONTINUE
    public void Continue()
    {
        UIManager.instance.ContinueUI();
    }
}
