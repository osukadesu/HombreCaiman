using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Misiones : MonoBehaviour
{
    public HumanInteractions[] humanInteractions;
    public GameObject mage;
    public Text txtMision;
    public int mision;
    public bool isMage, weAreRun;
    void Start()
    {
        mage.SetActive(false);
        mision = 1;
        isMage = false;
        weAreRun = false;
        LasMisiones(mision);
    }
    public void LasMisiones(int _mision)
    {
        switch (_mision)
        {
            case 1:
                txtMision.text = "Recoge la basura que la gente ha tirado, acercate y diles que no boten basura en el rio";
                StartCoroutine(IEHideText());
                break;
            case 9:
                StartCoroutine(IEMisionV2());
                mage.SetActive(true);
                break;
            case 10:
                isMage = true;
                break;
            case 11:
                weAreRun = true;
                for (int i = 0; i < humanInteractions.Length; i++)
                {
                    humanInteractions[i].humansAnim.SetBool("walk", true);
                    humanInteractions[i].humansAnim.SetBool("run", true);
                }
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
