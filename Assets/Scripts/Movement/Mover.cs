using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour, IAction
    {
        // Variables visible in editor
        [SerializeField]
        GameObject target;

        // Private member variables
        NavMeshAgent navMeshAgent;
        Health health;

        // Unity specific functions
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            UpdateAnimator();
        }

        // Public functions
        public void Cancel()
        {
            navMeshAgent.isStopped = true;
        }

        public void StartMoveAction(Vector3 destination)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination) 
        { 
            navMeshAgent.isStopped = false;
            navMeshAgent.destination = destination; 
        }

        // Private functions
        private void UpdateAnimator()
        {
            Vector3 localVelocity = transform.InverseTransformDirection(navMeshAgent.velocity);
            GetComponent<Animator>().SetFloat("ForwardSpeed", localVelocity.z);
        }
    }
}
