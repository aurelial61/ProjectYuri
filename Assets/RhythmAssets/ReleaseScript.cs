using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject manager;
    public KeyCode key;
    public float timer;
    public float hitTime;
    public GameObject perfect;
    public GameObject great;
    public GameObject good;
    public GameObject miss;
    public GameObject effectPrefab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = manager.GetComponent<RhythmScript>().timer;
        
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        
        if ((Input.GetKeyUp(key)))
        {
            if ((hitTime - timer <= 0.15f && hitTime - timer > 0.1f) || (hitTime - timer < -0.1f && hitTime - timer >= -0.15f))
            {
                manager.GetComponent<RhythmScript>().score += 5;
                manager.GetComponent<RhythmScript>().combo = 0;
                manager.GetComponent<RhythmScript>().fullCombo = false;
                manager.GetComponent<RhythmScript>().allPerfect = false;
                Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Instantiate(good);
                
            }
            else if ((hitTime - timer <= 0.10f && hitTime - timer > 0.02f) || (hitTime - timer < -0.02f && hitTime - timer >= -0.1f))
            {
                manager.GetComponent<RhythmScript>().score += 10 + manager.GetComponent<RhythmScript>().combo / 10;
                
                manager.GetComponent<RhythmScript>().combo++;
                manager.GetComponent<RhythmScript>().allPerfect = false;
                Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Instantiate(great);
            }
            else if ((hitTime - timer >= -0.02f && hitTime - timer <= 0.02f))
            {
                manager.GetComponent<RhythmScript>().score += 15 + manager.GetComponent<RhythmScript>().combo / 10;
                manager.GetComponent<RhythmScript>().combo++;
                Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Instantiate(perfect);
            }
            else if (hitTime - timer < 0.20f)
            {
                
                manager.GetComponent<RhythmScript>().combo = 0;
                manager.GetComponent<RhythmScript>().fullCombo = false;
                manager.GetComponent<RhythmScript>().allPerfect = false;
                Instantiate(miss);
            }

            if (hitTime - timer <= 0.20f)
            {
                Destroy(gameObject);
            }
            
        }
        if (hitTime - timer < -0.20f)
        {
            
            manager.GetComponent<RhythmScript>().combo = 0;
            Instantiate(miss);
            manager.GetComponent<RhythmScript>().fullCombo = false;
            manager.GetComponent<RhythmScript>().allPerfect = false;
            Destroy(gameObject);
        }

    }
}
