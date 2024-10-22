using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MageCharacter : MonoBehaviour
{
    public Text txtMision4;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtMision4.text = "Presiona E para Hablar";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtMision4.text = "";
        }
    }
    IEnumerator IEHideText()
    {
        yield return new WaitForSeconds(0.5f);
        txtMision4.text = "";
    }
}