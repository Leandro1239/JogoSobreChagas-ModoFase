using UnityEngine;

public class ControlaSons : MonoBehaviour
{
    public static ControlaSons Instance;
    public AudioSource Musica, Coleta, Dor, Pulo;
    private int Coletou, ContadorSom, Doeu, DorSom, Pulou, PulouSom;
    private float VolumeMusica = 1f, VolumeSom = 1f;

    private void Start()
    {
        Doeu = Sintoma.DorSom;
        Coletou = Somador.ContaSom;
        Pulou = Movimentacao.PulaSom;
        Musica.Play();
    }

    void Update()
    {
        Musica.volume = VolumeMusica;
        Coleta.volume = VolumeSom;

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
        if (Musica.isPlaying)
        {
            Musica.Pause();
        }
        else
        {
            Musica.Play();
        }
    }

    public void PausePlaySom()
    {
        if (Coleta.isPlaying)
        {
            Coleta.Pause();
        }
        else
        {
            Coleta.Play();
        } 
    }

    public void SetVolumeMusica (float vol)
    {
        VolumeMusica = vol;
    }

    public void SetVolumeSom (float volsom)
    {
        VolumeSom = volsom;
    }
}
