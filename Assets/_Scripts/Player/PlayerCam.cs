using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRot;
    float yRot;

    void Start()
    {
        // Ukrycie i zablokowanie kursora w centrum ekranu
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        xRot = 0;
        yRot = 0;
    }

    
    void Update()
    {
        // Pobranie ruchu myszy
        float mouseX = Input.GetAxisRaw("Mouse X") * sensX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensY * Time.deltaTime;

        yRot += mouseX;
        xRot -= mouseY;

        // Ograniczenie patrzenia w górê/dó³ (¿eby kamera siê nie obraca³a o 360 stopni)
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // Obrót samej kamery (pe³na rotacja w pionie i poziomie)
        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        // Obrót gracza – tylko w osi poziomej, ¿eby nie patrzy³ w górê/dó³
        orientation.rotation = Quaternion.Euler(0, yRot, 0);
    }
}
