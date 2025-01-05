using UnityEngine;

public class ViewpointTest : MonoBehaviour
{
    [Header("Quad Camera")]
    public Camera quadCamera;
    
    private Camera _mainCamera;
    private Transform _targetTransform;
    private float _zValue;
    
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
                print($"Hit the object: {mainHit.transform.name}");
                Vector2 hitPos = mainHit.textureCoord;
                print(hitPos);
                Ray quadRay = quadCamera.ViewportPointToRay(hitPos);
                if (Physics.Raycast(quadRay, out RaycastHit quadHit))
                {
                    // 改变选中物体的颜色
                    //quadHit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
                    
                    print($"QuadRay hit {quadHit.transform.name}, pos: {quadHit.transform.position}");
                    _targetTransform = quadHit.transform;
                    _zValue = quadCamera.ViewportToScreenPoint(quadHit.transform.position).z;
                    print($"zValue: {_zValue}");
                }
            }
        } else if (Input.GetMouseButton(0))
        {
            if (_targetTransform is null) return;

            Vector3 mousePos = Input.mousePosition;
            mousePos.z = _zValue;
            _targetTransform.position = quadCamera.ScreenToViewportPoint(mousePos);
        } else if (Input.GetMouseButtonUp(0))
        {
            _targetTransform = null;
        }
    }
}
