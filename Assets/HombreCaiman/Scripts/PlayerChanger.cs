using System.Collections;
using UnityEngine;
public class PlayerChanger : MonoBehaviour
{
    public PlayerController pc;
    public HumanInteractions[] humanInteractions;
    public bool isMage, weAreRun;
    public Transform playerPos2;
    public PlayerController player;
    void Start()
    {
        isMage = true;
        player.transform.position = playerPos2.position;
    }
    void OnTriggerEnter(Collider other)
    {
        if (isMage && other.CompareTag("Swim"))
        {
            StartCoroutine(Transformation(true));
            StartCoroutine(IEMove());
            weAreRun = true;
            for (int i = 0; i < humanInteractions.Length; i++)
            {
                humanInteractions[i].humansAnim.SetBool("walk", true);
                humanInteractions[i].humansAnim.SetBool("run", true);
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (isMage && other.CompareTag("Swim"))
        {
            StartCoroutine(Transformation(false));
        }
    }
    IEnumerator Transformation(bool _isCaiman)
    {
        yield return new WaitForSeconds(1f);
        pc.isCaiman = _isCaiman;
        pc.characterAnim.SetBool("caiman", pc.isCaiman);
        pc.canJump = !pc.isCaiman;
        pc.playerSpeed = .5f;
        pc.human.enabled = !pc.isCaiman;
        pc.caiman.enabled = pc.isCaiman;
        pc.caimanBody.SetActive(pc.isCaiman);
        pc.humanBody[0].SetActive(!pc.isCaiman);
        pc.humanBody[1].SetActive(!pc.isCaiman);
        pc.canSwim = _isCaiman;
        pc.characterAnim.SetBool("swim", pc.canSwim);
    }
    IEnumerator IEMove()
    {
        yield return new WaitForSeconds(0.5f);
        pc.canMove = false;
        yield return new WaitForSeconds(1f);
        pc.canMove = true;
    }
}