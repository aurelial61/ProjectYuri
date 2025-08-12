using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject manager;
    public bool hit;
    public float timer;
    public float hitTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = manager.GetComponent<RhythmScript>().timer;
        
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        
        if ((Input.GetKeyDown(KeyCode.Space)))
        {
            if ((hitTime - timer <= 0.15f && hitTime - timer > 0.1f) || (hitTime - timer < -0.1f && hitTime - timer >= -0.15f))
            {
                manager.GetComponent<RhythmScript>().score++;
            }
            else if ((hitTime - timer <= 0.10f && hitTime - timer > 0.02f) || (hitTime - timer < -0.02f && hitTime - timer >= -0.1f))
            {
                manager.GetComponent<RhythmScript>().score += 2;
            }
            else if ((hitTime - timer >= -0.02f && hitTime - timer <= 0.02f))
            {
                manager.GetComponent<RhythmScript>().score += 3;
            }
            else if (hitTime - timer < 0.25f)
            {
                manager.GetComponent<RhythmScript>().score--;
            }

            if (hitTime - timer <= 0.25f)
            {
                Destroy(gameObject);
            }
            
        }
        
    }
}
