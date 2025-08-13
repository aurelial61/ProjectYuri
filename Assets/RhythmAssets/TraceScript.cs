using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraceScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject manager;
    public KeyCode key;
    public float timer;
    public float hitTime;
    public GameObject perfect;
    public GameObject miss;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = manager.GetComponent<RhythmScript>().timer;
        
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        
        if ((Input.GetKey(key)))
        {
            if ((hitTime - timer >= -0.02f && hitTime - timer <= 0.02f))
            {
                manager.GetComponent<RhythmScript>().score += 1;
                manager.GetComponent<RhythmScript>().combo++;
                Instantiate(perfect);
                Destroy(gameObject);
            }
            
            
            
        }
        if (hitTime - timer < -0.02f)
        {
            manager.GetComponent<RhythmScript>().score -= 3;
            manager.GetComponent<RhythmScript>().combo = 0;
            Instantiate(miss);
            manager.GetComponent<RhythmScript>().fullCombo = false;
            manager.GetComponent<RhythmScript>().allPerfect = false;
            Destroy(gameObject);
        }

    }
}
