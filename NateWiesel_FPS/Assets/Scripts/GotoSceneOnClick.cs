using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoSceneOnClick : MonoBehaviour
{
    public int number;
    // Update is called once per frame
    void Start()
    {
        Cursor.visible = true;
    }
    void onClick()
    {
        go(number);
    }
    public void go(int num)
    {
        SceneManager.LoadScene(num);
    }
}
