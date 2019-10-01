using UnityEngine;
using UnityEngine.UI;

public class LiberaNivel : MonoBehaviour
{
    // VARIAVEIS PARA COLOCAR OS BUTOES E PARA SIMBOLIZAR A PASSAGEM DE NIVEL
    public Button Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, Level10;
    bool Passou1, Passou2, Passou3, Passou4, Passou5, Passou6, Passou7, Passou8, Passou9, Passou10;

    // RECONHECE A VARIÁVEL DE CADA CÓDIGO
    public void Start()
    {
        // VERIFICA EM CADA CÓDIGO SE PASSOU OU NÃO
        Passou1 = Nivel1.Passou1; Passou2 = Nivel2.Passou2; Passou3 = Nivel3.Passou3; Passou4 = Nivel4.Passou4; Passou5 = Nivel5.Passou5;
        Passou6 = Nivel6.Passou6; Passou7 = Nivel7.Passou7; Passou8 = Nivel8.Passou8; Passou9 = Nivel9.Passou9;
        
        // DESATIVA TODOS OS BOTÕES
        Level2.interactable = false; Level3.interactable = false; Level4.interactable = false; Level5.interactable = false; Level6.interactable = false;
        Level7.interactable = false; Level8.interactable = false; Level9.interactable = false; Level10.interactable = false;

        // CONDIÇÃO PARA LIBERAR OS NIVEIS
        if (Passou1)
        {
            Level2.interactable = true;
        }

        if (Passou2)
        {
            Level3.interactable = true;
        }

        if (Passou3)
        {
            Level4.interactable = true;
        }

        if (Passou4)
        {
            Level5.interactable = true;
        }

        if (Passou5)
        {
            Level6.interactable = true;
        }

        if (Passou6)
        {
            Level7.interactable = true;
        }

        if (Passou7)
        {
            Level8.interactable = true;
        }

        if (Passou8)
        {
            Level9.interactable = true;
        }

        if (Passou9)
        {
            Level10.interactable = true;
        }
    }
}
