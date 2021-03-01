using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikingBadScript : MonoBehaviour
{
    GameObject spriteOne, spriteTwo, spriteTransform;
    float speedMultiplier = 20f, switchFrame = 0;
    bool isOne = true;

    private void Awake()
    {
        spriteTransform = transform.Find("Sprite Transform").gameObject;
        spriteOne = spriteTransform.transform.Find("Sprite 1").gameObject;
        spriteTwo = spriteTransform.transform.Find("Sprite 2").gameObject;

        spriteOne.SetActive(true);
        spriteTwo.SetActive(false);

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

        if (x != 0 || y != 0)
        {
            if (switchFrame > 0.5f)
            {
                switchFrame -= 0.5f;

                if (isOne)
                {
                    spriteOne.SetActive(false);
                    spriteTwo.SetActive(true);
                    isOne = false;

                }
                else
                {
                    spriteOne.SetActive(true);
                    spriteTwo.SetActive(false);
                    isOne = true;

                }

            }
            else
            {
                switchFrame += Time.deltaTime;

            }

        }

        if (x < 0)
        {
            if (y < 0) SetSpriteTransformRotation(135f);
            else if (y > 0) SetSpriteTransformRotation(225f);
            else SetSpriteTransformRotation(180f);

        }
        else if (x > 0)
        {
            if (y < 0) SetSpriteTransformRotation(45f);
            else if (y > 0) SetSpriteTransformRotation(315f);
            else SetSpriteTransformRotation(0f);

        }
        else
        {
            if (y < 0) SetSpriteTransformRotation(90f);
            else if (y > 0) SetSpriteTransformRotation(270f);

        }

    }

    void SetSpriteTransformRotation(float degrees)
    {
        spriteTransform.transform.eulerAngles = new Vector3(90f, degrees, 0f);

    }

}
