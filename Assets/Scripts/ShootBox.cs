using UnityEngine;

public class ShootBox : MonoBehaviour
{
    [Header("桌面")]
    public Transform allCubes;
    [Header("旋转速度")]
    public float rotateSpeed = 5f;
    [Header("红色小球")]
    public GameObject redBall;
    [Header("发射小球的力")]
    public float launchForce = 50f;
    
    private Camera _mainCamera;
    private bool _isMouseMove; // 鼠标是否在移动
    
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
            if (_isMouseMove) return;

            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            GameObject clone = Instantiate(redBall, _mainCamera.transform.position, Quaternion.identity);
            if (clone.TryGetComponent(out Rigidbody rb))
            {
                rb.AddForce((ray.origin - _mainCamera.transform.position) * launchForce, ForceMode.Impulse);
            }
            Destroy(clone, 2f);
        } else if (Input.GetMouseButton(0))
        {
            float horDistance = Input.GetAxis("Mouse X");
            _isMouseMove = horDistance != 0;
            if (_isMouseMove)
            { // 转动场景
                //_mainCamera.Rotate(Vector3.up * rotate);
                allCubes.Rotate(Vector3.down * (horDistance * rotateSpeed));
            }
        } else if (Input.GetMouseButtonUp(0))
        {
            _isMouseMove = false;
        }
    }
}
