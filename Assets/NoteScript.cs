using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float timer;
    public bool hit;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;
        
        
    }
}
