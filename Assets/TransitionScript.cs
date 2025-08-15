using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    // animation
    //public Animation image;
    public Animator transition;

    public GameObject dialogue; // finds dialogue
    
    public float transitionTime;

    public Button skipDialogue;

    //public GameObject anim;
    // Update is called once per frame

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "LoseDialogue" || SceneManager.GetActiveScene().name == "StartDialogue")
        {
            skipDialogue.interactable = true;
            skipDialogue.onClick.AddListener(LoadNextLevel);
        }
        else
        {
            skipDialogue.interactable = false;
        }
    }
    void Update()
    {
        if (dialogue.GetComponent<Dialouge>().sceneStop == true) // finds when scene is stopped
        {
            LoadNextLevel(); // loads next scene
        }
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().name == "WinDialogue")
        {
            StopAllCoroutines();
        }
        else
        {
            StartCoroutine(LoadLevel()); // transitions to next scene according to index
        }
    }

    IEnumerator LoadLevel()
    {
        // animation for transition
        transition.enabled = true; // starts transition at this time
        //image.Play(); // plays animation
        transition.SetTrigger("Start"); // triggers animator

        yield return new WaitForSeconds(transitionTime); // wait for few seconds

        SceneManager.LoadScene("RhythmScene1"); // loads next scene/actual transition
        //SceneManager.LoadScene("insert scene here"); // loads next scene according to name;
        //if transition not needed, just remove prefab from hierachy
    }
}
