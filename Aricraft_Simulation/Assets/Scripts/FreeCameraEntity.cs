using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraEntity : MonoBehaviour
{
    public const float VELOCITY = 5f;
    Vector3 m_MousePosition;
    float m_HorizontalAngle = 0;
    float m_VerticalAngle = 0;

    private void Start() {
        m_MousePosition = Input.mousePosition;
    }

    void Update()
    {
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.W)) {
            //move forward
            move += Vector3.right;
        } else if (Input.GetKey(KeyCode.S)) {
            //move backward
            move -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.A)) {
            //Parallel Left
            move += Vector3.forward;
        } else if (Input.GetKey(KeyCode.D)) {
            //Parallel Right
            move -= Vector3.forward;
        }
        if (Input.GetKey(KeyCode.Q)) {
            //Vertical Up
            move += Vector3.up;
        } else if (Input.GetKey(KeyCode.E)) {
            //Vertical Right
            move -= Vector3.up;
        }
        if (move != Vector3.zero) {
            move.Normalize();
            this.transform.Translate(move * VELOCITY * Time.deltaTime);
        }


        if (Input.GetMouseButtonDown(0))
        {
            m_MousePosition = Input.mousePosition;
        } else if (Input.GetMouseButton(0)) {
            Vector3 mouseDeltaPosition = m_MousePosition - Input.mousePosition;

            m_HorizontalAngle -= mouseDeltaPosition.x * 0.1f;
            m_VerticalAngle = Mathf.Clamp(m_VerticalAngle - mouseDeltaPosition.y * 0.1f, -89f, 89f);
            this.transform.localEulerAngles = new Vector3(0, m_HorizontalAngle, m_VerticalAngle);

            m_MousePosition = Input.mousePosition;
        }
    } 
}
