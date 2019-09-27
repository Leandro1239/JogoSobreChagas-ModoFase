using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Start() {
        // ControlaAudio.instance.PlayMusica(0);
        // ControlaPaineis.instance.AtualizaToqueBarbeiro();
    }

    // ====================== NÃO DESTROI O OBJETO =================== \\
    void Awake()    
    {
        if (instance == null)                                   //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
