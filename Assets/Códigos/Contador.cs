// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// CONTA QUANTOS AÇAIS TEM SALVO E QUANTAS VEZES FORAM JOGADAS
public class Contador : MonoBehaviour
{
    //VARIÁVEIS
    public static Contador instance;           //DEFINE A CLASSE COMO PUBLICA
    public static int AcaiTotal = 0, PlayTotal;
    Text Coleta_Total, Play_Total;

    //REALIZA ISSO LOGO AO INICIAR
    void Awake()
    {
        if (instance == null)                       //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        AcaiTotal = AcaiTotal + ColetaAcai.Total;
        Coleta_Total = GameObject.Find("CQts_txt").GetComponent<Text>();
        Coleta_Total.text = AcaiTotal.ToString();
    }

    //---- PARTE DE CONTAGEM DO AÇAI ----

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'AcaiSalvo'
    /*public void ContaAcai()
    {
        
        Coleta_Total.text = AcaiTotal.ToString();

        if (PlayerPrefs.HasKey("AcaiSalvo"))                
        {
            AcaiTotal = PlayerPrefs.GetInt("AcaiSalvo");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'AcaiTotal'
        }
        else
        {
            AcaiTotal = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("AcaiSalvo", AcaiTotal);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }

    //Coletado É A VARIAVEL CRIADA PARA COMUNICAÇÃO ENTRE CÓDIGOS ATRAVÉS DO ARGUMENTO
    public void PegouAcai(int Coletado)                     
    {
        AcaiTotal += Coletado;                              //SOMA À VARIÁVEL 'AcaiTotal' O VALOR COLETADO NO ARGUMENTO DADO NA CLASSE 'ColetaAcai'
        Salva(AcaiTotal);                                   //SALVA
    }

    //GUARDA O VALOR DA VARIÁVEL NA CHAVE 'AcaiSalvo'
    public void Salva(int Coletado)
    {
        PlayerPrefs.SetInt("AcaiSalvo", AcaiTotal);         
    }

    //ATUALIZA O VALOR QUE TEM NA CHAVE PARA A VARIÁVEL
    public void UpdateScore()
    {
        AcaiTotal = PlayerPrefs.GetInt("AcaiSalvo");        
    }

     //ATUALIZA O VALOR DO TXT
    public void UpdateScoreTXT()
    {
        Coleta_Total.text = AcaiTotal.ToString();
    }*/

    //----PARTE DE CONTAGEM DE JOGADAS----

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'PlaySalvo'
    public void ContaPlay()
    {
       // Play_Total = GameObject.Find("PQts_txt").GetComponent<Text>();
        Play_Total.text = PlayTotal.ToString();

        if (PlayerPrefs.HasKey("PlaySalvo"))
        {
            PlayTotal = PlayerPrefs.GetInt("PlaySalvo");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'PlayTotal'
        }

        else
        {
            PlayTotal = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("PlaySalvo", PlayTotal);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }

    //SALVA A QUANTIDADE DE JOGADAS DENTRO DE UMA CHAVE
    public void SalvaPlay(int ClicouPlay)
    {
        PlayerPrefs.SetInt("PlaySalvo", PlayTotal);
    }

    //ATUALIZA O VALOR DA VARIAVEL COM O VALOR QUE TEM NA CHAVE
    public void UpdatePlay()
    {
        PlayTotal = PlayerPrefs.GetInt("PlaySalvo");
    }

    /* //ATUALIZA O TXT
    public void UpdatePlayTXT()
    {
        Play_Total.text = PlayTotal.ToString();
    }*/

    //CALCULA A QUANTIDADE DE VEZES QUE JOGOU
    public void Jogou(int ClicouPlay)
    {
        PlayTotal += ClicouPlay;                              //SOMA À VARIÁVEL 'AcaiTotal' O VALOR COLETADO NO ARGUMENTO DADO NA CLASSE 'ColetaAcai'
        SalvaPlay(PlayTotal);                                   //SALVA
    }

}