using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Driver : MonoBehaviour
{
    [SerializeField]  float currentSpeed = 100f;
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float boostSpeed = 200f;
    [SerializeField] float regularSpeed = 100f;
    [SerializeField] float delay = 0.03f;
    [SerializeField] TMP_Text boostText;
    
    void Start()
    {
        currentSpeed = 100f;
        steerSpeed = 180f;

        boostText.gameObject.SetActive(false);
    
    }
    void OnTriggerEnter2D(Collider2D collision)

    {
        if (collision.CompareTag("Boost"))
        {
            currentSpeed = boostSpeed;
            boostText.gameObject.SetActive(true);
            Destroy(collision.gameObject, delay);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

       if (collision.collider.CompareTag("WorldCollision"))

        {
        currentSpeed = regularSpeed;
        boostText.gameObject.SetActive(false);
        }
        
    }
    void Update()
    {
        float move = 0f;
        float steer = 0f;


        if (Keyboard.current.wKey.isPressed)
        {
            move = 0.05f;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move = -0.05f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }
            float moveAmount = move * currentSpeed * Time.deltaTime;
            float steerAmount = steer * steerSpeed * Time.deltaTime;

               transform.Rotate(0, 0, steerAmount);
               transform.Translate(0,moveAmount, 0);
    }
}
