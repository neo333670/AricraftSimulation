using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEntity : MonoBehaviour
{
    [SerializeField] GameObject m_target;
    public GameObject m_Base;
    public GameObject m_Gun;

    [SerializeField] GameObject m_Bullet;

    private void FixedUpdate()
    {   //base rotation
        Vector3 diffVec = m_target.transform.position - this.transform.position;

        var targetQuaternion = Quaternion.FromToRotation(
            Vector3.left, new Vector3(diffVec.x, 0f, diffVec.z));
        m_Base.transform.localRotation = targetQuaternion;
        //gun rotation
        Vector2 xzProjection = new Vector2(diffVec.x, diffVec.z);
        float xzPjLength = xzProjection.magnitude;

        var targetGunQuaternion = Quaternion.FromToRotation
        (new Vector3(-xzPjLength, 0, 0), new Vector3(-xzPjLength, diffVec.y, 0));
        m_Gun.transform.localRotation = targetGunQuaternion;

        //shoot bullet
        if (Input.GetKeyDown(KeyCode.Return)) {
            var bullet = GameObject.Instantiate(m_Bullet);
            bullet.transform.position = m_Gun.transform.position;
            bullet.GetComponent<Rigidbody>().velocity = -m_Gun.transform.right * 500;
        }
    }
}
