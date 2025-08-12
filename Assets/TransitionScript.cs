using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScript : MonoBehaviour
{
    public Animator transition;
    public GameObject dialouge;
    public Animation image;

    public float transitionTime;
    // Update is called once per frame
    void Update()
    {
        if (dialouge.GetComponent<Dialouge>().sceneStop == true)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.enabled = true;
        image.Play();
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
