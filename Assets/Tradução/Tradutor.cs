using UnityEngine;
using DFTGames.Localization;

public class Tradutor : MonoBehaviour
{
    public static Tradutor instance; 
    #region Public Methods

    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
        LocalizeImage.SetCurrentLanguage();
        GameManager.instance.controleTraducao = 0;
    }

    public void SetPortuguese()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Portuguese);
        LocalizeImage.SetCurrentLanguage();
        GameManager.instance.controleTraducao = 1;
    }
    
    #endregion Public Methods

//     public class ControlaBotoes : MonoBehaviour
// {
//     public static ControlaBotoes instance;
//     public Button ligaSom, desligaSom;

//     // =========================== GERENCIA DE BOTOES ======================== \\
//     public void Update() {
//         if (GameManager.instance.ligaSom == true){
//             ligaSom.interactable = false;
//             desligaSom.interactable = true;
//         }

//         if (GameManager.instance.ligaSom == false){
//             ligaSom.interactable = true;
//             desligaSom.interactable = false;
//         }  
//     }
//}

}
