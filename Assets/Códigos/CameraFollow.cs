using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
    public Transform player;
    //public float distanciaCamera = 30f;

    private void Awake()
    {
        //GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height/1.3f)/distanciaCamera);
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, 7, 0);
    }
}
