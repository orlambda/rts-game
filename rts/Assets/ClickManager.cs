using UnityEngine;

// See tutorial https://learn.unity.com/tutorial/onmousedown

// TODO: Bug: null check on clickedObject: non-villager objects can be clicked (markers, buildings)
// so checked that last clicked object is a villager instead
// quick fix - tested for VillagerMovement script - there is a better way (tags?)

// TODO: selectedEntityMarker should move with selected villager because that villager is still selected

public class ClickManager : MonoBehaviour
{
    private GameObject clickedObject;
    public GameObject ground;

    public GameObject destinationMarker;
    public GameObject selectedEntityMarker;
    private Camera mainCamera;
    void Awake()
    {
        mainCamera = Camera.main;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            Ray ray = mainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // If ground was clicked, move object there
                if (hit.collider.gameObject.GetInstanceID() == ground.GetInstanceID())
                {
                    if (clickedObject.GetComponent<VillagerMovement>())
                    {
                        float x = hit.point.x;
                        float z = hit.point.z;
                        float y = destinationMarker.transform.position.y;
                        destinationMarker.transform.position = new Vector3(x, y, z);
                        VillagerMovement villager = clickedObject.GetComponent<VillagerMovement>();
                        villager.target = new Vector3(
                            destinationMarker.transform.position.x,
                            villager.transform.position.y,
                            destinationMarker.transform.position.z);
                        // Hide selectedEntityMarker
                        // TODO: NOT LIKE THIS
                        selectedEntityMarker.transform.position = 
                        new Vector3(-50,selectedEntityMarker.transform.position.y,-50);
                    }
                }
                // Else tell our clicked object to move to the target
                else
                {
                    clickedObject = hit.collider.gameObject;
                    selectedEntityMarker.transform.position = 
                        new Vector3(
                            clickedObject.transform.position.x,
                            selectedEntityMarker.transform.position.y,
                            clickedObject.transform.position.z
                            );
                }
            }
        }
    }
}
