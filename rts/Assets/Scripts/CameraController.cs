using UnityEngine;

// This allows movement of the camera on 3 axes
// Translation is currently in a global scope
// If we add camera rotation we will need to refactor
    // E.g. keep x and z on local scope
    // Consider how camera's up/down angle will affect translation
        // Would a change in global camera height require an adjustment to the local x transformation
    // Research needed into rts cameras (movement, rotation, angle of view)


public class CameraController : MonoBehaviour
{
    // If heights conflict, minHeight is used for max and default
    [Range(0f, 4f)]
    public float minHeight = 0;
    [Range(0f, 4f)]
    public float maxHeight;
    [Range(0f, 4f)]
    public float defaultHeight;

    [Range(0f, 4f)]
    public float horizontalSpeed;
    [Range(0f, 4f)]
    public float verticalSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ValidateCameraHeightRange();
        transform.position = new Vector3(transform.position.x, defaultHeight, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Get input
        Vector3 inputs = GetInputs();

        // Check height is within range
        float targetHeight = transform.position.y + Time.deltaTime * verticalSpeed * inputs.y;
        if (targetHeight > maxHeight || targetHeight < minHeight)
        {
            inputs.y = 0;
        }

        Vector3 velocity = new Vector3(0, 0, 0);
        velocity.x += (Time.deltaTime * horizontalSpeed * inputs.x);
        velocity.y += (Time.deltaTime * verticalSpeed * inputs.y);
        velocity.z += (Time.deltaTime * horizontalSpeed * inputs.z);
        transform.Translate(velocity, Space.World);        
    }

    void ValidateCameraHeightRange()
    {
        if (maxHeight < minHeight) {
            Debug.Log("Camera max height is lower than min height");
            maxHeight = minHeight;
            defaultHeight = minHeight;
        }
    }
    Vector3 GetInputs()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("CameraHeight"), Input.GetAxis("Vertical"));
    }
}
