using UnityEngine;

public class Nivel3 : MonoBehaviour
{
    Somador Somador_R = new Somador();          
    public static int AcaiDesseNivel, Venceu3;
    public static bool Passou3 = false;

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
            if (AcaiDesseNivel >= 10)
            {
                Venceu3 = 1;
                Passou3 = true;
            }
        }
    }
}