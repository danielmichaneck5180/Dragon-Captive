﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{
    Vector3 wind = new Vector3(0f, 0f, 0f);
    Vector3 drag = new Vector3(0f, 0f, 0f);
    Vector3 velocity = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocity = drag + wind;

        transform.Translate(velocity * Time.deltaTime);

    }

    public void SetDrag(Vector3 newDrag)
    {
        drag = newDrag;

    }

    public void SetWind(Vector3 newWind)
    {
        wind = newWind;

    }

}
