using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject bike, dragon, camera;

    Vector3 objectDistance = new Vector3(0f, 0f, 0f);
    Vector3 windflow = new Vector3(0f, 0f, 0f);

    float windAcceleration = 50f;
    float windBoundary = 40f;

    LineRenderer lineRenderer;
    Vector3[] linePos;

    LineRenderer windLineRenderer;
    Vector3[] windPos;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        windLineRenderer = transform.Find("Wind Direction Pointer").gameObject.GetComponent<LineRenderer>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        camera.transform.position = new Vector3(camera.transform.position.x, 100f, camera.transform.position.z);

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

    }

}
