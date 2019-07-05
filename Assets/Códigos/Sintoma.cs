// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// TRATA OS DANOS QUE O PERSONAGEM TOMA
public class Sintoma : MonoBehaviour {

    //VARIÁVEIS
    public static Sintoma instance;                                         //INICIANDO A CLASSE PARA ELA FICAR VISÍVEL PARA OUTRAS CLASSES 
    public Text Saude;                                                      //RECEBE O TEXTO ONDE ESCREVE O ATUAL ESTADO
    int ValorAtual = 3, Dano = 1, Energia = 1;                    //VALOR TOTAL DA VIDA, VALOR QUANDO LEVA DANO, VALOR QUANDO RECUPERA VIDA
    public static int Morreu = 0, DorSom = 0;
    public Animator anime;

    public void Start()
    {
        anime = GetComponent<Animator>();
    }

    //COLISÃO COM INIMIGO
    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            anime.SetBool("Idle", false);
            anime.SetBool("Run", false);
            anime.SetBool("Jump", false);
            anime.SetBool("Hit", true);
            DorSom += 1;
            Destroy(Dano.gameObject);                       //DESTROI O INIMIGO QUANDO TOCA
            VidaPerde();                                    //CHAMA O METODO 'VidaPerde'
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

    //MÉTODO QUE FAZ PERDER VIDA
    public void VidaPerde()                                 
    {
        if (ValorAtual > 0)
        {
            ValorAtual -= Dano;
            EstadoSaude();                                  //CHAMA O MÉTODO 'EstadoSaúde' PARA VALIDAR 
        }
        if (ValorAtual == 0)
        {
            Morreu = 1;
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

    //MÉTODO QUE VERIFICA O ESTADO DE SAÚDE PARA ESCREVER NA TELA
    public void EstadoSaude()                               //DIFINE TODOS OS ESTADOS E O QUE ACONTECE NELES
    {
        if (ValorAtual == 3)
        {
            Saude.text = "Saudável";
        }

        if (ValorAtual == 2)
        {
            Saude.text = "Doente";
        }

        if (ValorAtual == 1)
        {
            Saude.text = "Muito Doente";
        }
    }
}
