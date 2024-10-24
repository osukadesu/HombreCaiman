using UnityEngine;
using UnityEngine.UI;
public class HumanInteractions : MonoBehaviour
{
    public Animator humansAnim;
    public Text txtMision2;
    public Transform target;
    public PlayerChanger playerChanger;
    void Update()
    {
        if (playerChanger.weAreRun)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, 0.08f * Time.deltaTime);
            Vector3 direction = (target.position - transform.position).normalized;
        }
    }
}