using UnityEngine;

public class Nivel1 : MonoBehaviour
{
    Somador Somador_R = new Somador();

    public static int AcaiDesseNivel, Venceu1;
    public static bool Passou1 = false;

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
            if (AcaiDesseNivel >= 5)
            {
                Venceu1 = 1;
                Passou1 = true;
            }
        }
    }
}
