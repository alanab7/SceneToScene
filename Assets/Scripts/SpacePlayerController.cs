using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SpacePlayerController : MonoBehaviour
{
 public InputAction MoveAction;
 private static SpacePlayerController instance;


    public float walkSpeed = 1.0f;
    public float turnSpeed = 20f;
    private int count;

    Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;
    private MeshRenderer meshRenderer;

    void Start ()
    {
        count = 0;
        m_Rigidbody = GetComponent<Rigidbody> ();
        MoveAction.Enable();
    }

    void FixedUpdate()
    {
        var pos = MoveAction.ReadValue<Vector2>();

        float horizontal = pos.x;
        float vertical = pos.y;
        

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);

        m_Rigidbody.MoveRotation(m_Rotation);
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * walkSpeed * Time.deltaTime);
        
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            count = count + 1;
        }

        if (other.gameObject.CompareTag("Scene1Door"))
        {
            // Print out the current scene's name

            Debug.Log(SceneManager.GetActiveScene().name);

            // Change scene

            SceneManager.LoadScene("Scene2");
            transform.position = new Vector3(0f, 1f, 0f);
            walkSpeed = 6.0f;
        }
//uncomment when scene 3 is done, adjust position and walk speed as needed
        //if (other.gameObject.CompareTag("Scene2Door"))
        //{

           // Debug.Log(SceneManager.GetActiveScene().name);

           // SceneManager.LoadScene("Scene3");
            //transform.position = new Vector3(0f, 1f, 0f);
            //walkSpeed = 6.0f;
       // }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // prevent duplicates
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    

}

