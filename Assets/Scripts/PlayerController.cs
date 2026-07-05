using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
    public float moveSpeed = 5f;
    public bool autoRun = false;
    
    Vector2 inputMove;
    CharacterController controller;
    
    void Start() => controller = GetComponent<CharacterController>();

    void OnMove(InputValue v) => inputMove = v.Get<Vector2>();
    void OnToggleAutoRun() => autoRun = !autoRun;

    void Update() {
        Vector3 moveDir = new(inputMove.x, 0, inputMove.y);
        if (autoRun && inputMove == Vector2.zero)
            moveDir = transform.forward;
            
        controller.Move(moveDir * moveSpeed * Time.deltaTime);
        
        if (inputMove.magnitude > 0.1f) {
            Quaternion targetRot = Quaternion.LookRotation(inputMove);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 0.2f);
        }
    }
}