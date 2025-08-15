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
        skipDialogue.interactable = true;
        skipDialogue.onClick.AddListener(LoadNextLevel);
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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1)); // transitions to next scene according to index
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // animation for transition
        transition.enabled = true; // starts transition at this time
        //image.Play(); // plays animation
        transition.SetTrigger("Start"); // triggers animator

        yield return new WaitForSeconds(transitionTime); // wait for few seconds

        SceneManager.LoadScene(levelIndex); // loads next scene/actual transition
        //SceneManager.LoadScene("insert scene here"); // loads next scene according to name;
        //if transition not needed, just remove prefab from hierachy
    }
}
