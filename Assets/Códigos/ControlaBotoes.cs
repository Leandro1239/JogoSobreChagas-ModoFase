using UnityEngine.UI;
using UnityEngine;

public class ControlaBotoes : MonoBehaviour
{
    public static ControlaBotoes instance;
    public Button ligaSom, desligaSom;

    // =========================== GERENCIA DE BOTOES ======================== \\
    public void Update() {
        if (GameManager.instance.ligaSom == true){
            ligaSom.interactable = false;
            desligaSom.interactable = true;
        }

        if (GameManager.instance.ligaSom == false){
            ligaSom.interactable = true;
            desligaSom.interactable = false;
        }  
    }
}
