using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public Aidkit aidkitPrefab;
    private Aidkit _aidkit;    
    public float delayMin = 3;
    public float delayMax = 9;
    private List<Transform> _spawnerPoints;

    private void Start()
    {
        //spawnerPoints = new List<Transform>(transform.GetComponentsInChildren<Transform>());
        _spawnerPoints = new List<Transform>();
        foreach (Transform child in transform)
        {
            _spawnerPoints.Add(child);
        }
    }
    private void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;
        
        Invoke("CreateAidkit", Random.Range(delayMin, delayMax));
        //Invoke("CreateAidkit", delay);
    }
    private void CreateAidkit()
    {
        _aidkit = Instantiate(aidkitPrefab);
        Debug.Log("_spawnerPoints.Count=" + _spawnerPoints.Count);
        _aidkit.transform.position = _spawnerPoints[Random.Range(0, _spawnerPoints.Count)].position;
        Debug.Log("_aidkit.transform.position=" + _aidkit.transform.position.x);
    }
}
