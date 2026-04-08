using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Transform respawnPoint;
    public float threshold = -5f;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (transform.position.y < threshold)
        {
            controller.enabled = false;
            transform.position = respawnPoint.position;
            controller.enabled = true;
        }
    }
}
