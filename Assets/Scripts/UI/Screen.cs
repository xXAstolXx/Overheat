using UnityEngine;

public abstract class Screen : MonoBehaviour
{
    private bool isActive;

    private void Start()
    {
        isActive = false;
        gameObject.SetActive(isActive);
    }

    public virtual void ShowScreen()
    {
        isActive = true;
        gameObject.SetActive(isActive);
    }

    public void HideScreen()
    {
        isActive = false;
        gameObject.SetActive(isActive);
    }
}
