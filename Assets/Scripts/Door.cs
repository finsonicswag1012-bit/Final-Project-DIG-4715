using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
