using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   public Transform target; // Assign your character's Transform in the Inspector
        public Vector3 offset; // Adjust the desired offset from the character

        void LateUpdate()
        {
            if (target != null)
            {
                transform.position = target.position + offset;
            }
        }
}
