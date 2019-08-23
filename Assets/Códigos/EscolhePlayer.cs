using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolhePlayer : MonoBehaviour
{
    public static EscolhePlayer instance;
    GameObject player;
    int controle = 0;

    public GameObject[] players;

    public void Start(){
        player = GameObject.Find("Player");
        DontDestroyOnLoad(player);
        player = players[0];
    }
    public void Awake(){
        if (instance == null)                           //FAZ COM QUE O CÓDIGO NÃO SEJA DESTRUIDO TODA VEZ QUE REINICIAR O JOGO
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TrocaPersonagem(){
        Destroy(player);
        player = GameObject.Find("Player");
        if (controle == 0){
            player = Instantiate(players[0], player.transform.position, player.transform.rotation);
            controle = 1;
        }
       else if (controle == 1){
            player = Instantiate(players[1], player.transform.position, player.transform.rotation);
            controle = 0;
       }
    }

    public void Escolhe()
    {
        SceneManager.LoadScene("Fase-1", LoadSceneMode.Single);
        DontDestroyOnLoad(player);
        player.name = "Player";
        player.transform.position = new Vector3(-16, 4, 0);
        Ativa();
    }

    public void Ativa()
    {
        player.SetActive(true);
    }

    public void Desativa()
    {
        player.SetActive(false);
    }
}
