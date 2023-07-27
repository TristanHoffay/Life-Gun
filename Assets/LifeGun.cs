using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeGun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private bool canShoot = true;
    private float animationOver = 0;
    [SerializeField]
    private float animationDuration = 1f;
    // Start is called before the first frame update
    void Start()
    {
        if (bullet == null)
            Debug.Log("Error: bullet prefab not set to gun");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.GetChild(0).position;
            newBullet.GetComponent<Rigidbody>().velocity = transform.up * 50f;
        }
        if (Input.GetMouseButtonDown(1))
        {
            // animate hand pointing for a second
            canShoot = false; // until animation over
            animationOver = Time.time + animationDuration;
        }
        if (!canShoot && Time.time > animationOver) 
        {
            canShoot = true;
        }
    }
}
