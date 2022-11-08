using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletControl : MonoBehaviour
{

    public float speed = 30f;
    public float atk = 50f;
    private Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            gameObject.SetActive(false);
            Destroy(gameObject, 1);
        }

        if (other.tag == "Wall")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
