using UnityEngine;

public class Level10 : MonoBehaviour
{
    public Misiones misiones;
    void Awake() {
        
            misiones = FindObjectOfType<Misiones>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MisionesSingleton.misionesSingleton.ChangeMision();
        }
    }
}