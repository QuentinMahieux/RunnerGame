using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 targetdirection;
    private GameObject character;
    private Vector3 targetPosition;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.35f;
    
    void Start()
    {
       character = GameObject.Find("Player");
    }
    void LateUpdate()
    {
        targetPosition = character.transform.TransformPoint(offset);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.LookAt(character.transform.position + targetdirection);
    }
}
