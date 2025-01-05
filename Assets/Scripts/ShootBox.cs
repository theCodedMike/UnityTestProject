using UnityEngine;

public class ShootBox : MonoBehaviour
{
    [Header("旋转速度")]
    public float rotateSpeed = 5f;
    [Header("红色小球")]
    public GameObject redBall;
    
    
    private Camera _mainCamera;
    private Vector3 _localEulerAngles;
    private Vector3 _startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _localEulerAngles = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _startPosition = Input.mousePosition;
        } else if (Input.GetMouseButton(0))
        {
            float horDistance = Input.GetAxis("Mouse X");
            _localEulerAngles.y += horDistance * rotateSpeed * Time.deltaTime;
            transform.localEulerAngles = _localEulerAngles;
        } else if (Input.GetMouseButtonUp(0))
        {

            if ((Input.mousePosition - _startPosition).sqrMagnitude >= Screen.width / 10f)
                return;
            
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            GameObject clone = ObjectPool.GetInstance().GetObject("bullet", redBall, ray.GetPoint(2f), Quaternion.identity);

            
            if (clone.TryGetComponent(out Rigidbody rb))
            {
                //rb.AddForce(ray.direction * launchForce, ForceMode.Impulse);
                rb.velocity = ray.direction;
            }
            Destroy(clone, 2f);
        }
    }
}
