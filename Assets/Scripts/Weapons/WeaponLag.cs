using UnityEngine;
public class WeaponLag : MonoBehaviour
{
    public PlayerLook playerLook;

    public float swayAmount = 2f;
    public float smoothSpeed = 8f;

    private Vector3 currentRot;

    private void LateUpdate()
    {
        Vector2 look = playerLook.LookDelta;

        Vector3 targetRot = new Vector3(
            -look.y * swayAmount,
             look.x * swayAmount,
             0f
        );

        currentRot = Vector3.Lerp(
            currentRot,
            targetRot,
            Time.deltaTime * smoothSpeed
        );

        transform.localRotation = Quaternion.Euler(currentRot);
    }
}
