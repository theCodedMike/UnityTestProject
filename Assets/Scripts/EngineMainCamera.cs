using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineMainCamera : MonoBehaviour
{
    [Header("摄像头向左旋转最大角度")]
    public float minLeftRightRotateDegree = -50f;
    [Header("摄像头移向右旋转最大角度")]
    public float maxLeftRightRotateDegree = 50f;
    [Header("摄像头向上旋转最大角度")]
    public float minUpDownRotateDegree = -20f;
    [Header("摄像头移向下旋转最大角度")]
    public float maxUpDownRotateDegree = 15f;
    
    private Vector3 _localEulerAngles;
    
    // Start is called before the first frame update
    void Start()
    {
        _localEulerAngles = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        _localEulerAngles.y += Input.GetAxis("Mouse X");
        _localEulerAngles.y = Mathf.Clamp(_localEulerAngles.y, minLeftRightRotateDegree, maxLeftRightRotateDegree);
        _localEulerAngles.x -= Input.GetAxis("Mouse Y");
        _localEulerAngles.x = Mathf.Clamp(_localEulerAngles.x, minUpDownRotateDegree, maxUpDownRotateDegree);
        transform.localEulerAngles = _localEulerAngles;
    }
}
