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
    public GameObject anim;

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

        if(SceneManager.GetActiveScene().name == "StartDialogue")
        {
            if (currentSprite % 2 == 0)
            {
                sprite.transform.position = new Vector3(-0.1f, 0.09f);
                sprite.transform.localScale = new Vector3(1.25f, 1.25f);
            }
            else
            {
                sprite.transform.position = new Vector3(-0.1f, 0.09f);
                sprite.transform.localScale = new Vector3(1.25f, 1.25f);
            }

            if(currentSprite == 8)
            {
                sprite.GetComponent<Animator>().enabled = true;
                sprite.transform.position = new Vector3(-0.1f, 0.09f);
                sprite.transform.localScale = new Vector3(1.25f, 1.25f);
            }
            else if (currentSprite == 9)
            {
                sprite.GetComponent<Animator>().enabled = false;
                gameObject.GetComponent<Animator>().enabled = true;
                sprite.transform.position = new Vector3(-0.1f, 0.09f);
                sprite.transform.localScale = new Vector3(1f, 1f);
            }
        }

        if(SceneManager.GetActiveScene().name == "WinDialogue" || SceneManager.GetActiveScene().name == "LoseDialogue")
        {
            if(currentSprite == 7)
            {
                gameObject.GetComponent<Animator>().enabled = true;
                gameObject.GetComponent<Animation>().Play();
            }
        }

        if (currentSprite <= charSprites.Length - 1)
        {
            currentSprite++;
        }
        else
        {
            gameObject.SetActive(false); // all activity is stopped
            sceneStop = true; // the scene is stopped
        }

        if (currentSprite >= charSprites.Length)
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
        if (index < lines.Length - 1) // length of array
        {
            index++; // go to next line
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            sceneStop = true;
            gameObject.SetActive(false); // all activity is stopped
        }
    }

    public void StopDialogue()
    {
        textComponent.text = lines[11];
        anim.GetComponent<Animator>().enabled = true;
        anim.GetComponent<Animation>().Play();
        gameObject.SetActive(false);
    }
}
