using UnityEngine;

public class Star : MonoBehaviour
{
    public void ChangeUV()
    {
        GetComponent<MeshRenderer>().material.SetTextureOffset("_MainTex", new Vector2(0.5f, 0));
    }
}
