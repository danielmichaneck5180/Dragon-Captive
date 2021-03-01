using UnityEngine;
using UnityEngine.UI;

public class ControllerScript : MonoBehaviour
{
    public GameObject bike, dragon, camera, timerText, endText, birdReference;

    Vector3 objectDistance = new Vector3(0f, 0f, 0f);
    Vector3 windflow = new Vector3(0f, 0f, 0f);

    public float cameraHeight = 100f;
    public float minX, minZ, maxX, maxZ;
    float windAcceleration = 50f;
    float windBoundary = 40f;
    float timer = 60;
    float birdTimer = 5f;

    bool end = false, dragonWin = false, bikeWin = false;

    LineRenderer lineRenderer;
    Vector3[] linePos;

    LineRenderer windLineRenderer;
    Vector3[] windPos;

    GameObject[] birds;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        windLineRenderer = transform.Find("Wind Direction Pointer").gameObject.GetComponent<LineRenderer>();
        birds = new GameObject[255];

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            timerText.GetComponent<Text>().text = "Time Remaining: " + Mathf.Ceil(timer).ToString();

        }
        else
        {
            end = true;
            dragonWin = true;

        }

        if (end)
        {
            if (bikeWin)
            {
                endText.GetComponent<Text>().text = "BIKE WINS!";

            }
            else endText.GetComponent<Text>().text = "DRAGON WINS!";

            timerText.GetComponent<Text>().text = "";

        }
        else
        {
            if (birdTimer > 0f)
            {
                birdTimer -= Time.deltaTime;

            }
            else
            {
                birdTimer = 5f;
                GameObject birb = Instantiate(birdReference, gameObject.transform);
                birb.transform.Translate(new Vector3(-150f + camera.transform.position.x,
                    0f,
                    -150f + camera.transform.position.z));
                birb = Instantiate(birdReference, gameObject.transform);
                birb.transform.Translate(new Vector3(150f + camera.transform.position.x,
                    0f,
                    -150f + camera.transform.position.z));
                birb = Instantiate(birdReference, gameObject.transform);
                birb.transform.Translate(new Vector3(-150f + camera.transform.position.x,
                    0f,
                    150f + camera.transform.position.z));
                birb = Instantiate(birdReference, gameObject.transform);
                birb.transform.Translate(new Vector3(150f + camera.transform.position.x
                    ,
                    0f,
                    150f + camera.transform.position.z));

            }

            objectDistance = bike.transform.position - dragon.transform.position;
            objectDistance.y = 0f;

            dragon.GetComponent<DragonScript>().SetDrag(objectDistance);

            int x = 0, y = 0;

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                x -= 1;

            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                x += 1;

            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                y -= 1;

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                y += 1;

            }

            windflow = new Vector3(Mathf.Clamp(windflow.x + x * Time.deltaTime * windAcceleration, -windBoundary, windBoundary),
                0f,
                Mathf.Clamp(windflow.z + y * Time.deltaTime * windAcceleration, -windBoundary, windBoundary));

            dragon.GetComponent<DragonScript>().SetWind(windflow);

            camera.transform.position = (bike.transform.position + dragon.transform.position) / 2;
            camera.transform.position = new Vector3(camera.transform.position.x, cameraHeight, camera.transform.position.z);
            camera.transform.position = new Vector3(Mathf.Clamp(camera.transform.position.x, minX, maxX),
            cameraHeight,
            Mathf.Clamp(camera.transform.position.z, minZ, maxZ));

            linePos = new Vector3[2];

            linePos[0] = dragon.transform.position;
            linePos[1] = bike.transform.position;

            lineRenderer.SetPositions(linePos);

            windPos = new Vector3[2];

            windPos[0] = new Vector3(60f + camera.transform.position.x,
                10f,
                30f + camera.transform.position.z);
            windPos[1] = windPos[0] + windflow / 4;

            windLineRenderer.SetPositions(windPos);

            for (int i = 0; i < birds.Length; i++)
            {
                if (birds[i] != null)
                {
                    birds[i].GetComponent<BirdScript>().AddWind(windflow);

                }

            }

        }

    }

    public void DragonHit()
    {
        end = true;
        bikeWin = true;

    }

    public void AddBird(GameObject bird)
    {
        for (int i = 0; i < birds.Length; i++)
        {
            if (birds[i] == null)
            {
                birds[i] = bird;
                break;

            }

        }

    }

}
