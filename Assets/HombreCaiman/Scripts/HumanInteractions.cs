using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HumanInteractions : MonoBehaviour
{
    public Text txtMision2;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtMision2.text = "Presiona E para Hablar";
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            txtMision2.text = "";
        }
    }
    IEnumerator IEHideText()
    {
        yield return new WaitForSeconds(0.5f);
        txtMision2.text = "";
    }
}