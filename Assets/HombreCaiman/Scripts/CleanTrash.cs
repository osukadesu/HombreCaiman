using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class CleanTrash : MonoBehaviour
{
    public Text txtMision2;
    public bool item;
    void Awake()
    {
        item = false;
    }
    void Update()
    {
        if (item && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(IEHideTextAndDestroy());
            MisionesSingleton.misionesSingleton.ChangeMision();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            item = true;
            txtMision2.text = "Presiona E para limpiar";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            item = false;
            txtMision2.text = "";
        }
    }
    IEnumerator IEHideTextAndDestroy()
    {
        StartCoroutine(IEHideText());
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject, 0.5f);
    }
    IEnumerator IEHideText()
    {
        yield return new WaitForSeconds(0.5f);
        txtMision2.text = "";
    }
}