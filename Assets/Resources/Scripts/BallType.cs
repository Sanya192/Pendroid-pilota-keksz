using UnityEngine;

[CreateAssetMenu(fileName = "MyBalls", menuName = "New Ball")]
public class BallType : ScriptableObject {

    [SerializeField]
    private Sprite ballTexture;

    [SerializeField]
    private float radius = 0.5f;
	
}
