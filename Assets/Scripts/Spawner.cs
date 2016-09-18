using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawnPrefab;

    public float minSecondsBetweenSpawning = 3.0f;
    public float maxSecondsBetweenSpawning = 6.0f;

    private float timePassed = 0f;
    private float spawnCD = 0f;

    // Use this for initialization
    void Start () {
        spawnCD = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
    }

    // Update is called once per frame
    void Update () {
        timePassed += Time.deltaTime;
        if (timePassed > spawnCD) // is it time to spawn again?
        {
            Spawn();
            timePassed = 0f;
            spawnCD = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
        }
    }

    void Spawn()
    {
        // create a new gameObject
        Instantiate(spawnPrefab, transform.position, transform.rotation);

    }
}
