using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CanSpeakMage : MonoBehaviour
{
    public Misiones misiones;
    public Text txtMision2;
    public bool canSpeak;
    void Update()
    {
        if (canSpeak && Input.GetKeyDown(KeyCode.E))
        {
            txtMision2.text = "Toma esta posión cuando entres al rio podrás asustar a la gente";
            StartCoroutine(IEHideText());
            misiones.mision++;
            misiones.LasMisiones(misiones.mision);
            StartCoroutine(IEHideTextAndDestroy());
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canSpeak = false;
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
