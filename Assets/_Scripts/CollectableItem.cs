using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectableItem : MonoBehaviour
{
    public Transform itemGOHolder;
    private Light lightUnderGO;
    private AudioSource audioSource;

    public Item item;

    void Start()
    {
        lightUnderGO = GetComponentInChildren<Light>();
        audioSource = GetComponent<AudioSource>();

        // Ustawienie dźwięku przedmiotu
        audioSource.clip = item.itemAudioClip;

        // Animacje przedmiotu (przeskalowanie, obrót, ruch)
        LeanTween.scale(gameObject, new Vector3(1.2f, 1.2f, 1.2f), 1f).setLoopPingPong();
        LeanTween.rotateAround(gameObject, Vector3.up, 360f, 5f).setLoopClamp();
        LeanTween.moveY(gameObject, transform.position.y + 0.5f, 1f).setLoopPingPong();

        // Tworzenie modelu graficznego przedmiotu w odpowiednim miejscu
        Instantiate(item.itemPrefab, itemGOHolder.position, Quaternion.identity, itemGOHolder);

        // Ustawienie koloru światła w zależności od typu przedmiotu
        if (item.itemLight == Item.ItemLight.Red)
        {
            lightUnderGO.color = Color.red;
        }
        else if (item.itemLight == Item.ItemLight.Green)
        {
            lightUnderGO.color = Color.green;
        }
        else if (item.itemLight == Item.ItemLight.Blue)
        {
            lightUnderGO.color = Color.blue;
        }
        else if (item.itemLight == Item.ItemLight.Yellow)
        {
            lightUnderGO.color = Color.yellow;
        }
        else
        {
            lightUnderGO.color = Color.white;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Próba zebrania przedmiotu
            bool isItemCollected = PlayerInventory.instance.CollectItem(item);

            // Jeśli przedmiot został zebrany (np. ekwipunek nie jest pełny), usuń go z gry
            if (isItemCollected)
            {
                // Jeśli przedmiot ma przypisany dźwięk, odtwórz go
                if (audioSource != null && !!item.itemAudioClip)
                {
                    AudioSource.PlayClipAtPoint(audioSource.clip, transform.position);
                }
                Destroy(gameObject);
            }
        }
    }
}
