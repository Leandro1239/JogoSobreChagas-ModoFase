using UnityEngine;

public class Nivel2 : MonoBehaviour
{
    Somador Somador_R = new Somador();

    public static int AcaiDesseNivel, Venceu2;
    public static bool Passou2 = false;

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
            if (AcaiDesseNivel >= 7)
            {
                Venceu2 = 1;
                Passou2 = true;
            }
        }
    }
}
