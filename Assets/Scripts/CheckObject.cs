using UnityEngine;

public class CheckObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Good"))
        {
            UIManager.Instance.DropHP();
        }
        else if(other.CompareTag("Bad"))
        {
            UIManager.Instance.CheckWin();
        }
    }
}
