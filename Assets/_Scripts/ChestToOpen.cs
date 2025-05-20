using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestToOpen : MonoBehaviour
{
    public float radius = 5f;
    private SphereCollider sphereCollider;
    public GameObject textToShowWhenInCollider;

    public KeyCode keyToOpen = KeyCode.E;

    private bool isPlayerInRange = false;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = radius;

        textToShowWhenInCollider.SetActive(false);
    }

    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(keyToOpen))
        {
            // Add your logic to open the chest here
            Debug.Log("Chest opened!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the text when the player is in range
            textToShowWhenInCollider.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the text when the player leaves the range
            textToShowWhenInCollider.SetActive(false);
            isPlayerInRange = false;
        }
    }
}
