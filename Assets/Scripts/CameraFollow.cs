using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform Player; // Assign your character's Transform in the Inspector
        public Vector3 offset; // Adjust the desired offset from the character


    void Awake()
    {
        offset = transform.position - Player.position;
    }

    void LateUpdate()
    {
        if (Player != null)
        {
            // Position the camera behind the player, maintaining the offset
            transform.position = Player.position + Player.rotation * offset;

            // Make the camera look at the player
            transform.LookAt(Player.position);
        }
    }
}
