using UnityEngine;
using UnityEngine.UI;
using DFTGames.Localization;

public class Tradutor : MonoBehaviour
{
    public static Tradutor instance;
    public int lingua = 0;
    public Button PT, EN; 
    #region Public Methods

    private void Update() {
    // ============================ TRADUCAO ============================== \\
        if (lingua == 0){
            SetEnglish();
            EN.interactable = false;
            PT.interactable = true;
        }
        
        if(lingua == 1){
            SetPortuguese();
            EN.interactable = true;
            PT.interactable = false;
        }
    }
    
    public void Ingles()
    {
        lingua = 0;
    }

    public void Portugues()
    {
        lingua = 1;
    }

    public void SetEnglish()
    {
        Localize.SetCurrentLanguage(SystemLanguage.English);
        LocalizeImage.SetCurrentLanguage();
    }

    public void SetPortuguese()
    {
        Localize.SetCurrentLanguage(SystemLanguage.Portuguese);
        LocalizeImage.SetCurrentLanguage();
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
