using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private void Awake()
    {
        SetOrthographicSize();
    }

    private void SetOrthographicSize()
    {
        var currentAspect = (float) Screen.width / (float) Screen.height;
        Camera.main.orthographicSize = 1920 / currentAspect / 105;
    }
}