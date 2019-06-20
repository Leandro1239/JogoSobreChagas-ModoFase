// BIBLIOTECAS
using UnityEngine;
using UnityEngine.UI;

// CONTA QUANTOS AÇAIS TEM SALVO E QUANTAS VEZES FORAM JOGADAS
public class Contador : MonoBehaviour
{
    //VARIÁVEIS
    public static Contador instance;           //DEFINE A CLASSE COMO PUBLICA
    public int AcaiTotal, PlayTotal = 0;

    //REALIZA ISSO LOGO AO INICIAR
    //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
    void Awake()
    {
        if (instance == null)                       
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    //COMPARA O VALOR DE VEZES JOGADAS PARA SE CASO FOR UMA VEZ MOSTRAR A TELA DE TUTORIAL
    public void Update()
    {
        // TIRAR DOS COMENTÁRIOS PARA RESETAR OS VALORES SALVOS DE AÇAI E DE JOGADAS
        // AcaiTotal *= 0; PlayTotal *= 0; Salva(AcaiTotal); SalvaPlay(PlayTotal); 
    }

    //---- PARTE DE CONTAGEM DO AÇAI ----
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

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'AcaiSalvo'
    public void AtualizaAcai()
    {
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

    //----PARTE DE CONTAGEM DE JOGADAS----
    //CALCULA A QUANTIDADE DE VEZES QUE JOGOU
    public void Jogou(int ClicouPlay)
    {
        PlayTotal += ClicouPlay;                              //SOMA À VARIÁVEL 'AcaiTotal' O VALOR COLETADO NO ARGUMENTO DADO NA CLASSE 'ColetaAcai'
        SalvaPlay(PlayTotal);                                   //SALVA
    }

    //SALVA A QUANTIDADE DE JOGADAS DENTRO DE UMA CHAVE
    public void SalvaPlay(int ClicouPlay)
    {
        PlayerPrefs.SetInt("PlaySalvo", PlayTotal);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'PlaySalvo'
    public void AtualizaPlay()
    {
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
}