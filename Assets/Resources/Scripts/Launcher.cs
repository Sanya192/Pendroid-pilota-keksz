using UnityEngine;

public class Launcher : MonoBehaviour {

    /// <summary>
    /// Prefb for the ball being launched
    /// </summary>
    [Tooltip("The prefab for the ball being launched")]
    [SerializeField]
    private GameObject ballPrefab;

    /// <summary>
    /// The balls in order of launch. The first one is at index 0
    /// </summary>
    private Ball[] balls;

    /// <summary>
    /// The ball types before launching anything
    /// </summary>
    [SerializeField]
    [Tooltip("What kind of ball to launch from this launcher. The first ball is at index 0.")]
    private BallType[] ballTypes;

    /// <summary>
    /// The index of the current ball in the <see cref="balls"/> array
    /// </summary>
    private int currBallIndex = 0;
    /// <summary>
    /// The current ball from the <see cref="balls"/> array
    /// </summary>
    private Ball CurrBall {
        get { return balls[currBallIndex]; }
    }

    public Ball FlyingBall {
        get {
            if (currBallIndex > 0)
                return balls[currBallIndex - 1];
            else
                return null;
        }
    }

    [SerializeField]
    private float maxLaunchSpeed = 100f;

    [SerializeField]
    private float maxLaunchRadiusPercent = 0.1f;
    /// <summary>
    /// Radius of max launch strength in pixels
    /// </summary>
    private float maxLaunchRadius;

    private void Start() {
        // instantiate all balls in ballType
        balls = new Ball[ballTypes.Length];
        for (int i = 0; i < ballTypes.Length; i++) {
            balls[i] = Instantiate(ballPrefab, transform).GetComponent<Ball>();
            balls[i].tag = "Ball";
            balls[i].DisablePhysics();
            balls[i].name = "Ball " + i;

            // move it a bit back
            if (i > 0) {
                balls[i].transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                balls[i].transform.position = balls[i - 1].transform.position - new Vector3(balls[i - 1].Radius * 2, 0, 0);
            }
        }
        balls[balls.Length-1].last = true;
        maxLaunchRadius = Camera.main.pixelWidth * maxLaunchRadiusPercent;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, (Camera.main.orthographicSize * 2) * maxLaunchRadiusPercent);
    }

    private Vector2 touchEndPos = new Vector3();
    private bool isDragging = false;
    private void Update() {
        Vector2 launcherScreenPos = Camera.main.WorldToScreenPoint(transform.position);

#if UNITY_EDITOR || UNITY_STANDALONE
        Vector2 mousePosition = Input.mousePosition;

        // only start pulling if the ball was touched
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mouseScreePos = Camera.main.ScreenToWorldPoint(mousePosition);
            mouseScreePos.z = 0;

            // the ball was touched
            if ((CurrBall.transform.position - mouseScreePos).magnitude <= CurrBall.Radius) {
                isDragging = true;
            }
        }

        if (Input.GetMouseButton(0) && isDragging) {
            // get how much we moved from launcher on screen
            Vector2 mouseDelta = mousePosition - launcherScreenPos;

            float dist = mouseDelta.magnitude;

            // we are too far away from the launcher -> shrink it to the max
            if (dist > maxLaunchRadius) {
                touchEndPos = launcherScreenPos + mouseDelta * (maxLaunchRadius / dist);
            } else {
                touchEndPos = mousePosition;
            }
        }

        // launch the ball
        if (Input.GetMouseButtonUp(0) && isDragging) {
            // in which way
            Vector3 launchVector = launcherScreenPos - touchEndPos;
            // whith what power
            float launchPower = launchVector.magnitude / maxLaunchRadius * maxLaunchSpeed;

            LaunchCurrentBall(launchVector.normalized * launchPower);

            // stop the launching process
            isDragging = false;
        }
#endif
#if UNITY_ANDROID

#endif
    }

    /// <summary>
    /// Launches current bal the puts the next one on the launcher
    /// </summary>
    /// <param name="force">The force with which to launch the ball</param>
    private void LaunchCurrentBall(Vector2 force) {
        // launch ball
        CurrBall.Launch(force);

        currBallIndex++;
        // out of balls
        if (currBallIndex >= balls.Length) {

        } else {
            // reset ball and move to launching pos
            CurrBall.transform.localScale = new Vector3(1f, 1f, 1f);
            CurrBall.transform.localPosition = new Vector3();

            // move other balls
            for (int i = currBallIndex + 1; i < balls.Length; i++) {
                balls[i].transform.position = balls[i - 1].transform.position - new Vector3(balls[i - 1].Radius * 2, 0, 0);
            }
        }
    }

}
