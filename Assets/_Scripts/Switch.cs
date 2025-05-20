using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public float radius = 5f;
    private SphereCollider sphereCollider;
    public GameObject goToShowWhenInCollider;
    public TextMeshProUGUI text;

    public KeyCode keyToActivate = KeyCode.E;

    private bool isPlayerInRange = false;
    private bool _isActivated = false;

    void Start()
    {
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = radius;

        goToShowWhenInCollider.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(keyToActivate) && !_isActivated)
        {
            Activate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the text when the player is in range
            goToShowWhenInCollider.SetActive(true);
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the text when the player leaves the range
            goToShowWhenInCollider.SetActive(false);
            isPlayerInRange = false;
        }
    }

    private void Activate()
    {
        // Logic to activate the switch
        Debug.Log("Switch activated!");
        _isActivated = true;
        text.text = "Ju¿ aktywowano!";

        GameManager.instance.RenderSwitchesActivated();
    }

    public bool isActivated()
    {
        return _isActivated;
    }
}
