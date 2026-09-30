using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AngelController : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform Player;
    public Transform cam;
    public float angle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {  
        agent.SetDestination(Player.position);
        Vector3 toAngel =  transform.position - cam.position;
        angle = Vector3.Angle(cam.forward,  toAngel); //camera direction to let know that the  angel is being watched
        if (angle < 30)
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }

        if (toAngel.magnitude < 1.5f)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }   
}
