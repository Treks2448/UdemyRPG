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
    Ray ray;
    RaycastHit hit;

    

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)) { GetComponent<NavMeshAgent>().destination = hit.point; }
        }
    }
}
