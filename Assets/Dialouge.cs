using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // calling text component

    [TextArea(3, 10)]
    public string[] lines; // array of set of lines

    public Sprite[] charSprites;
    public SpriteRenderer spriteRenderer;
    public int currentSprite;
    public GameObject sprite;
    //public GameObject anim;

    public float textSpeed; // how fast the characters set up

    private int index; // index of scenes

    public bool sceneStop; // when the scene stops
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty; // first it's empty
        StartDialogue();
        sceneStop = false;
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (SceneManager.GetActiveScene().name == "LoseDialogue")
        {
            anim.GetComponent<Animation>().Play();
        }
        */
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if(textComponent.text == lines[index]) // when the line shows up
            { 
                NextLine(); // go to next line
                
                ChangeSprite();
            }
            else
            {
                StopAllCoroutines(); // stop courotines
                textComponent.text = lines[index]; // stay in line
            }
        }
    }
    
    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }
    
    void ChangeSprite()
    {
        sprite.GetComponent<SpriteRenderer>().sprite = charSprites[currentSprite];
        currentSprite++;

        if (index >= charSprites.Length)
        {
            currentSprite = 0;
        }
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
