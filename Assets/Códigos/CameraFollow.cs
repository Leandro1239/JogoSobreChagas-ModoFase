using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    // Cria o jogador e a posição a ser seguida
    private GameObject player; 
    private Transform posicao;
    
    // ACHA O JOGADOR E O CHEGACHAO PARA PODER SEGUIR
    public void Update() {
        player = GameObject.Find("Player");
        posicao = player.transform.Find("ChecaChão");
        transform.position = new Vector3(posicao.position.x, 7, 0);     // SEGUE SOMENTE NO EIXO X
    }
}
