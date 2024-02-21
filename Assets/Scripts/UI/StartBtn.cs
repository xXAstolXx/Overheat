using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("trigger start");
        SceneManager.LoadScene(sceneIndex);
    }
}
