using UnityEngine;

public class ViewpointTest : MonoBehaviour
{
    public Camera quadCamera;
    
    
    private Camera _mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mainRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(mainRay, out RaycastHit mainHit))
            {
                Vector2 hitPos = mainHit.textureCoord;
                print(hitPos);
                Ray quadRay = quadCamera.ViewportPointToRay(hitPos);
                if (Physics.Raycast(quadRay, out RaycastHit quadHit))
                {
                    quadHit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }
}
