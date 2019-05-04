using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    private Text Coleta_Total;
    public GameObject PainelLose, PainelWin, PainelPause;


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

    void Carrega (Scene cena, LoadSceneMode modo)
    {
        Coleta_Total = GameObject.Find("TotalAçai_text").GetComponent<Text>();        //PROCURA SOZINHO O TEXTO
        LigaDesligaPainel();
        PainelLose = GameObject.Find("Panel - Lose");
        PainelWin = GameObject.Find("Panel - Win");
        PainelPause = GameObject.Find("Panel - Pause");
    }

    public void UpdateUI()
    {
        Coleta_Total.text = ColectManager.instance.AcaiTotal.ToString();
    }

    public void GameOverUI()
    {
        PainelLose.SetActive(true);
        Time.timeScale = 0;
    }

    public void PassLevelUI()
    {
        PainelWin.SetActive(true);
        Time.timeScale = 0;
    }

    public void PauseUI()
    {
        PainelPause.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueUI()
    {
        PainelPause.SetActive(false);
        Time.timeScale = 1;
    }

    void LigaDesligaPainel()
    {
        StartCoroutine(Tempo());
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(0.001f);
        PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);
    }

    public void DesativaPainel()
    {
        PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);
    }
}
