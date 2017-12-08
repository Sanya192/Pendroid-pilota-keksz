/*
    ==================================================================
    Megvalósított funckiók:
        állítható gravitáció
        szél
        speciális effektek (az ellenfelek robbanásakor)
        több terep és pálya
        többféle célpont
        
        állítható a szél sebessége
        menürendszer
        zene
        hangok
        felhők, amelyek reagálnak a szélre
        pattogás a földön
        ejtőernyő segítség (pályánként egyszer használható fel)
        mindegyik pálya kijátszható.
    =================================================================
 */
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Ball : MonoBehaviour {

    private Rigidbody2D rigidBody;
    private CircleCollider2D circleCollider;
    public SpriteRenderer spriteRenderer;

    public GameObject parachutePrefab;
    public bool last;
    public bool physicsEnabled = true;

    public float Radius {
        get { return circleCollider.radius; }
    }

    void Awake() {
        rigidBody = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody.drag = 0.5f;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update() {

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
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.BallShoot);
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other) {
        SoundManager.Instance.PlayOneShot(SoundManager.Instance.CollisionSound);
    }

    public void UseParachute() {
        GameObject parachuteClone = Instantiate(parachutePrefab, gameObject.transform.position, Quaternion.identity);
        parachuteClone.gameObject.transform.parent = gameObject.transform;
        rigidBody.drag = 20f;
    }
}
