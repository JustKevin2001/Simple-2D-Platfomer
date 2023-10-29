using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Attributes
    [SerializeField] float levelLoadDelay;
    [SerializeField] AudioClip WinningSound;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audioSource.PlayOneShot(WinningSound);
            StartCoroutine(LoadNextLevel());
        }
    }

    // Function cua startCoroutine phai di kem IEnumertator
    IEnumerator LoadNextLevel()
    {
        // Sau khi yeild return(Doi 3s thi chay code phia duoi => Xu ly bat dong bo)
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
}
