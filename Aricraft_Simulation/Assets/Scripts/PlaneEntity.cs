using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEntity : MonoBehaviour
{
    float m_Velocity = 10;
    const float PLANE_ACCELERATION = 10f;
    const float PLANE_DECELERATION = 10f;
    const float PLANE_MIN_VELOCITY = 10f;
    const float PLANE_MAX_VELOCITY = 10f;

    float m_RollVelocity = 0;
    const float ROLL_ACCELERATION = 100f;
    const float ROLL_DECELERATION = 100f;
    const float MAX_ROLL_VELOCITY = 100f;

    private void FixedUpdate(){
        this.transform.Translate(m_Velocity * Time.fixedDeltaTime * Vector3.right);
        RollControll();
        this.transform.Rotate(m_RollVelocity *Time.fixedDeltaTime, 0, 0);
    
    }
    void RollControll() {
        if (Input.GetKey(KeyCode.LeftArrow)){
            m_RollVelocity = Mathf.Min(MAX_ROLL_VELOCITY, m_RollVelocity + ROLL_ACCELERATION * Time.fixedDeltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            m_RollVelocity = Mathf.Max(-MAX_ROLL_VELOCITY, m_RollVelocity - m_RollVelocity - ROLL_DECELERATION * Time.fixedDeltaTime);
        }

    }

}
