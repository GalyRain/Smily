using UnityEngine;

public class FollowingCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    void LateUpdate()
    {
        cameraTransform.transform.position = new Vector3(
            transform.position.x,
            transform.position.z,
            cameraTransform.transform.position.z);
    }
}