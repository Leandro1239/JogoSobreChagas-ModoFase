﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel7 : MonoBehaviour
{
    public static Nivel7 instance;                     //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES            
    public static int AcaiDesseNivel, Venceu7;
    public static bool Passou7 = false;

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
            if (AcaiDesseNivel >= 20)
            {
                Venceu7 = 1;
                Passou7 = true;
            }
        }
    }
}