using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(
            Random.Range(-45f, 45f) * Mathf.Sign(transform.position.x),
            0f,
            Random.Range(-45f, 45f) * Mathf.Sign(transform.position.z));

        rb.velocity = rb.velocity.normalized * 1f;
        Debug.Log(rb.velocity);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
