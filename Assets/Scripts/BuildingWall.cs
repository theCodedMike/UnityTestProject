using UnityEngine;

public class BuildingWall : MonoBehaviour
{
    [Header("砖块")]
    public GameObject block;
    [Header("宽")]
    public int width = 10;
    [Header("高")]
    public int height = 4;
    // Start is called before the first frame update
    void Start()
    {
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                var clone = Instantiate(block, new Vector3(x, y, 0), Quaternion.identity);
                if (clone.TryGetComponent<MeshRenderer>(out var mr))
                {
                    mr.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
                }
            }
        }
    }
}
