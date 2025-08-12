using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RhythmScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    public float spawnDistance;
    public float bpm;
    public float spb;
    public List<float> notes;
    public float speed;
    public int combo;
    
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
        scoreText.text = "Score: " + score + "     " + "Combo: " + combo;
        if (notes.Count > 0 && timer >= (notes[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 0, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes[0] *spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            notes.RemoveAt(0);

        }
    }

    
}
