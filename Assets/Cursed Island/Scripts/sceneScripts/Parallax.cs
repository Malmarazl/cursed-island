using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 parallaxEffectMultiple;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }
    

    private void Update()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiple.x, deltaMovement.y * parallaxEffectMultiple.y);
        lastCameraPosition = cameraTransform.position;
    }
}
