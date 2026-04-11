using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float ySmoothTime = 0.2f;
    public float horizontalSmoothTime = 0.05f;

    float yVelocity;
    float xVelocity;
    float zVelocity;

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        pos.y = Mathf.SmoothDamp(pos.y, target.position.y, ref yVelocity, ySmoothTime);
        pos.x = Mathf.SmoothDamp(pos.x, target.position.x, ref xVelocity, horizontalSmoothTime);
        pos.z = Mathf.SmoothDamp(pos.z, target.position.z, ref zVelocity, horizontalSmoothTime);

        transform.position = pos;
    }
}
