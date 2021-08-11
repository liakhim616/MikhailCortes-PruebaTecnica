using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    private int fromScene;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        fromScene = PlayerPrefs.GetInt("fromScene", 0);

        if (fromScene == 0)
        {
            StartCoroutine(LoadingCoR());
        }
        else
        {
            StartCoroutine(LoadingCoRB());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator LoadingCoR()
    {
        Debug.Log("AsyncMenu-Game");
        yield return new WaitForSeconds(2f);
        AsyncOperation loadingOperation = SceneManager.LoadSceneAsync(2);
        while (!loadingOperation.isDone)
        {
            yield return null;
        }
    }

    public IEnumerator LoadingCoRB()
    {
        Debug.Log("AsyncGame-Menu");
        yield return new WaitForSeconds(2f);
        AsyncOperation loading2Operation = SceneManager.LoadSceneAsync(0);
        while (!loading2Operation.isDone)
        {
            yield return null;
        }
    }
}
