// BIBLIOTECAS
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    public void LigaSom(){
        GameManager.instance.Liga();
    }

    public void DesligaSom(){
        GameManager.instance.Desliga();
    }

    public void OnOffSom(){
        GameManager.instance.LigaDesliga();
    }
}
