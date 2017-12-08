using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject cloudPrefab;
    public float waitBeforaStart = 2f;
    public float repeatTime = 5f;

    public float z = 0;
    // Use this for initialization
    void Start() {
        InvokeRepeating("Spawn", waitBeforaStart, repeatTime);
    }

    private void Spawn() {
        float x = gameObject.transform.position.x + Random.Range(-2, 2);
        float y = gameObject.transform.position.y + Random.Range(-2, 2);
        Instantiate(cloudPrefab, new Vector3(x, y, z), Quaternion.identity);
    }
}
