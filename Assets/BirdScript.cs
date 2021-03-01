using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    Rigidbody rb;
    Vector3 startVelocity;
    const float speed = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = new Vector3(
            Random.Range(5f, 40f) * -Mathf.Sign(transform.position.x),
            0f,
            Random.Range(5f, 40f) * -Mathf.Sign(transform.position.z));

        startVelocity = rb.velocity.normalized * speed;
        rb.AddForce(startVelocity);
        transform.LookAt(-transform.position);
        Debug.Log(rb.velocity);

        GameObject.FindGameObjectWithTag("GameController").GetComponent<ControllerScript>().AddBird(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Dragon")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<ControllerScript>().DragonHit();

        }

    }

    public void AddWind(Vector3 wind)
    {
        rb.velocity = startVelocity + wind / (speed);

    }

}
