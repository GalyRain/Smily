using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    private void LateUpdate()
    {
        transform.position = new Vector3(
        playerController.transform.position.x,
        playerController.transform.position.z,
        transform.position.z);
    }
}
