using UnityEngine;

// 以圆形形式实例化预制件
public class CircleFormation : MonoBehaviour
{
    [Header("预制件Block")]
    public GameObject block;
    [Header("克隆个数")]
    public int numberOfObjects = 20;
    [Header("半径")]
    public float radius = 5f;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = radius * Mathf.Cos(angle);
            float z = radius * Mathf.Sin(angle);
            Vector3 position = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(block, position, rot);
        }
    }
}
