using UnityEngine;
public class MisionesSingleton : MonoBehaviour
{
    public static MisionesSingleton misionesSingleton;
    public Misiones misiones;
    public int mision;
    void Awake()
    {
        if (misionesSingleton == null)
        {
            misionesSingleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //ChangeMision();
    }
    void Start()
    {
        mision = 1;
    }
    public void ChangeMision()
    {
        mision++;
        misiones.LasMisiones(mision);
    }
}