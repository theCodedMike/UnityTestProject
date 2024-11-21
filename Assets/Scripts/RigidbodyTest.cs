using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody[] rbs = GameObject.FindObjectsOfType<Rigidbody>();
            foreach (var item in rbs)
            {
                item.AddExplosionForce(10f, new Vector3(5, 0, 0), 10, 0, ForceMode.Impulse);
            }
        }
    }
}
