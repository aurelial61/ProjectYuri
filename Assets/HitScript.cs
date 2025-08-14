using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public bool play;
    void Start()
    {
        if (play)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(-4, transform.position.y, 0);
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Destroy(gameObject);
        }
    }
}
