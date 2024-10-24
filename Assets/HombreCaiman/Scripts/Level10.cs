using UnityEngine;

public class Level10 : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MisionesSingleton.misionesSingleton.ChangeMision();
        }
    }
}