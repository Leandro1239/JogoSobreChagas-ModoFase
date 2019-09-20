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
        if(lingua == 0){
            SetPortuguese();
            EN.interactable = true;
            PT.interactable = false;
        }

        if (lingua == 1){
            SetEnglish();
            EN.interactable = false;
            PT.interactable = true;
        }
    }
    
    public void Ingles()
    {
        lingua = 1;
    }

    public void Portugues()
    {
        lingua = 0;
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
}
