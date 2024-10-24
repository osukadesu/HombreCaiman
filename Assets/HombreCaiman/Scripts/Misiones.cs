using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Misiones : MonoBehaviour
{
    public HumanInteractions[] humanInteractions;
    public GameObject mage, mision10;
    public Text txtMision;
    public bool isMage, weAreRun;
    public Transform playerPos2;
    public PlayerController player;
    void Start()
    {
        mision10.SetActive(false);
        mage.SetActive(false);
        isMage = false;
        weAreRun = false;
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
                player.transform.position = playerPos2.position;
                FindObjectOfType<Misiones>();
                mision10.SetActive(true);
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
        txtMision.text = "Encuentra la cabaña del hechizero y pídele ayuda para asustar a la gente.";
        StartCoroutine(IEHideText());
    }
}