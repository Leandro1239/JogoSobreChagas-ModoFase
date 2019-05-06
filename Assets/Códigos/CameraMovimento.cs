// BIBLIOTECAS
using UnityEngine;

// CLASSE
public class CameraMovimento : MonoBehaviour
{
    //VARIÁVEIS
    private float dampTime = 0.15f, x = 0.5f, y = 0.3f;                  //SUAVIDADE DA CAMERA, AJUSTE NO EIXO X, AJUSTE NO EIXO Y
    private Vector3 velocity = Vector3.zero;        //VELOCIDADE
    public Transform player;                        //DEFINE O PLAYER

    //SEGUE O PLAYER
    void Update()
    {
        if (player)                                 
        {
            Vector3 point = GetComponent<Camera>().WorldToViewportPoint(player.position);
            Vector3 delta = player.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(x, y, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        } 
    }
}
