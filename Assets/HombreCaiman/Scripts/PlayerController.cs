using System.Collections;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public Misiones misiones;
    public Animator characterAnim;
    [SerializeField] Rigidbody playerRB;
    [SerializeField] Vector3 moveDirection;
    [SerializeField] CapsuleCollider human, caiman;
    [SerializeField] GameObject[] humanBody, trashObjects;
    [SerializeField] GameObject caimanBody;
    [SerializeField] float horizontalMove, verticalMove, playerSpeed;
    public bool canJump, isWalk, canRun, isRun, isCaiman = false, canSwim, canMove;
    void Start()
    {
        playerSpeed = 1f;
        canMove = true;
        canJump = true;
        canRun = true;
        canSwim = false;
        human.enabled = true;
        caiman.enabled = false;
        humanBody[0].SetActive(true);
        humanBody[1].SetActive(true);
        caimanBody.SetActive(false);
        characterAnim.SetBool("walk", false);
        characterAnim.SetBool("run", false);
    }
    void Update()
    {
        if (canMove)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal");
            verticalMove = Input.GetAxisRaw("Vertical");
        }
        else
        {
            horizontalMove = 0;
            verticalMove = 0;
        }
        moveDirection = new Vector3(horizontalMove, 0, verticalMove).normalized;
        /* 
        transform.Rotate(0, horizontalMove * Time.deltaTime * 50f, 0);
        if (moveDirection != Vector3.zero)
        {
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
        } 
        */
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerRB.AddForce(new(0, 4f, 0), ForceMode.Impulse);
            }
        }
        SetAnimations();
        if (isRun)
        {
            characterAnim.SetFloat("animSpeed", 1.7f);
        }
        else characterAnim.SetFloat("animSpeed", 1f);
        characterAnim.SetBool("swimming", canSwim && moveDirection != Vector3.zero);
        characterAnim.SetBool("caimaniando", isCaiman && moveDirection != Vector3.zero);
    }
    void FixedUpdate()
    {
        /*
        Vector3 movement = moveDirection * playerSpeed * Time.fixedDeltaTime;
        playerRB.MovePosition(playerRB.position + movement);
        */
        Quaternion deltaRotation = Quaternion.Euler(0, horizontalMove * Time.fixedDeltaTime * 100f, 0);
        playerRB.MoveRotation(playerRB.rotation * deltaRotation);
        Vector3 movement = transform.forward * verticalMove * Time.fixedDeltaTime * playerSpeed;
        playerRB.MovePosition(playerRB.position + movement);
    }
    void SetAnimations()
    {
        isWalk = horizontalMove != 0f || verticalMove != 0f;
        isRun = isWalk && canRun && Input.GetKey(KeyCode.LeftShift);
        characterAnim.SetBool("walk", isWalk);
        characterAnim.SetBool("run", isRun);
        playerSpeed = isRun ? 4f : 1f;
    }
    void OnTriggerEnter(Collider other)
    {
        if (misiones.isMage && other.CompareTag("Swim"))
        {
            misiones.mision++;
            misiones.LasMisiones(misiones.mision);
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
        isCaiman = _isCaiman;
        characterAnim.SetBool("caiman", isCaiman);
        canJump = !isCaiman;
        playerSpeed = .5f;
        human.enabled = !isCaiman;
        caiman.enabled = isCaiman;
        caimanBody.SetActive(isCaiman);
        humanBody[0].SetActive(!isCaiman);
        humanBody[1].SetActive(!isCaiman);
        canSwim = _isCaiman;
        characterAnim.SetBool("swim", canSwim);
    }
    IEnumerator IEMove()
    {
        yield return new WaitForSeconds(0.5f);
        canMove = false;
        yield return new WaitForSeconds(1f);
        canMove = true;
    }
}