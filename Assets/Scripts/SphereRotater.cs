using UnityEngine;

public class SphereRotater : MonoBehaviour
{
    public Vector3 rotationSpeeds = new Vector3(50f, 50f, 0f); // 50 degrees X, 50 degrees Y, 0 degrees Z

    void Update()
    {
        // Rotate using the defined speeds scaled by time
        transform.Rotate(rotationSpeeds * Time.deltaTime);
    }
}
