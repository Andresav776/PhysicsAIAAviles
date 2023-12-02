using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    public GameObject explosion;
    float bulletSpeed = 0f;
    float mass = 1f;
    float force = 50;
    float accel;
    float drag = 0.25f;
    float gravity = -0.25f;
    float gravAccel;
    float ySpeed = 0f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        accel = force / mass;
        bulletSpeed += accel * 1;
        gravAccel = gravity / mass;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        bulletSpeed *= (1 - Time.deltaTime * drag);
        ySpeed += gravAccel * Time.deltaTime;
        this.transform.Translate(0, ySpeed, Time.deltaTime * bulletSpeed);
    }
}
