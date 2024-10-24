using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangerScene : MonoBehaviour
{
    public PlayerChanger playerChanger;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(1);
            playerChanger.enabled = false;
        }
    }
}