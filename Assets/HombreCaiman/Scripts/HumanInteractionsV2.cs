using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HumanInteractionsV2 : MonoBehaviour
{
    public Animator humansAnim;
    public Text txtMision2;
    public Transform target;
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