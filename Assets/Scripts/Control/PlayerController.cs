using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using RPG.Core;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        // Private variables
        Health health;

        // Unity functions
        void Start()
        {
            health = GetComponent<Health>();
        }

        void Update()
        {
            if (health.IsDead()) { return; }
            if (InteractWithCombat()) { return; }
            if (InteractWithMovement()) { return; }
        }

        // Private functions
        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        private bool InteractWithMovement()
        {
            RaycastHit hit;
            if (Physics.Raycast(GetMouseRay(), out hit))
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                return true;
            }
            return false;
        }

        private bool InteractWithCombat()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.collider.gameObject.GetComponent<CombatTarget>();
                if (target == null) { continue; }

                if (!GetComponent<Fighter>().CanAttack(target.gameObject)) { continue; }
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Fighter>().Attack(target.gameObject);
                }
                return true;
            }
            return false;
        }
    }
}
