using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        // Variables visible in editor
        [SerializeField] Transform target;
        [SerializeField] float lerpSpeed = 1f;

        private Vector3 velocity = Vector3.zero; 

        void LateUpdate()
        {
            transform.position = Vector3.SmoothDamp(transform.position, target.position, ref velocity, lerpSpeed);
        }
    }
}
