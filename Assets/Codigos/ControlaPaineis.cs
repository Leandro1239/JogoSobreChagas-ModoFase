using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlaPaineis : MonoBehaviour
{
    Contador Contador_R = new Contador();
    Sintoma Sintoma_R = new Sintoma();
    EncontraPaineis EncontraPaineis_R = new EncontraPaineis();
  
    // SÓ VAI ATIVAR O PAINEL DE AVISO SE FOR ZERO, SE FOR 1 SIGNIFICA QUE JA FOI ATIVADO.
    private int controleTutorial = 0, controleColeta = 0, controleDano = 0;
    private bool apanhou = false; 

    public void Update()
    {   
        // VERIFICA SE É A PRIMEIRA VEZ QUE É JOGADO, PARA ATIVAR O TUTORIAL E ATIVA O CONTROLE PARA NUNCA MAIS ENTRAR NESSA CONDIÇÃO
        if (Contador_R.AcaiTotal == 0 && controleTutorial == 0)
        {
            DesligaPainel();
            TutorialUI();
            controleTutorial = 1;
        }

        // VERIFICA SE É A PRIMEIRA VEZ QUE COLETA AÇAI
        if (Contador_R.AcaiTotal == 1 && controleColeta == 0)
        {
            DesligaPainel();
            ColetouAcaiUI();
            controleColeta = 1;
        }

        // VERIFICA SE É A PRIMEIRA VEZ QUE TOCA EM UM BARBEIRO
        if (apanhou == true && controleDano == 0)
        {
            DesligaPainel();
            TocouBarbeiro();
            controleDano = 1;
        }

        // ======================== MORTE E VITÓRIA ======================== //
        // VERIFICA SE A VIDA É ZERO PARA CHAMAR O PAINEL DE MORTE
        if (Sintoma_R.Morreu == 1)
        {
            DesligaPainel();
            GameOverUI();
            Sintoma_R.Morreu = 0;
        }

        // VERIFICA EM TODOS OS NÍVEIS SE ELE VENCEU ALGUM, SE SIM MOSTRA O PAINEL DE VITÓRIA E DESLIGA A VITÓRIA DO NÍVEL
        if (Nivel1.Venceu1 == 1 || Nivel2.Venceu2 == 1 || Nivel3.Venceu3 == 1 || Nivel4.Venceu4 == 1 || Nivel5.Venceu5 == 1 ||
            Nivel6.Venceu6 == 1 || Nivel7.Venceu7 == 1 || Nivel8.Venceu8 == 1 || Nivel9.Venceu9 == 1 || Nivel10.Venceu10 == 1)
        {
            DesligaPainel();
            PassLevelUI();

            Nivel1.Venceu1 = 0; Nivel2.Venceu2 = 0; Nivel3.Venceu3 = 0; Nivel4.Venceu4 = 0; Nivel5.Venceu5 = 0;
            Nivel6.Venceu6 = 0; Nivel7.Venceu7 = 0; Nivel8.Venceu8 = 0; Nivel9.Venceu9 = 0; Nivel10.Venceu10 = 0;
        }
    }


    //====================== CONTAGEM DE PRIMEIRO DANO ====================== \\
    //tocou É A VARIAVEL CRIADA PARA COMUNICAÇÃO ENTRE CÓDIGOS ATRAVÉS DO ARGUMENTO
    public void BarbeiroTocou()
    {
            apanhou = true;
            controleDano = 1 ;
            Salva(controleDano);                                   //SALVA
    }

    //GUARDA O VALOR DA VARIÁVEL NA CHAVE 'Tocou'
    public void Salva(int conta)
    {
        PlayerPrefs.SetInt("Tocou", conta);
    }

    //VERIFICA SE TEM ALGO SALVO NA CHAVE 'AcaiSalvo'
    public void AtualizaToqueBarbeiro()
    {
        if (PlayerPrefs.HasKey("Tocou"))                
        {
            controleDano = PlayerPrefs.GetInt("Tocou");    //SE TIVER, PEGA O VALOR DA CHAVE E ATRIBUI NA VARIÁVEL 'AcaiTotal'
        }
        else
        {
            controleDano = 0;                                  //SE NÃO TEM NADA SALVO COMEÇA COM ZERO
            PlayerPrefs.SetInt("Tocou", controleDano);     //ATRIBUI O ZERO NO VARIÁVEL
        }
    }

    // ========================= MÉTODOS DOS PAINEIS ======================== \\
    // CHAMA UMA FUNÇÃO PARA DESATIVAR OS PAINEIS 
    public void DesligaPainel()
    {
        EncontraPaineis_R.PainelLose.SetActive(false);
        EncontraPaineis_R.PainelWin.SetActive(false);
        EncontraPaineis_R.PainelPause.SetActive(false);
        EncontraPaineis_R.PainelTutorial.SetActive(false);
        EncontraPaineis_R.PainelColeta.SetActive(false);
        EncontraPaineis_R.PainelBarbeiro.SetActive(false);
    }

    // ATIVA PAINEL DE LOSE E PAUSA O TEMPO ================= \\
    public void GameOverUI()
    {
        EncontraPaineis_R.PainelLose.SetActive(true);
        Time.timeScale = 0;
    }

    //ATIVA PAINEL DE PRÓXIMO NÍVEL E PAUSA O TEMPO ================= \\
    public void PassLevelUI()
    {
        EncontraPaineis_R.PainelWin.SetActive(true);
        Time.timeScale = 0;
    }

    // ================== ATIVA PAINEL DE PAUSE E PAUSA ================= \\
    public void PauseUI()
    {
        EncontraPaineis_R.PainelPause.SetActive(true);
        Time.timeScale = 0;
    }

    // ================== DESATIVA PAINEL DE PAUSE E CONTINUA ================= \\
    public void ContinueUI()
    {
        Time.timeScale = 1;
    }

    // ================== ATIVA PAINEL DE TUTORIAL E PAUSA ================= \\
    public void TutorialUI()
    {
        EncontraPaineis_R.PainelTutorial.SetActive(true);
        Time.timeScale = 0;
    }

    // ================== ATIVA PAINEL DE COLETA E PAUSA ================= \\
    public void ColetouAcaiUI(){
        EncontraPaineis_R.PainelColeta.SetActive(true);
        Time.timeScale = 0;
    }

    // ============ ATIVA PAINEL DE TOQUE NO BARBEIRO E PAUSA ============= \\
    public void TocouBarbeiro(){
        EncontraPaineis_R.PainelBarbeiro.SetActive(true);
        Time.timeScale = 0;
    }
}
