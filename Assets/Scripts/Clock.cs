using System;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [Header("红色立方体")]
    public GameObject cube;
    [Header("绿色长方体")]
    public GameObject rect;
    [Header("时钟半径(最好>=5)")]
    public int radius = 10;
    [Header("时针")]
    public Transform hourHand;
    [Header("分针")]
    public Transform minuteHand;
    [Header("秒针")]
    public Transform secondHand;
    
    private const int NumOfCubes = 60;
    private const float OneRad = 2 * Mathf.PI / NumOfCubes; // 1/60弧度
    private long _lastTimeInSeconds;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < NumOfCubes; i++)
        {
            float rad = OneRad * i;
            float x = Mathf.Sin(rad) * radius;
            float y = Mathf.Cos(rad) * radius;
            Vector3 position = transform.position + new Vector3(x, y, 0);
            Quaternion quaternion = Quaternion.Euler(0, 0, -rad * Mathf.Rad2Deg);
            Instantiate(i % 5 == 0 ? rect : cube, position, quaternion);
        }
        
        DateTime start = DateTime.Now;
        _lastTimeInSeconds = start.Ticks / TimeSpan.TicksPerMillisecond / 1000;
        float second = start.Second;
        float minute = start.Minute + (second / 60);
        float hour = start.Hour % 12 + (minute / 60);
        secondHand.Rotate(Vector3.back, 6 * second);
        minuteHand.Rotate(Vector3.back, 6 * minute);
        hourHand.Rotate(Vector3.back, 30 * hour);
        //print($"{hour}:{minute}:{second}");
    }

    // Update is called once per frame
    void Update()
    {
        long nowInSeconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond / 1000;
        long secondsSpan = nowInSeconds - _lastTimeInSeconds;
        //print($"secondsSpan: {secondsSpan}");
        
        secondHand.Rotate(Vector3.back, 6 * secondsSpan);
        minuteHand.Rotate(Vector3.back, 6 * secondsSpan / 60f);
        hourHand.Rotate(Vector3.back, 30 * secondsSpan / 3600f);
        
        _lastTimeInSeconds = nowInSeconds;
    }
}
