using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegisterScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject currentNote;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentNote != null)
        {
            currentNote.GetComponent<NoteScript>().HitNote();
            
        }
    }

    public void addNote(GameObject note)
    {
        if (currentNote == null)
        {
            currentNote = note;
        }
        else if (note.GetComponent<NoteScript>().hitTime < currentNote.GetComponent<NoteScript>().hitTime)
        {
            currentNote = note;
        }

    }
}
