using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel9 : MonoBehaviour
{
    Somador Somador_R = new Somador();          
    public static int AcaiDesseNivel, Venceu9;
    public static bool Passou9 = false;

    //FICA SEMPRE VERIFICANDO MUDANÇA NA VARIAVEL 'AcaiFase' e atribuindo a 'AcaiDesseNivel'
    public void Update()
    {
        AcaiDesseNivel = Somador_R.AcaiFase;
    }

    //VERIFICA COLISÃO COM O PLAYER 
    public void OnCollisionEnter2D(Collision2D Pass)
    {
        if (Pass.gameObject.CompareTag("Player"))
        {
            if (AcaiDesseNivel >= 25)
            {
                Venceu9 = 1;
                Passou9 = true;
            }
        }
    }
}
