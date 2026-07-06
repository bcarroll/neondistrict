using UnityEngine;
using System.Collections;

public class SmoothCameraTransition : MonoBehaviour {
    public float transitionDuration = 0.5f;
    
    private Coroutine routine;
    void Start() => enabled = false; // Only active during transitions

    public void BeginTransition() {
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(SmoothLerp());
    }

    IEnumerator SmoothLerp() {
        float elapsed = 0f;
        while (elapsed < transitionDuration) {
            float t = elapsed / transitionDuration;
            transform.position = Vector3.Lerp(transform.parent.position + new Vector3(0,12,-8), transform.position, t);
            yield return null;
            elapsed += Time.deltaTime;
        }
    }
}