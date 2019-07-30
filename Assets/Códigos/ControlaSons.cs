using UnityEngine;

public class ControlaSons : MonoBehaviour
{
    public static ControlaSons Instance;
    public AudioSource Musica, Coleta, Dor, Pulo;
    private int Coletou, ContadorSom, Doeu, DorSom, Pulou, PulouSom;
    private float Volume = 1f;

    private void Start()
    {
        Doeu = Sintoma.DorSom;
        Coletou = Somador.ContaSom;
        Pulou = Movimentacao.PulaSom;
        Musica.Play();
    }

    void Update()
    {
        Musica.volume = Volume;
        Coleta.volume = Volume;
        Dor.volume = Volume;
        Pulo.volume = Volume;

        ContadorSom = Somador.ContaSom;
        DorSom = Sintoma.DorSom;
        PulouSom = Movimentacao.PulaSom;

        if (Coletou != ContadorSom)
        {
            Coleta.Play();
            Coletou = ContadorSom;
        }

        if (Doeu != DorSom)
        {
            Dor.Play();
            Doeu = DorSom;
        }

        if (Pulou != PulouSom)
        {
            Pulo.Play();
            Pulou = PulouSom;
        }
    }

    public void PausePlayMusica()
    {
        Musica = GetComponent<AudioSource>();
        Coleta = GetComponent<AudioSource>();
        Dor = GetComponent<AudioSource>();
        Pulo = GetComponent<AudioSource>();

        if (Musica.isPlaying)
        {
            Musica.Pause();
            Coleta.Pause();
            Dor.Pause();
            Pulo.Pause();
        }
        else
        {
            Musica.Play();
            Coleta.Play();
            Dor.Play();
            Pulo.Play();
        }
    }

    public void SetVolume (float vol)
    {
        Volume = vol;
    }
}
