using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class HumanInteractions : MonoBehaviour
{
    public Animator humansAnim;
    public Text txtMision2;
    public Transform target;
    public Misiones misiones;
    void Update()
    {
        if (misiones.weAreRun)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.08f * Time.deltaTime);
            Vector3 direction = (target.position - transform.position).normalized;
        }
    }
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