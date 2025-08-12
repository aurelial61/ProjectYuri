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
    
    public float timer;
    public float hitTime;
    public float endHitTime;
    public float spb;
    public float beatTimer;
    public GameObject perfect;
    public GameObject great;
    public GameObject good;
    public GameObject miss;
    
    void Start()
    {
        endHitTime = hitTime + duration;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject thisNote = Instantiate(notePrefab, transform.position, Quaternion.identity);
        thisNote.GetComponent<NoteScript>().speed = speed;
        thisNote.GetComponent<NoteScript>().hitTime = hitTime;
        thisNote.GetComponent<NoteScript>().manager = manager;

    }
}
