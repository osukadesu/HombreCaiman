using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HumanInteractions : MonoBehaviour
{
    public Misiones misiones;
    public Text txtMision2;
    public bool canSpeak;
    void Update()
    {
        if (canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            txtMision2.text = "Deja de tirar basura al rio";
            StartCoroutine(IEHideText());
            misiones.mision++;
            misiones.LasMisiones(misiones.mision);
            canSpeak = false;
            /*
             StartCoroutine(IEHideTextAndDestroy());
            */
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = true;
            txtMision2.text = "Presiona E para Hablar";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = false;
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