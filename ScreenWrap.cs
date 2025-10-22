using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private float screenLeft;
    private float screenRight;
    private float screenTop;
    private float screenBottom;

    void Start()
    {
        mainCamera = Camera.main;

        // Get screen bounds in world units
        //ViewportToWorldPoint is normalized coordinate system for the screen
        //(0,0,0).x - bottom left edge, (1,0,0).x - bottom right edge
        //(0,0,0).y - top left edge, (0,1,0).y - top right edge

        screenLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        screenRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        screenBottom = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        screenTop = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
    }

    void Update()
    {
        Vector3 pos = transform.position;

        if (pos.x < screenLeft)
            pos.x = screenRight;
        else if (pos.x > screenRight)
            pos.x = screenLeft;

        if (pos.y < screenBottom)
            pos.y = screenTop;
        else if (pos.y > screenTop)
            pos.y = screenBottom;

        transform.position = pos;
    }
}
