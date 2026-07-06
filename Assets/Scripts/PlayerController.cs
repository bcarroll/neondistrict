using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public bool autoRun = false;
    
    Vector3 moveInput;
    CharacterController controller;
    
    void Start() => controller = GetComponent<CharacterController>();

    void Update() {
        // Get input from keyboard
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        if (autoRun && h == 0f && v == 0f) {
            moveInput = transform.forward;
        } else {
            moveInput = new Vector3(h, 0, v);
        }
            
        controller.Move(moveInput * moveSpeed * Time.deltaTime);
        
        if (moveInput.magnitude > 0.1f) {
            Quaternion targetRot = Quaternion.LookRotation(moveInput);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 0.2f);
        }
    }
}
