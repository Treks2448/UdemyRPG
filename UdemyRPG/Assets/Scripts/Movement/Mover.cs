using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    // Variables visible in editor
    [SerializeField]
    GameObject target;

    // Private member variables
    Camera cam;
    NavMeshAgent navMeshAgent;
    Ray ray;
    RaycastHit hit;

    // Unity specific functions
    void Start()
    {
        cam = Camera.main;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        MoveToCursor();
        UpdateAnimator();
    }

    // Private functions
    private void MoveToCursor()
    {
        if (Input.GetButton("Fire1"))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) { navMeshAgent.destination = hit.point; }
        }
    }

    private void UpdateAnimator()
    {
        Vector3 localVelocity = transform.InverseTransformDirection(navMeshAgent.velocity);
        GetComponent<Animator>().SetFloat("ForwardSpeed", localVelocity.z);
    }
}
