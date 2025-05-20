using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelZone : MonoBehaviour
{
    public int sceneToLoadIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && LevelManager.instance.CanOpenDoor())
        {
            SceneManager.LoadScene(sceneToLoadIndex);
        }
    }
}
