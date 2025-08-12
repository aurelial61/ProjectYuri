using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Destroy(gameObject);
        }
        GetComponent<TextMeshPro>().color = new Color(GetComponent<TextMeshPro>().color.r, GetComponent<TextMeshPro>().color.g, GetComponent<TextMeshPro>().color.b, 1 - timer);
        
        
    }
}
