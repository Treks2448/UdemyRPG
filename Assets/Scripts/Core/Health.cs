using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        // Variables visible in editor
        [SerializeField] float healthPoints = 100f;

        // Private varaibles
        private bool isDead;

        // Unity specific functions
        void Start()
        {
            isDead = false;
        }
        
        // Public functions
        public bool IsDead() { return isDead; }
        public void TakeDamage(float damage)
        {
            healthPoints = Mathf.Max(healthPoints - damage, 0);
            print(healthPoints);
            if (healthPoints == 0)
            {
                Die();
            }
        }

        // Private functions
        private void Die()
        {
            if (isDead) { return; }
            GetComponent<Animator>().SetTrigger("Die");
            isDead = true;
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }
}

