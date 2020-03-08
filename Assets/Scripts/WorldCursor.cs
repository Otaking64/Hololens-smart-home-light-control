using UnityEngine;

public class WorldCursor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    // Use this for initialization
    void Start()
    {
        // Find mesh renderer
        meshRenderer = this.gameObject.GetComponentInChildren<MeshRenderer>();
    }

    void Update()
    {
        //tract headpostion and gazedirection for raycast interaction
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;

        RaycastHit hitInfo;

        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            //if gaze hits an object show the cursor (enable the meshRenderer)
            meshRenderer.enabled = true;
            this.transform.position = hitInfo.point;
            this.transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
        }
        else
        {
            //else hide the cursor
            meshRenderer.enabled = false;
        }
    }
}