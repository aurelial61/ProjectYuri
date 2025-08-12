using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    // animation
    public Animation image;
    public Animator transition;

    public GameObject dialouge; // finds dialouge
    
    public float transitionTime;
    // Update is called once per frame
    void Update()
    {
        if (dialouge.GetComponent<Dialouge>().sceneStop == true) // finds when scene is stopped
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
        transition.enabled = true; // starts transition at this time
        image.Play(); // plays animation
        transition.SetTrigger("Start"); // triggers animator

        yield return new WaitForSeconds(transitionTime); // wait for few seconds

        SceneManager.LoadScene(levelIndex); // loads next scene
    }
}
