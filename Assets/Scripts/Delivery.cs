using UnityEngine;
using TMPro;
public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float delay = 0.03f;
    [SerializeField] TMP_Text IceCreamText;
    void Start()
    { 
        IceCreamText.gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            Debug.Log("Picked up an Ice Cream");
            hasPackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
            IceCreamText.gameObject.SetActive(true);
            
        }

        if (collision.CompareTag("Customer") && hasPackage)
        {
            Debug.Log("Thank you for the ice cream");
            hasPackage = false;
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, delay);
            IceCreamText.gameObject.SetActive(false);
            
        }
    }
}
