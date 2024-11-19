using UnityEngine;

public class EngineControl : MonoBehaviour
{
    [Header("摄像头移动速度")]
    public float rotateSpeed = 0.5f;
    [Header("层过滤标志")]
    public LayerMask layerMask;
    public Transform left4;
    public Transform left3;
    public Transform left2;
    public Transform left1;
    
    public Transform right1;
    public Transform right2;
    public Transform right3;
    public Transform right4;

    private Camera _mainCamera;
    private Vector3 _localEulerAnglesOfMainCamera;
    private Transform _target; // 鼠标点击的物体
    private float _zValue;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _localEulerAnglesOfMainCamera = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        _localEulerAnglesOfMainCamera.y += Input.GetAxis("Mouse X") * rotateSpeed;
        _localEulerAnglesOfMainCamera.y = Mathf.Clamp(_localEulerAnglesOfMainCamera.y, -60f, 60f);
        _localEulerAnglesOfMainCamera.x -= Input.GetAxis("Mouse Y");
        _localEulerAnglesOfMainCamera.x = Mathf.Clamp(_localEulerAnglesOfMainCamera.x, -20f, 15f);
        transform.localEulerAngles = _localEulerAnglesOfMainCamera;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 80; i++)
            {
                right1.Translate(Vector3.right * 0.2f);
                left1.Translate(Vector3.left * 0.2f);
                
                right2.Translate(Vector3.right * 0.3f);
                left2.Translate(Vector3.left * 0.3f);
                
                right3.Translate(Vector3.right * 0.4f);
                left3.Translate(Vector3.left * 0.4f);
                
                right4.Translate(Vector3.right * 0.5f);
                left4.Translate(Vector3.left * 0.5f);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            print(Input.mousePosition);
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100, layerMask))
            {
                print("Enter here...");
                _target = hit.transform;
                _zValue = _mainCamera.WorldToScreenPoint(_target.position).z;
            }
        } else if (Input.GetMouseButton(0))
        {
            if (_target is null) return;
            
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = _zValue;
            _target.position = _mainCamera.ScreenToWorldPoint(mousePosition);
        } else if (Input.GetMouseButtonUp(0))
        {
            _target = null;
        }
    }
}
