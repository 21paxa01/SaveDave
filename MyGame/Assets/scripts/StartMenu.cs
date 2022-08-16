using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject perechod;
    public Save save;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Game()
    {
        StartCoroutine(StartGame());
    }
    IEnumerator StartGame()
    {
        perechod.SetActive(true);
        yield return new WaitForSeconds(1f);
        save.training = false;
        save.Save_training();
        SceneManager.LoadScene(3);
    }
    public void Training()
    {
        StartCoroutine(StartTraining());
    }
    IEnumerator StartTraining()
    {
        perechod.SetActive(true);
        yield return new WaitForSeconds(1f);
        save.training = true;
        save.Save_training();
        SceneManager.LoadScene(3);
    }
}
