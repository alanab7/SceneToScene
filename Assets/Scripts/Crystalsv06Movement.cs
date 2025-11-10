using UnityEngine;

public class Crystalsv06Movement : MonoBehaviour
{
float speed = 4f;     // how fast it oscillates
    float height = 0.5f;  // how high it goes
    float baseY;

 void Start()
{
    baseY = transform.position.y;

 }

void Update() 
{
    Vector3 pos = transform.position;
    float newY = baseY + Mathf.Sin(Time.time * speed) * height;
    transform.position = new Vector3(pos.x, newY * height, pos.z);
}

}
