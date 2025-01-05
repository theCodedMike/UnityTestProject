using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public Transform target;

    public Transform targetUI;
    
    private Camera _mainCamera;

    private Transform _mergeTarget;

    private float _zValue;
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //ScreenPointToRay();
        //WorldToScreenPoint();
        Merge();
    }

    // 将二维屏幕的操作转换为三维游戏中的操作  屏幕转世界
    void ScreenPointToRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                print($"Hit something: {hit.transform.name}");
                hit.transform.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }
        }
    }

    // 世界转屏幕
    void WorldToScreenPoint()
    {
        Vector3 pos = _mainCamera.WorldToScreenPoint(target.position);
        var mousePosition = Input.mousePosition;
        mousePosition.z = pos.z;
        target.position = _mainCamera.ScreenToWorldPoint(mousePosition);
    }

    void Merge()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                _mergeTarget = hit.transform;
                _zValue = _mainCamera.WorldToScreenPoint(_mergeTarget.position).z;
            }
        } else if (Input.GetMouseButton(0))
        {
            if (_mergeTarget is null) return;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _zValue;
            _mergeTarget.position = _mainCamera.ScreenToWorldPoint(mousePosition);
        } else if (Input.GetMouseButtonUp(0))
        {
            _mergeTarget = null;
        }
    }
}
