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
    public List<float> notes2;
    public List<float> notes3;
    public List<float> notes4;

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
    public List<Vector2> holds2;
    public List<Vector2> holds3;
    public List<Vector2> holds4;
    public bool start;
    public static bool bigAttack;
    public bool played;
    public int maxCombo;
    public Animator queenAnim;
    public int perfects;
    public int greats;
    public int goods;
    public int misses;


    void Start()
    {
        spb = 60f / bpm;
        fullCombo = true;
        allPerfect = true;
        timer = 0 - spb * 8;
        
    }

    // Update is called once per frame
    void Update()
    {
        queenAnim.SetBool("Attack", bigAttack);
        if (timer > -0.2f && ! start)
        {
            start = true;
            GetComponent<AudioSource>().Play();
        }
        timer += Time.deltaTime;

        
        if (timer > 59 * spb && ! bigAttack && ! played)
        {
            bigAttack = true;
            played = true;
         
        }

        if (combo > maxCombo)
        {
            maxCombo = combo;
        }
     
        

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
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 4, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes[0] *spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            thisNote.GetComponent<NoteScript>().key = KeyCode.D;
            notes.RemoveAt(0);

        }

        if (holds.Count > 0 && timer >= (holds[0].x * spb - spawnDistance / speed))
        {
            GameObject holdNote = Instantiate(holdPrefab, transform.position + new Vector3(spawnDistance, 4, 0), Quaternion.identity);
            holdNote.GetComponent<HoldScript>().speed = speed;
            holdNote.GetComponent<HoldScript>().hitTime = holds[0].x * spb;
            holdNote.GetComponent<HoldScript>().manager = gameObject;
            holdNote.GetComponent<HoldScript>().duration = holds[0].y * spb;
            holdNote.GetComponent<HoldScript>().spb = spb;
            holdNote.GetComponent<HoldScript>().spawnDistance = spawnDistance;
            holdNote.GetComponent<HoldScript>().key = KeyCode.D;
            holds.RemoveAt(0);
        }

        if (notes2.Count > 0 && timer >= (notes2[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 3, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes2[0] * spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            thisNote.GetComponent<NoteScript>().key = KeyCode.F;
            notes2.RemoveAt(0);

        }

        if (holds2.Count > 0 && timer >= (holds2[0].x * spb - spawnDistance / speed))
        {
            GameObject holdNote = Instantiate(holdPrefab, transform.position + new Vector3(spawnDistance, 3, 0), Quaternion.identity);
            holdNote.GetComponent<HoldScript>().speed = speed;
            holdNote.GetComponent<HoldScript>().hitTime = holds2[0].x * spb;
            holdNote.GetComponent<HoldScript>().manager = gameObject;
            holdNote.GetComponent<HoldScript>().duration = holds2[0].y * spb;
            holdNote.GetComponent<HoldScript>().spb = spb;
            holdNote.GetComponent<HoldScript>().spawnDistance = spawnDistance;
            holdNote.GetComponent<HoldScript>().key = KeyCode.F;
            holds2.RemoveAt(0);
        }

        if (notes3.Count > 0 && timer >= (notes3[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 2, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes3[0] * spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            thisNote.GetComponent<NoteScript>().key = KeyCode.J;
            notes3.RemoveAt(0);

        }

        if (holds3.Count > 0 && timer >= (holds3[0].x * spb - spawnDistance / speed))
        {
            GameObject holdNote = Instantiate(holdPrefab, transform.position + new Vector3(spawnDistance, 2, 0), Quaternion.identity);
            holdNote.GetComponent<HoldScript>().speed = speed;
            holdNote.GetComponent<HoldScript>().hitTime = holds3[0].x * spb;
            holdNote.GetComponent<HoldScript>().manager = gameObject;
            holdNote.GetComponent<HoldScript>().duration = holds3[0].y * spb;
            holdNote.GetComponent<HoldScript>().spb = spb;
            holdNote.GetComponent<HoldScript>().spawnDistance = spawnDistance;
            holdNote.GetComponent<HoldScript>().key = KeyCode.J;
            holds3.RemoveAt(0);
        }

        if (notes4.Count > 0 && timer >= (notes4[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 1, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes4[0] * spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            thisNote.GetComponent<NoteScript>().key = KeyCode.K;
            notes4.RemoveAt(0);

        }

        if (holds4.Count > 0 && timer >= (holds4[0].x * spb - spawnDistance / speed))
        {
            GameObject holdNote = Instantiate(holdPrefab, transform.position + new Vector3(spawnDistance, 1, 0), Quaternion.identity);
            holdNote.GetComponent<HoldScript>().speed = speed;
            holdNote.GetComponent<HoldScript>().hitTime = holds4[0].x * spb;
            holdNote.GetComponent<HoldScript>().manager = gameObject;
            holdNote.GetComponent<HoldScript>().duration = holds4[0].y * spb;
            holdNote.GetComponent<HoldScript>().spb = spb;
            holdNote.GetComponent<HoldScript>().spawnDistance = spawnDistance;
            holdNote.GetComponent<HoldScript>().key = KeyCode.K;
            holds4.RemoveAt(0);
        }
        
    }

    
}
