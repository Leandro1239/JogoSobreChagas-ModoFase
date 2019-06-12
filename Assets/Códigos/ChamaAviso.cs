// BIBLIOTECAS
using UnityEngine;

//GERENCIA OS PAINEIS
public class ChamaAviso : MonoBehaviour
{
    public static ChamaAviso Instance;
    int Tutorial = 0;

    //NUNCA DESTROI O OBJETO
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // CHAMA O PAINEL DE TUTORIAL SOMENTE UMA VEZ
        if (Tutorial == 0)
        {
            GameManager.instance.AvisoTutorial();
            Tutorial = 1;
        }

    }

    public void Continue()
    {
        UIManager.instance.ContinueUI();
    }
}
