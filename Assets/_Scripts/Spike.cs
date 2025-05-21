using UnityEngine;

public class Spike : MonoBehaviour
{
    public GameObject spikesModel;

    public Vector3 offset = new Vector3(0, 1f, 0);
    public float popUpDuration = 0.5f;
    public float returnDuration = 3f;
    public float waitBeforeReturn = 5f;
    public int healthToTake = -50;
    public bool isReversed = false;

    private Vector3 initialPosition;
    private AudioSource audioSource;

    public AudioClip popUpSound;
    public AudioClip returnSound;

    private bool isUp = false;

    void Start()
    {
        if(isReversed) offset = new Vector3(0, -1f, 0);
        initialPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isUp)
        {
            PopUp();
        }
    }

    public void PopUp()
    {
        isUp = true;
        audioSource.PlayOneShot(popUpSound);
        GameManager.instance.AddHealth(healthToTake);

        LeanTween.move(gameObject, initialPosition + offset, popUpDuration)
                 .setEase(LeanTweenType.easeOutQuad)
                 .setOnComplete(() =>
                 {
                     // Odczekaj X sekund zanim wrócisz na dó³
                     LeanTween.delayedCall(gameObject, waitBeforeReturn, ReturnToPosition);
                 });
    }

    void ReturnToPosition()
    {
        audioSource.PlayOneShot(returnSound);
        LeanTween.move(gameObject, initialPosition, returnDuration)
                 .setEase(LeanTweenType.easeInQuad)
                 .setOnComplete(() =>
                 {
                     isUp = false;
                 });
    }
}
