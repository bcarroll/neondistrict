// CameraManager.cs — manages view switching + lerp smoothing
using UnityEngine;

public class CameraManager : MonoBehaviour {
    public enum ViewMode { Isometric, ThirdPerson, FirstPerson }
    
    [Header("References")]
    public Transform player;
    public Camera mainCamera;
    
    [Header("Settings")]
    public Vector3 isoOffset = new(0f, 12f, -8f);
    public float cameraLerpSpeed = 5f;

    private ViewMode currentMode = ViewMode.ThirdPerson;

    void Start() { SwitchView(ViewMode.ThirdPerson); }

    public void SwitchView(ViewMode mode) {
        currentMode = mode;
        switch (mode) {
            case ViewMode.Isometric:
                mainCamera.transform.position = player.position + isoOffset;
                mainCamera.transform.rotation = Quaternion.Euler(45f, 30f, 0f);
                break;
            case ViewMode.ThirdPerson:
                mainCamera.transform.SetParent(player);
                mainCamera.transform.localPosition = new Vector3(0f, 2.5f, -4f);
                mainCamera.transform.localRotation = Quaternion.identity;
                break;
            case ViewMode.FirstPerson:
                mainCamera.transform.SetParent(player);
                mainCamera.transform.localPosition = new Vector3(0f, 1.6f, 0.8f);
                mainCamera.transform.localRotation = Quaternion.identity;
                break;
        }
    }

    void LateUpdate() {
        if (currentMode == ViewMode.Isometric) {
            Vector3 targetPos = player.position + isoOffset;
            mainCamera.transform.position = 
                Vector3.Lerp(mainCamera.transform.position, targetPos, Time.deltaTime * cameraLerpSpeed);
        }
    }
}