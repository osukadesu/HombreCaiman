using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Misiones : MonoBehaviour
{
    public Text txtMision;
    public int mision;
    void Start()
    {
        mision = 1;
        LasMisiones(mision);
    }
    public void LasMisiones(int _mision)
    {
        switch (_mision)
        {
            case 1:
                txtMision.text = "Recoge la basura que la gente ha tirado, acercate y diles que no boten basura en el rio presionando la tecla F";
                StartCoroutine(IEHideText());
                break;
            case 9:
                StartCoroutine(IEMisionV2());
                break;
        }
    }
    IEnumerator IEHideText()
    {
        yield return new WaitForSeconds(5f);
        txtMision.text = "";
    }
    IEnumerator IEMisionV2()
    {
        yield return new WaitForSeconds(1f);
        txtMision.text = "Busca al hechizero para que te de una posión y puedas asustar a la gente.";
        StartCoroutine(IEHideText());
    }
}
