using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEntity : MonoBehaviour
{
    [SerializeField] ParticleSystem particleExplosion;

    private void OnCollisionEnter(Collision other)
    {
        PlaneEntity plane = other.gameObject.GetComponent<PlaneEntity>();
        if (plane != null) {
            GameObject.Destroy(this);
            GameObject.Instantiate(particleExplosion
                , this.transform.position
                , this.transform.rotation );
        }
    }
}
