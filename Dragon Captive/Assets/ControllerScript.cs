using UnityEngine;

public class ControllerScript : MonoBehaviour
{
    public GameObject bike, dragon, camera;

    Vector3 objectDistance = new Vector3(0f, 0f, 0f);
    Vector3 windflow = new Vector3(0f, 0f, 0f);

    float windAcceleration = 20f;
    float windBoundary = 40f;

    LineRenderer lineRenderer;
    Vector3[] linePos;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

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

    }

}
