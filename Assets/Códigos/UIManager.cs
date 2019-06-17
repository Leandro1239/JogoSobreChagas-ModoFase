using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

//MOSTRA AS COISAS NA TELA
public class UIManager : MonoBehaviour
{
    //VARIÁVEIS
    public static UIManager instance;                               //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    private string Coleta_Total, Play_Total;
    private Text CT, PT;
    private GameObject PainelLose, PainelWin, PainelPause, PainelTutorial;

    //NÃO DESTROI O OBJETO
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += Carrega;
    }

    //PEGA AS STRINGS, DÁ FORMATO PARA ELAS E COLOCA ELAS NO TEXTO PARA SER MOSTRADO NO MENU
    public void AtualizaTXT()
    {
        Coleta_Total = string .Format("{0}", Contador.instance.AcaiTotal);
        CT = GameObject.Find("CQts_txt").GetComponent<Text>();
        CT.text = Coleta_Total;
        Play_Total = string.Format("{0}", Contador.instance.PlayTotal);
        PT = GameObject.Find("PQts_txt").GetComponent<Text>();
        PT.text = Play_Total;
    }

    //CARREGA SEMPRE NO INICIO, ENCONTRA OS PAINEIS SOZINHO
    public void Carrega (Scene cena, LoadSceneMode modo)
    {
        DesligaPainel();
        PainelLose = GameObject.Find("Panel - Lose");
        PainelWin = GameObject.Find("Panel - Win");
        PainelPause = GameObject.Find("Panel - Pause");
        PainelTutorial = GameObject.Find("Panel - Tutorial");
    }

    // ATIVA PAINEL DE LOSE E PAUSA O TEMPO
    public void GameOverUI()
    {
        PainelLose.SetActive(true);
        Time.timeScale = 0;
    }

    //ATIVA PAINEL DE PRÓXIMO NÍVEL E PAUSA O TEMPO
    public void PassLevelUI()
    {
        PainelWin.SetActive(true);
        Time.timeScale = 0;
    }

    // ATIVA PAINEL DE PAUSE E PAUSA
    public void PauseUI()
    {
        PainelPause.SetActive(true);
        Time.timeScale = 0;
    }

    // ATIVA PAINEL DE TUTORIAL E PAUSA
    public void Tutorial()
    {
        PainelTutorial.SetActive(true);
        Time.timeScale = 0;
    }

    // DESATIVA PAINEL DE PAUSE E CONTINUA
    public void ContinueUI()
    {
        Time.timeScale = 1;
    }

    // MÉTODO QUE DESLIGA TODOS OS PAINEIS, LIMPA TELA
    // CHAMA UMA FUNÇÃO PARA DESATIVAR OS PAINEIS 
    public void DesligaPainel()
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
