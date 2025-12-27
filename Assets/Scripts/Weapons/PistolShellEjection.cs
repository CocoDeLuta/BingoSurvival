using UnityEngine;
public class PistolShellEjection : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform ejectPoint;

    public float ejectForce = 2f;
    public float torque = 5f;

    public void Eject()
    {
        // cria cápsula real
        GameObject shell = Instantiate(shellPrefab, ejectPoint.position, ejectPoint.rotation);

        Rigidbody rb = shell.GetComponent<Rigidbody>();
        rb.AddForce(-ejectPoint.right * ejectForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * torque, ForceMode.Impulse);

        Destroy(shell, 5f);
    }
}
