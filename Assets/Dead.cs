using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    [SerializeField]
    private GameObject reanimatedObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If hit by life bullet
        if (collision.gameObject.CompareTag("LifeBullet"))
        {
            // Destroy bullet
            Destroy(collision.gameObject);
            // Change to living object
            Instantiate(reanimatedObject, transform.position, transform.rotation);
            Destroy(transform.gameObject);
        }
    }
}
