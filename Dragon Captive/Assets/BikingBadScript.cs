using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikingBadScript : MonoBehaviour
{
    float speedMultiplier = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int x = 0, y = 0;

        if (Input.GetKey(KeyCode.A))
        {
            x -= 1;

        }

        if (Input.GetKey(KeyCode.D))
        {
            x += 1;

        }

        if (Input.GetKey(KeyCode.S))
        {
            y -= 1;

        }

        if (Input.GetKey(KeyCode.W))
        {
            y += 1;

        }

        transform.Translate(new Vector3(x, 0, y) * Time.deltaTime * speedMultiplier);

    }

}
