
using UnityEngine;

public class InputTest : MonoBehaviour
{
    [Header("方块")]
    public Transform cube;

    public float moveSpeed = 10f;
    public float rotateSpeed = 1f;

    private Vector3 _localEulerAnglesOfCube;

    private Vector3 _localEulerAnglesOfCamera;
    // Start is called before the first frame update
    void Start()
    {
        _localEulerAnglesOfCube = cube.localEulerAngles;
        _localEulerAnglesOfCamera = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //GetAxis();
        GetButton();
    }

    // 该系列方法的返回值在[-1,1]之间
    void GetAxis()
    {
        // 控制方块的前后左右移动
        cube.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (Time.deltaTime * moveSpeed));
        
        // 控制方块视野随着鼠标左右移动而左右移动(本质上是方块沿y周旋转)
        _localEulerAnglesOfCube.y += Input.GetAxis("Mouse X");
        cube.localEulerAngles = _localEulerAnglesOfCube * rotateSpeed;

        // 控制方块视野随着鼠标上下移动而上下移动(本质上是主相机沿x轴旋转)
        _localEulerAnglesOfCamera.x -= Input.GetAxis("Mouse Y");
        _localEulerAnglesOfCamera.x = Mathf.Clamp(_localEulerAnglesOfCamera.x, -45f, 30f);
        transform.localEulerAngles = _localEulerAnglesOfCamera;
    }

    // 该系列方法的返回值为bool
    void GetButton()
    {
        if (Input.GetButtonDown("Fire1")) // 点击鼠标左键，向前移动
        {
            Debug.Log(Input.mousePosition);
            cube.Translate(Vector3.forward * (Time.deltaTime * moveSpeed));
        }

        if (Input.GetButtonDown("Jump")) // 按space按键，向右移动
        {
            cube.Translate(Vector3.right * (Time.deltaTime * moveSpeed));
        }
    }
}
