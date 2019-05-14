using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    //VARIÁVEIS
    public static UIManager instance;                               //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    private Text Coleta_Total;
    public GameObject PainelLose, PainelWin, PainelPause, PainelTutorial;

    //NÃO DESTROI O OBJETO
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    //CARREGA SEMPRE NO INICIO
    void Carrega (Scene cena, LoadSceneMode modo)
    {
        LigaDesligaPainel();
        PainelLose = GameObject.Find("Panel - Lose");
        PainelWin = GameObject.Find("Panel - Win");
        PainelPause = GameObject.Find("Panel - Pause");
        PainelTutorial = GameObject.Find("Panel - Tutorial");
    }

    // ATIVA PAINEL DE LOSE E PAUSA O TEMPO
    public void GameOverUI()
    {
        PainelLose.SetActive(true);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);
        PainelTutorial.SetActive(false);
        Time.timeScale = 0;
    }

    //ATIVA PAINEL DE PRÓXIMO NÍVEL E PAUSA O TEMPO
    public void PassLevelUI()
    {
        PainelWin.SetActive(true);
        PainelLose.SetActive(false);
        PainelPause.SetActive(false);
        PainelTutorial.SetActive(false);
        Time.timeScale = 0;
    }

    // ATIVA PAINEL DE PAUSE E PAUSA
    public void PauseUI()
    {
        PainelPause.SetActive(true);
        PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelTutorial.SetActive(false);
        Time.timeScale = 0;
    }

    public void Tutorial()
    {
        PainelTutorial.SetActive(true);
        PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);
        Time.timeScale = 0;
    }

    // DESATIVA PAINEL DE PAUSE E CONTINUA
    public void ContinueUI()
    {
        PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);
        PainelTutorial.SetActive(false);
        Time.timeScale = 1;
    }

    // CHAMA UMA FUNÇÃO PARA DESATIVAR OS PAINEIS 
    public void LigaDesligaPainel()
    {
        StartCoroutine(Tempo());
    }

    // FAZ COM QUE O CÓDIGO ACHE OS PAINEIS
    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(0.01f);
        PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);
        PainelTutorial.SetActive(false);
    }
}
