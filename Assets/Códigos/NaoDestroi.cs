using UnityEngine;

//CÓDIGO QUE FAZ NÃO DESTRUIR O OBJETO EM QUE ELE ESTÁ
public class NaoDestroi : MonoBehaviour
{
    //VARIÁVEIS
    public static NaoDestroi instance;                         //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 

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
}
