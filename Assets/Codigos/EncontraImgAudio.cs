﻿using UnityEngine.UI;
using UnityEngine;

public class EncontraImgAudio : MonoBehaviour
{
    public static EncontraImgAudio instance;
    //public Image imgOn, imgOff;

    public void LigaDesligaSom(){
         ControlaAudio.instance.OnOffSom(); 
    }
}