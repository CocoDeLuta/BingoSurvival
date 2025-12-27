using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [Header("References")]
    public Camera playerCamera;

    [Header("Sensitivity")]
    public float sensitivityX = 30f;
    public float sensitivityY = 30f;

    [Header("Clamp")]
    public float minPitch = -80f;
    public float maxPitch = 80f;

    // Estado interno
    private float pitch;
    private Vector2 lookDelta;

    // expoe o delta do look para outras classes (WeaponLag)
    public Vector2 LookDelta => lookDelta;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    /// <summary>
    /// Chamado pelo InputManager
    /// </summary>
    public void ProcessLook(Vector2 input)
    {
        // Guarda delta (sem Time.deltaTime ainda)
        lookDelta = input;

        float mouseX = input.x * sensitivityX * Time.deltaTime;
        float mouseY = input.y * sensitivityY * Time.deltaTime;

        // Pitch (câmera)
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);

        playerCamera.transform.localRotation =
            Quaternion.Euler(pitch, 0f, 0f);

        // Yaw (player)
        transform.Rotate(Vector3.up * mouseX);
    }
}
