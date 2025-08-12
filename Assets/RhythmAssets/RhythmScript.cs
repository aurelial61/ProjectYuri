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
    public bool fullCombo;
    public bool allPerfect;
    public GameObject notePrefab;
    public GameObject holdPrefab;
    public int score;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI comboText;
    public List<Vector2> holds;
    

    void Start()
    {
        spb = 60f / bpm;
        fullCombo = true;
        allPerfect = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        //GetComponent<BoxCollider2D>().size = new Vector2(speed / 12f * 2, 10);

        scoreText.text = "Score: " + score;
        if (combo > 0)
        {
            comboText.text = "Combo: " + combo;
        }
        else
        {
            comboText.text = "";
        }
        
        if (! allPerfect)
        {
            comboText.color = new Color(0.96f, 0.66f, 0.72f);
        }
        
        if (notes.Count > 0 && timer >= (notes[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 0, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes[0] *spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            notes.RemoveAt(0);

        }

        if (holds.Count > 0 && timer >= (holds[0].x * spb - spawnDistance / speed))
        {
            GameObject holdNote = Instantiate(holdPrefab, transform.position + new Vector3(spawnDistance, 0, 0), Quaternion.identity);
            holdNote.GetComponent<HoldScript>().speed = speed;
            holdNote.GetComponent<HoldScript>().hitTime = holds[0].x * spb;
            holdNote.GetComponent<HoldScript>().manager = gameObject;
            holdNote.GetComponent<HoldScript>().duration = holds[0].y * spb;
            holdNote.GetComponent<HoldScript>().spb = spb;
            holdNote.GetComponent<HoldScript>().spawnDistance = spawnDistance;
            holds.RemoveAt(0);
        }
    }

    
}
