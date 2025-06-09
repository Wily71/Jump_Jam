using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;
    private Rigidbody2D _rigidbody2D;
    
    // Start is called before the first frame update
    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update() {
        float horizontal = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(horizontal * speed, _rigidbody2D.velocity.y);
    }
}
