using UnityEngine;
using UnityEngine.SceneManagement;
public class TakePosion : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}