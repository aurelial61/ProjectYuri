using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // calling text component
    public string[] lines; // array of set of lines
    public float textSpeed; // how fast the characters set up

    private int index; // index of scenes

    public bool sceneStop; // when the scene stops
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty; // first it's empty
        StartDialouge();
        sceneStop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(textComponent.text == lines[index]) // when the line shows up
            {
                NextLine(); // go to next line
            }
            else
            {
                StopAllCoroutines(); // stop courotines
                textComponent.text = lines[index]; // stay in line
            }
        }
    }

    void StartDialouge()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in lines[index].ToCharArray()) // types out each char
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void NextLine()
    {
        if(index < lines.Length - 1) // length of array
        {
            index++; // go to next line
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false); // all activity is stopped
            sceneStop = true; // the scene is stopped
        }
    }
}
