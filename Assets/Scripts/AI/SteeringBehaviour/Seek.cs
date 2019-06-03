using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehaviour
{
<<<<<<< HEAD
=======
    public Transform target;
    
>>>>>>> 61cc80670c7eae2b58482aa9e1b201eecab8ac10
    public override Vector3 GetForce(AI owner)
    {
        // SET force to zero
        Vector3 force = Vector3.zero;
<<<<<<< HEAD
        // Implement SEEK here
=======

        // If target is not null
        if (target)
        {
            //  SET desiredForce to target - current(position)
            Vector3 desiredForce = target.position - transform.position;
            //  SET force to desiredForce normalized x weighting
            force += desiredForce.normalized * weighting;
        }

>>>>>>> 61cc80670c7eae2b58482aa9e1b201eecab8ac10
        // RETURN force
        return force;
    }
}
