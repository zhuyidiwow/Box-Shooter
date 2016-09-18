using UnityEngine;

public class ZombieBehavior : MonoBehaviour {

    public float moveSpeed = 1f;

    public int scoreAmount;
    public int timeAmount;

    public GameObject explosion;
    private Vector3 targetAngle;

    public Vector3 moveDirection = new Vector3(0, 0, 1);

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);

        //        turnAroundTimer -= Time.deltaTime;
        //        if (turnAroundTimer < 0) {
        //            turnAroundTimer = 3f;
        //            TurnAround();
        //            Debug.Log(moveDirection);
        //        }
    }

    void OnCollisionEnter(Collision collision) {

        if (GameManager.gm) {
            if (GameManager.gm.gameIsOver)
                return;
        }

        if (collision.gameObject.tag != "Ground") {
            TurnAround();
        }

        // only do stuff if hit by a projectile
        if (collision.gameObject.tag == "Projectile") {
            if (explosion) {
                // Instantiate an explosion effect at the gameObjects position and rotation
                Instantiate(explosion, transform.position, transform.rotation);
            }

            // if game manager exists, make adjustments based on target properties
            if (GameManager.gm) {
                GameManager.gm.targetHit(scoreAmount, timeAmount);
            }

            // destroy the projectile
            Destroy(collision.gameObject);

            // destroy self
            Destroy(gameObject);
        }

    }

    void TurnAround() {
        targetAngle = transform.eulerAngles + 180f * Vector3.up;
        transform.eulerAngles = targetAngle;
        moveDirection *= -1f;
    }
}
