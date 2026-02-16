using UnityEngine;

public class CameraRunner : MonoBehaviour
{
    public Rigidbody rb;
    void Update()
    {
        rb.linearVelocity = PlayerRunner.instance.playerSpeed * transform.forward;
    }
}
