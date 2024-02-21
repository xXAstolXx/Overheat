using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartBtn : MonoBehaviour
{
    [SerializeField]
    private int sceneIndex;

    [SerializeField]
    private Slider slider;

    private void Start()
    {
        slider.maxValue = 10;
        slider.minValue = 0;
        slider.value = slider.minValue;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        slider.value += 0.1f;
        if(slider.value == slider.maxValue)
        {
            LoadSceneByIndex(sceneIndex);
        }
    }

    private void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
}
