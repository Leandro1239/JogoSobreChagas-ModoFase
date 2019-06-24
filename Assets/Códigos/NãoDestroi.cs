using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NãoDestroi : MonoBehaviour
{
    public static NãoDestroi instance;                         //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 

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
