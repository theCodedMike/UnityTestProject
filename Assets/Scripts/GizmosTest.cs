using UnityEngine;

public class GizmosTest : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        // 注意这里的资源不需要后缀
        Gizmos.DrawIcon(transform.position, "叹号2");
    }
}
