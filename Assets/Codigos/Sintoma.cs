// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// TRATA OS DANOS QUE O PERSONAGEM TOMA
public class Sintoma : MonoBehaviour 
{
    ControlaAudio ControlaAudio_R = new ControlaAudio();
    ControlaPaineis ControlaPaineis_R = new ControlaPaineis();
    
    // CONTROLE DE VIDA
    public int ValorAtual = 3, Dano = 1, Energia = 1, Morreu = 0, damage = 0;   //VALOR TOTAL DA VIDA, VALOR QUANDO LEVA DANO, VALOR QUANDO RECUPERA VIDA
    
    // TEXTO E IMAGEM
    private Text Saude;                                                      //RECEBE O TEXTO ONDE ESCREVE O ATUAL ESTADO
    private GameObject cora1, cora2, cora3;

    // ============================ COLISÕES ================================= \\
    //COLISÃO COM INIMIGO
    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            // ANIMAÇÃO HIT
            damage = 1;

            // DESTROI O OBJETO E PERDE VIDA
            Destroy(Dano.gameObject);                       //DESTROI O INIMIGO QUANDO TOCA
            VidaPerde();                                    //CHAMA O METODO 'VidaPerde'
            
            // EMITE SOM E CONTA TOQUES NO BARBEIRO
            ControlaAudio_R.PlaySom(1);              // Gerenciador de Áudio
            ControlaPaineis_R.BarbeiroTocou();
        }
    }

    //COLISÃO COM REMÉDIO
    public void OnTriggerEnter2D(Collider2D Vida)                         //GANHA VIDA AO PASSAR NA BARRACA
    {
        if (Vida.gameObject.CompareTag("Vida"))
        {
            VidaGanha();                                    //CHAMA O METODO 'VidaGanha'
            Destroy(Vida.gameObject);                       //DESTROI A CURA
        }
    }

    // ========================= GERENCIA DE VIDA ========================== \\
    //MÉTODO QUE FAZ PERDER VIDA
    public void VidaPerde()                                 
    {
        if (ValorAtual >= 0)
        {
            ValorAtual -= Dano;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
    }

    //MÉTODO QUE FAZ GANHARR VIDA
    public void VidaGanha()                                 
    {
        if (ValorAtual < 3)
        {
            ValorAtual += Energia;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
    }

    // ========================== ESCREVE NA TELA =========================== \\
    //MÉTODO QUE VERIFICA O ESTADO DE SAÚDE PARA ESCREVER NA TELA
    public void EstadoSaude()                               //DIFINE TODOS OS ESTADOS E O QUE ACONTECE NELES
    {
        Saude = GameObject.Find("EstadoSaude_text").GetComponent<Text>();
        cora1 = GameObject.Find("Coracao1");
        cora2 = GameObject.Find("Coracao2");
        cora3 = GameObject.Find("Coracao3");

        if (ValorAtual == 3)
        {
            Saude.text = "Saudável";
            cora1.gameObject.SetActive(true);
            cora2.gameObject.SetActive(true);
            cora3.gameObject.SetActive(true);
        }

        if (ValorAtual == 2)
        {
            Saude.text = "Doente";
            cora3.gameObject.SetActive(false);
        }

        if (ValorAtual == 1)
        {
            Saude.text = "Muito Doente";
            cora2.gameObject.SetActive(false);
        }

        if (ValorAtual == 0)
        {
            Saude.text = "Perdeu";
            Morreu = 1;
            cora1.gameObject.SetActive(false);
        }
    }
}
