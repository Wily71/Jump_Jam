using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    // Components 
    private Rigidbody2D _rigidbody2D;
    
    // Capsule
    public float capsuleHeight = 0.25f;
    public float capsuleRadius = 0.08f;

    // Ground Check 
    public Transform feetCollider;
    public LayerMask groundMask;
    private bool _groundCheck;

    // Forces 
    public float jumpForce = 10;
    public float fallForce = 2;
    private Vector2 _gravityVector;
    
    // Sets gravity vector and connects components 
    private void Start() {
        _gravityVector = new Vector2(0, Physics2D.gravity.y);
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
   private void Update() {
        // Checks if player is touching ground 
        _groundCheck = Physics2D.OverlapCapsule(feetCollider.position, 
            new Vector2(capsuleHeight, capsuleRadius), CapsuleDirection2D.Horizontal,
            0, groundMask);

        // Checks if player is trying to jump/can jump 
        if (Input.GetKeyDown(KeyCode.Space) && _groundCheck) {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpForce);
        }

        // Checks if the gravity should be getting faster 
        if(_rigidbody2D.velocity.y < 0) {
            _rigidbody2D.velocity += _gravityVector * (fallForce * Time.deltaTime);
        }
    }
}
