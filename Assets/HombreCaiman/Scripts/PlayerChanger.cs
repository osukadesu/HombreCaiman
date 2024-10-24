using System.Collections;
using UnityEngine;
public class PlayerChanger : MonoBehaviour
{
    public static PlayerChanger playerChanger;
    public PlayerController pc;
    public Misiones misiones;
    void Awake()
    {
        if (misiones != null)
        {
            misiones = FindObjectOfType<Misiones>();
        }
        else Debug.Log("Mision is null");
        if (playerChanger == null)
        {
            playerChanger = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (misiones.isMage && other.CompareTag("Swim"))
        {
            MisionesSingleton.misionesSingleton.mision++;
            StartCoroutine(Transformation(true));
            StartCoroutine(IEMove());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (misiones.isMage && other.CompareTag("Swim"))
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