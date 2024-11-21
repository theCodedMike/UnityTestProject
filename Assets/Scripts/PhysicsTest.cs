using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Physics.BoxCast(transform.position, Vector3.one * 0.5f, Vector3.forward, out RaycastHit hit1, Quaternion.identity))
        {
            print(hit1.transform.name);
        }
        
    }
}
