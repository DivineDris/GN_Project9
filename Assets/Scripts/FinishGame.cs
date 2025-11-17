using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKeyDown)
        {
            Application.Quit();
        }
    }
}
