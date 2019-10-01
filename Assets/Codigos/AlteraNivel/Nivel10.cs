using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nivel10 : MonoBehaviour
{
    Somador Somador_R = new Somador();         
    public static int AcaiDesseNivel, Venceu10;
    public static bool Passou10 = false;

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
            if (AcaiDesseNivel >= 30)
            {
                Venceu10 = 1;
                Passou10 = true;
            }
        }
    }
}
