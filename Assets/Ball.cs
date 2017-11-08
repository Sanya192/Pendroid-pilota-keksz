using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private CircleCollider2D circleCollider;
    public SpriteRenderer spriteRenderer;

    private bool physicsEnabled = true;
    
    public float Radius {
        get { return circleCollider.radius; }
    }
    
	void Awake () {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}

    public void DisablePhysics() {
        rigidBody.Sleep();
        circleCollider.enabled = false;

        physicsEnabled = false;
    }

    public void EnablePhysics() {
        rigidBody.WakeUp();
        circleCollider.enabled = true;

        physicsEnabled = true;
    }

    public void Launch(Vector2 force) {
        if (!physicsEnabled) {
            EnablePhysics();
        }

        rigidBody.AddForce(force, ForceMode2D.Impulse);
    }
}
