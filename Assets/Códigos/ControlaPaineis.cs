using UnityEngine.UI;
using UnityEngine;

public class ControlaPaineis : MonoBehaviour
{
    public static ControlaPaineis instance;
    public GameObject PainelLose, PainelWin, PainelPause, PainelTutorial, PainelColeta, PainelBarbeiro; 
    
    // ============================== REPETIÇÃO ============================ \\
    public void Update()
    {
        // VERIFICA SE É A PRIMEIRA VEZ QUE É JOGADO, PARA ATIVAR O TUTORIAL E ATIVA O CONTROLE PARA NUNCA MAIS ENTRAR NESSA CONDIÇÃO
        if (Contador.instance.AcaiTotal == 0 && GameManager.instance.ControleTutorial == 0)
        {
            DesligaPainel();
            TutorialUI();
            GameManager.instance.ControleTutorial = 1;
        }

        // VERIFICA SE É A PRIMEIRA VEZ QUE COLETA AÇAI
        if (Contador.instance.AcaiTotal == 1 && GameManager.instance.ControleColeta == 0)
        {
            DesligaPainel();
            ColetouAcaiUI();
            GameManager.instance.ControleColeta = 1;
        }

        // VERIFICA SE É A PRIMEIRA VEZ QUE TOCA EM UM BARBEIRO
        if (GameManager.instance.painelBarbeiro == 1 && GameManager.instance.ControleDano == 0)
        {
            DesligaPainel();
            TocouBarbeiro();
            GameManager.instance.ControleDano = 1;
        }

        // VERIFICA SE A VIDA É ZERO PARA CHAMAR O PAINEL DE MORTE
        if (Sintoma.Morreu == 1)
        {
            DesligaPainel();
            GameOverUI();
            Sintoma.Morreu = 0;
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

    // ========================= MÉTODOS DOS PAINEIS ======================== \\
    // CHAMA UMA FUNÇÃO PARA DESATIVAR OS PAINEIS 
    public void DesligaPainel()
    {
        PainelLose.SetActive(false);
        PainelWin.SetActive(false);
        PainelPause.SetActive(false);
        PainelTutorial.SetActive(false);
        PainelColeta.SetActive(false);
        PainelBarbeiro.SetActive(false);
    }

    // ATIVA PAINEL DE LOSE E PAUSA O TEMPO ================= \\
    public void GameOverUI()
    {
        PainelLose.SetActive(true);
        Time.timeScale = 0;
    }

    //ATIVA PAINEL DE PRÓXIMO NÍVEL E PAUSA O TEMPO ================= \\
    public void PassLevelUI()
    {
        PainelWin.SetActive(true);
        Time.timeScale = 0;
    }

    // ================== ATIVA PAINEL DE PAUSE E PAUSA ================= \\
    public void PauseUI()
    {
        PainelPause.SetActive(true);
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
        PainelTutorial.SetActive(true);
        Time.timeScale = 0;
    }

    // ================== ATIVA PAINEL DE COLETA E PAUSA ================= \\
    public void ColetouAcaiUI(){
        PainelColeta.SetActive(true);
        Time.timeScale = 0;
    }

    // ============ ATIVA PAINEL DE TOQUE NO BARBEIRO E PAUSA ============= \\
    public void TocouBarbeiro(){
        PainelBarbeiro.SetActive(true);
        Time.timeScale = 0;
    }
}
