using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Transform player;

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, 7, 0);
    }
}
