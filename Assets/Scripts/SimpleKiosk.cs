using UnityEngine;

public class SimpleKiosk : MonoBehaviour {
    public string questName = "Fuel Run";
    
    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Player")) {
            Debug.Log($"Quest Available: {questName}");
            GetComponent<Renderer>().material.color = Color.red;
            Invoke(nameof(ResetColor), 0.3f);
        }
    }
    
    void ResetColor() => GetComponent<Renderer>().material.color = Color.white;
}