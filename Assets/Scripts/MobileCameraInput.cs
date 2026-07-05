using UnityEngine;

public class MobileCameraInput : MonoBehaviour {
    public CameraManager cameraManager;
    private float tapTime = 0f;
    
    void Update() {
        if (Input.touchCount <= 0 || Input.GetTouch(0).phase != TouchPhase.Began) return;
        
        Vector2 touchPos = Input.GetTouch(0).position;
        float centerDist = Vector2.Distance(touchPos, new Vector2(Screen.width/2, Screen.height/2));
        if (centerDist < Screen.width * 0.15f && Time.unscaledTime - tapTime < 0.3f) {
            cameraManager.SwitchView(CameraManager.ViewMode.Isometric);
        }
        tapTime = Time.unscaledTime;
    }
}