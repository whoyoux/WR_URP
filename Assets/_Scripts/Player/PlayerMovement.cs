using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public Transform oriention;
    
    float horizontalInput;
    float verticalInput;

    Vector3 moveDir;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        rb.drag = groundDrag;
    }

    private void MyInput()
    {
        // Pobieranie wej�cia od gracza
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void MovePlayer()
    {
        // Obliczenie kierunku ruchu wzgl�dem orientacji (np. kierunku kamery)
        moveDir = (oriention.forward * verticalInput + oriention.right * horizontalInput).normalized;

        rb.AddForce(moveDir * moveSpeed * 10f, ForceMode.Force);
    }

    void Update()
    {
        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void SpeedControl()
    {
        // Obliczenie pr�dko�ci w p�aszczy�nie poziomej
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            // Zachowanie pionowej pr�dko�ci (np. podczas skoku), ograniczenie poziomej
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
