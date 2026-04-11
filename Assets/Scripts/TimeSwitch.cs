using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;

public class TimeSwitch : MonoBehaviour
{
    public GameObject[] pastObjects;
    public GameObject[] futureObjects;
    public GameObject[] persistentObjects;

    public Material pastMat;
    public Material futureMat;

    public PauseScript pauseManager;

    bool isPast = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (GameObject obj in futureObjects)
        {
            obj.SetActive(false);
        }

        foreach(GameObject obj in pastObjects)
        {
            obj.GetComponent<Renderer>().sharedMaterial = pastMat;
        }
        foreach (GameObject obj in persistentObjects)
        {
            obj.GetComponent<Renderer>().sharedMaterial = pastMat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((Keyboard.current.fKey.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame) && pauseManager.paused == false)
        {
            isPast = !isPast;

            foreach (GameObject obj in pastObjects)
            {
                obj.SetActive(isPast);
                SetMat(obj);
            }

            foreach (GameObject obj in futureObjects)
            {
                obj.SetActive(!isPast);
                SetMat(obj);
            }

            foreach (GameObject obj in persistentObjects)
            {
                SetMat(obj);
            }
        }
    }

    void SetMat(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        renderer.sharedMaterial = isPast ? pastMat : futureMat;
    }
}
