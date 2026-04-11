using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform target;
    public float ySmoothTime = 0.2f;

    float yVelocity;

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        pos.y = Mathf.SmoothDamp(pos.y, target.position.y, ref yVelocity, ySmoothTime);
        pos.x = target.position.x;
        pos.z = target.position.z;

        transform.position = pos;
    }
}
