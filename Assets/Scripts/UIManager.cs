using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public Star[] starts;
    private int hp = 3;
    private int badCount = 4;
    void Awake()
    {
        Instance = this;
    }
    
    public void DropHP()
    {
        hp--;
        if (hp < 0)
        {
            print("YOU LOSE!!!");
            return;
        }
        starts[hp].ChangeUV();
    }

    public void CheckWin()
    {
        badCount--;
        if (badCount == 0)
            print("YOU WIN!!!");
    }
}
