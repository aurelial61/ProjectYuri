using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RhythmScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float spawnDistance;
    public float bpm;
    public float spb;
    public List<float> notes;
    public float speed;
    public float timer;
    public GameObject notePrefab;
    public int score;
    public TextMeshProUGUI scoreText;
    

    void Start()
    {
        spb = 60f / bpm;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //GetComponent<BoxCollider2D>().size = new Vector2(speed / 12f * 2, 10);
        scoreText.text = "" + score;
        if (notes.Count > 0 && timer >= (notes[0] * spb - spawnDistance / speed))
        {
            Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 0, 0), Quaternion.identity).
                GetComponent<NoteScript>().speed = speed;
            notes.RemoveAt(0);

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note")
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space))
            {
                collision.gameObject.GetComponent<NoteScript>().hit = true;
                Destroy(collision.gameObject);
                score++;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Note" && ! collision.gameObject.GetComponent<NoteScript>().hit)
        {
            
            Destroy(collision.gameObject);
            score--;
            
        }
    }
}
