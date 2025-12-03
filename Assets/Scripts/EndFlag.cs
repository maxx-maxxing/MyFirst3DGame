using UnityEngine;
using UnityEngine.SceneManagement;

public class EndFlag : MonoBehaviour
{
    public string nextSceneName;
    public bool lastLevel;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (lastLevel == true)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(nextSceneName);
            }
        }
    }
}
