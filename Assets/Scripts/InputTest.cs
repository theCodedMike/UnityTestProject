
using UnityEngine;

public class InputTest : MonoBehaviour
{
    [Header("方块")]
    public Transform cube;

    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;

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
        // 控制方块的前后左右移动
        cube.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * (Time.deltaTime * moveSpeed));
        // 控制方块视野左右移动
        _localEulerAnglesOfCube.y += Input.GetAxis("Mouse X");
        cube.localEulerAngles = _localEulerAnglesOfCube * rotateSpeed;

        _localEulerAnglesOfCamera.x -= Input.GetAxis("Mouse Y");
        _localEulerAnglesOfCamera.x = Mathf.Clamp(_localEulerAnglesOfCamera.x, -45f, 30f);
        transform.localEulerAngles = _localEulerAnglesOfCamera;
    }
}
