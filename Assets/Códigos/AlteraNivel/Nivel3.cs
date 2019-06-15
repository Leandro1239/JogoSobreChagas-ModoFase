﻿using UnityEngine;

public class Nivel3 : MonoBehaviour
{
    public static Nivel3 instance;                     //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES            
    public static int AcaiDesseNivel;

    //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    void Awake()
    {
        instance = this;
    }

    //FICA SEMPRE VERIFICANDO MUDANÇA NA VARIAVEL 'AcaiFase' e atribuindo a 'AcaiDesseNivel'
    public void Update()
    {
        AcaiDesseNivel = Somador.AcaiFase;
    }

    //VERIFICA COLISÃO COM O PLAYER 
    public void OnCollisionEnter2D(Collision2D Pass)
    {
        if (Pass.gameObject.CompareTag("Player"))
        {
            if (AcaiDesseNivel >= 10)
            {
                UIManager.instance.PassLevelUI();            //CHAMA O MENU DE PASSAR DE NÍVEL
            }
        }
    }
}