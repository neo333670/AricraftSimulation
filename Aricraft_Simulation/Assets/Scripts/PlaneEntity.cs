using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEntity : MonoBehaviour
{
    float m_Velocity = 0;
    const float PLANE_ACCELERATION = 10f;
    const float PLANE_DECELERATION = 10f;
    //const float PLANE_MIN_VELOCITY = 10f;
    const float PLANE_MAX_VELOCITY = 20f;

    float m_RollVelocity = 0;
    const float ROLL_ACCELERATION = 100f;
    const float ROLL_DECELERATION = 100f;
    const float MAX_ROLL_VELOCITY = 100f;

    public float m_PitchVelocity = 0;
    const float Pitch_ACCELERATION = 20f;
    const float Pitch_DECELERATION = 50f;
    const float MAX_Pitch_VELOCITY = 20f;

    [SerializeField] Transform m_PlantBodyTrans;

    private void FixedUpdate(){
        ForwardControl();
        RollControl();
        PitchControl();
        this.transform.Translate(m_Velocity * Time.fixedDeltaTime * Vector3.right);
        this.transform.Rotate(m_RollVelocity *Time.fixedDeltaTime, 0, 0);
        this.transform.Rotate(0, 0, m_PitchVelocity * Time.fixedDeltaTime);
        //visual effects
        m_PlantBodyTrans.localEulerAngles = new Vector3(m_RollVelocity / MAX_ROLL_VELOCITY *1000f *Time.fixedDeltaTime,
        0f, m_PitchVelocity/MAX_Pitch_VELOCITY *300f *Time.fixedDeltaTime);
    }

    void RollControl() {
        if (Input.GetKey(KeyCode.LeftArrow))        {
            m_RollVelocity = Mathf.Min(MAX_ROLL_VELOCITY, m_RollVelocity + ROLL_ACCELERATION * Time.fixedDeltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            m_RollVelocity = Mathf.Max(-MAX_ROLL_VELOCITY, m_RollVelocity - ROLL_ACCELERATION * Time.fixedDeltaTime);
        }
        else
        {
            m_RollVelocity = m_RollVelocity > 0 ?
                Mathf.Max(0, m_RollVelocity - ROLL_DECELERATION * Time.fixedDeltaTime) :
                Mathf.Min(0, m_RollVelocity + ROLL_DECELERATION * Time.fixedDeltaTime);
        }
    }

    void ForwardControl() {
        if (Input.GetKey(KeyCode.Space)) {
            m_Velocity = Mathf.Min(PLANE_MAX_VELOCITY, m_Velocity + PLANE_ACCELERATION * Time.fixedDeltaTime);
        } else if (Input.GetKey(KeyCode.LeftShift)) {
            m_Velocity = Mathf.Max(0, m_Velocity - PLANE_DECELERATION * Time.fixedDeltaTime);
        } 
    }

    void PitchControl() {
        if (Input.GetKey(KeyCode.UpArrow)) {
            m_PitchVelocity = Mathf.Min(MAX_Pitch_VELOCITY, m_PitchVelocity + Pitch_ACCELERATION *Time.fixedDeltaTime);
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            m_PitchVelocity = Mathf.Max(-MAX_Pitch_VELOCITY, m_PitchVelocity - Pitch_ACCELERATION * Time.fixedDeltaTime);
        } else {
            m_PitchVelocity = m_PitchVelocity > 0 ?
                Mathf.Max(0, m_PitchVelocity - Pitch_DECELERATION * Time.fixedDeltaTime) :
                Mathf.Min(0, m_PitchVelocity + Pitch_DECELERATION * Time.fixedDeltaTime);
        }
    }
}
