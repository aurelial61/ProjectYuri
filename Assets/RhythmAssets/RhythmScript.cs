using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
    public GameObject register1;
    public GameObject register2;
    public GameObject register3;
    public GameObject register4;
    public GameObject endPrefab;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI statText;
    public bool end;
    public bool showStats;


    void Start()
    {
        spb = 60f / bpm;
        fullCombo = true;
        allPerfect = true;
        timer = 0 - spb * 8;
        winText.text = "";
        statText.text = "";
        
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
     
        if (timer > 272 * spb && ! end)
        {
            Instantiate(endPrefab);
            if (allPerfect)
            {
                winText.text = "ALL PERFECT!!!!!";
            }
            else if (fullCombo)
            {
                winText.text = "FULL COMBO!!!";
            }
            else if (score > 2500)
            {
                winText.text = "VICTORY";
            }
            else
            {
                winText.text = "DEFEAT";
            }
            end = true;
        }

        if (timer > 276 * spb && ! showStats)
        {
            showStats = true;
            statText.text = "Max combo: " + maxCombo + "\nPerfect: " + perfects + 
                "\nGreat: " + greats + "\nGood: " + goods + "\nMiss: " + misses;
        }

        if (timer > 292 * spb)
        {
            if (score > 2500)
            {
                SceneManager.LoadScene("WinDialogue");
            }
            else
            {
                SceneManager.LoadScene("LoseDialogue");
            }
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
            thisNote.GetComponent<NoteScript>().register = register1;
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
            holdNote.GetComponent<HoldScript>().register = register1;
            holds.RemoveAt(0);
        }

        if (notes2.Count > 0 && timer >= (notes2[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 3, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes2[0] * spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            thisNote.GetComponent<NoteScript>().key = KeyCode.F;
            thisNote.GetComponent<NoteScript>().register = register2;
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
            holdNote.GetComponent<HoldScript>().register = register2;
            holds2.RemoveAt(0);
        }

        if (notes3.Count > 0 && timer >= (notes3[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 2, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes3[0] * spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            thisNote.GetComponent<NoteScript>().key = KeyCode.J;
            thisNote.GetComponent<NoteScript>().register = register3;
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
            holdNote.GetComponent<HoldScript>().register = register3;
            holds3.RemoveAt(0);
        }

        if (notes4.Count > 0 && timer >= (notes4[0] * spb - spawnDistance / speed))
        {
            GameObject thisNote = Instantiate(notePrefab, transform.position + new Vector3(spawnDistance, 1, 0), Quaternion.identity);
            thisNote.GetComponent<NoteScript>().speed = speed;
            thisNote.GetComponent<NoteScript>().hitTime = notes4[0] * spb;
            thisNote.GetComponent<NoteScript>().manager = gameObject;
            thisNote.GetComponent<NoteScript>().key = KeyCode.K;
            thisNote.GetComponent<NoteScript>().register = register4;
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
            holdNote.GetComponent<HoldScript>().register = register4;
            holds4.RemoveAt(0);
        }
        
    }

    
}
