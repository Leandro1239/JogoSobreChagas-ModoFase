using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscolhePlayer : MonoBehaviour
{
    public static EscolhePlayer instance;
    GameObject player;
    int i = 0;

    public GameObject[] players;
    public Button proximo, anterior, seleciona;

    // Start is called before the first frame update
    void Start()
    {
        proximo.onClick = new Button.ButtonClickedEvent();
        anterior.onClick = new Button.ButtonClickedEvent();
        seleciona.onClick = new Button.ButtonClickedEvent();

        proximo.onClick.AddListener(() => Proximo());
        anterior.onClick.AddListener(() => Anterior());
        seleciona.onClick.AddListener(() => Escolhe());
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
        {
            player = GameObject.Find("Player");
            player = Instantiate(players[i], player.transform.position, player.transform.rotation);
        }
    }

    void Proximo()
    {
        i++;
        if (i >= players.Length)
        {
            i = 0;
        }
        Destroy(player);
    }

    void Anterior()
    {
        i--;
        if (i <= 0)
        {
            i = players.Length - 1;
        }
        Destroy(player);
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
