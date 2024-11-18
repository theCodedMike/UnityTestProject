using UnityEngine;

public class ResourcesTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 这里不需要资源的后缀名
        Object pic = Resources.Load("1/RedCircle");
        Debug.Log(pic.name); // RedCircle

        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.material.mainTexture = pic as Texture;
    }
}
