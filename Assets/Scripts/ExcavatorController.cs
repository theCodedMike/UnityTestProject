using UnityEngine;

public class ExcavatorController : MonoBehaviour
{
    [Header("移动速度")]
    public float moveSpeed = 10f;
    [Header("旋转速度")]
    public float rotateSpeed = 50f;

    [Header("机身")]
    public Transform jiShen;
    [Header("大臂")]
    public Transform firstArm;
    [Header("小臂")]
    public Transform secondArm;
    [Header("铲斗")]
    public Transform bucket;
    
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("action/jishen/Object02/Loft04").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // 控制挖掘机前后移动
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));
        else if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * (moveSpeed * Time.deltaTime));
        
        // 控制挖掘机左右转向
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Vector3.down * (rotateSpeed * Time.deltaTime));
        else if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime));
        
        // 控制机身左右转向
        if (Input.GetKey(KeyCode.Q))
            jiShen.Rotate(Vector3.back * (rotateSpeed * Time.deltaTime));
        else if (Input.GetKey(KeyCode.E))
            jiShen.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));

        // 控制大臂
        if (Input.GetKey(KeyCode.Keypad4))
        {
            Vector3 eulerAngles = firstArm.localEulerAngles;
            eulerAngles.z = Mathf.Clamp(eulerAngles.z, 55, 130);
            firstArm.eulerAngles = eulerAngles;
            firstArm.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));
        }
        else if (Input.GetKey(KeyCode.Keypad1))
            firstArm.Rotate(Vector3.back * (rotateSpeed * Time.deltaTime));
        
        // 控制小臂
        if (Input.GetKey(KeyCode.Keypad5))
            secondArm.Rotate(Vector3.forward * (rotateSpeed * Time.deltaTime));
        else if (Input.GetKey(KeyCode.Keypad2))
            secondArm.Rotate(Vector3.back * (rotateSpeed * Time.deltaTime));

        // 控制铲斗
        if (Input.GetKey(KeyCode.Keypad6))
            bucket.Rotate(Vector3.right * (rotateSpeed * Time.deltaTime));
        else if (Input.GetKey(KeyCode.Keypad3))
            bucket.Rotate(Vector3.left * (rotateSpeed * Time.deltaTime));

    }
}
