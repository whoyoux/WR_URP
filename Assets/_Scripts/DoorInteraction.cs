using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    [Header("References")]
    public Transform doorTransform;

    [Header("Animation Settings")]
    public Vector3 closedEuler = Vector3.zero;
    public Vector3 openEuler = new Vector3(0, 90f, 0);
    public float duration = 0.5f;
    public LeanTweenType easeType = LeanTweenType.easeOutExpo;

    [Header("Input")]
    public KeyCode openKey = KeyCode.E;

    private bool isOpen = false;
    private bool isAnimating = false;
    private bool canOpen = false;

    public GameObject textGo;

    void Start()
    {
        // ustawiamy drzwi w pozycji zamkniêtej
        doorTransform.localEulerAngles = closedEuler;
        textGo.SetActive(false);
    }

    void Update()
    {
        bool doPlayerHasEverything = LevelManager.instance.CanOpenDoor();

        if(!doPlayerHasEverything)
        {
            // TODO: Show maybe error text
        } else
        {
            textGo.SetActive(true);
        }

        if (Input.GetKeyDown(openKey) && !isAnimating && canOpen && doPlayerHasEverything)
        {
            ToggleDoor();
        }
    }

    public void ToggleDoor()
    {
        isAnimating = true;
        Vector3 targetEuler = isOpen ? closedEuler : openEuler;

        LeanTween.rotateLocal(doorTransform.gameObject, targetEuler, duration)
                 .setEase(easeType)
                 .setOnComplete(() =>
                 {
                     isOpen = !isOpen;
                     isAnimating = false;
                 });

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
        }
    }
}
