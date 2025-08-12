using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float duration;
    public GameObject manager;
    public GameObject notePrefab;
    public GameObject tracePrefab;
    public float timer;
    public float hitTime;
    public float endHitTime;
    public float spb;
    public float beatTimer;
    public float spawnDistance;
    public GameObject perfect;
    public GameObject great;
    public GameObject good;
    public GameObject miss;
    public GameObject releasePrefab;
    public KeyCode key;
    
    public bool release;
    void Start()
    {
        endHitTime = hitTime + duration;
        
        GameObject thisNote = Instantiate(notePrefab, transform.position, Quaternion.identity);
        thisNote.GetComponent<NoteScript>().speed = speed;
        thisNote.GetComponent<NoteScript>().hitTime = hitTime;
        thisNote.GetComponent<NoteScript>().manager = manager;
        thisNote.GetComponent<NoteScript>().key = key;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = manager.GetComponent<RhythmScript>().timer;
        beatTimer += Time.deltaTime;
        if (beatTimer > spb * 0.2f)
        {
            GameObject traceNote = Instantiate(tracePrefab, transform.position, Quaternion.identity);
            traceNote.GetComponent<TraceScript>().speed = speed;
            traceNote.GetComponent<TraceScript>().hitTime = timer + spawnDistance / speed;
            traceNote.GetComponent<TraceScript>().manager = manager;
            traceNote.GetComponent<TraceScript>().key = key;
            beatTimer = 0;
            
        }

        if (timer > endHitTime - spawnDistance / speed)
        {
            GameObject thisNote = Instantiate(releasePrefab, transform.position, Quaternion.identity);
            thisNote.GetComponent<ReleaseScript>().speed = speed;
            thisNote.GetComponent<ReleaseScript>().hitTime = endHitTime;
            thisNote.GetComponent<ReleaseScript>().manager = manager;
            thisNote.GetComponent<ReleaseScript>().key = key;
            Destroy(gameObject);
        }

        

    }
}
