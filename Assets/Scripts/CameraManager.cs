using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 3f, -6f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + cameraOffset;
    }
}
