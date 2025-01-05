using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject redBall;
    [Header("小球的发射速度")]
    public float launchSpeed = 50f;

    public void SetVelocity(Vector3 dir)
    {
        if (redBall.TryGetComponent(out Rigidbody rb))
        {
            rb.velocity = dir * launchSpeed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Terrain"))
        {
            Invoke(nameof(Disable), 2f);
        }
    }

    private void Disable()
    {
        GameObjectPool.GetInstance().PutObject("Bullet", gameObject);
    }
}
