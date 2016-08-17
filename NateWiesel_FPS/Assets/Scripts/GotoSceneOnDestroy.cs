using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GotoSceneOnDestroy : MonoBehaviour
{
    //public int number;
    // Update is called once per frame
    void Update()
    {

    }
    void OnDestroy()
    {
        Debug.Log("Portal is dead!!!!!!");
        Overlord.Instance.Restart();
    }
}
