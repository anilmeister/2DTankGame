using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackMarkSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector2 lastPosition;
    public float trackDistance = 0.2f;
    public GameObject trackPrefab;
    public int objectPoolSize = 20;

    private ObjectPool objectPool;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>();
    }
    private void Start()
    {
        lastPosition = transform.position;
        objectPool.Initialize(trackPrefab, objectPoolSize);
    }

    // Update is called once per frame
    private void Update()
    {
        var distanceDriven = Vector2.Distance(transform.position, lastPosition);

        if (distanceDriven >= trackDistance)
        {
            lastPosition = transform.position;
            var tracks = objectPool.CreateObject();
            tracks.transform.position = transform.position;
            tracks.transform.rotation = transform.rotation;
        }
        
    }
}
