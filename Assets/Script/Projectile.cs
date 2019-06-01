using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public LayerMask collisionMask;
    float speed = 10;
    float damage = 1;

    float lifetime = 3;
    float skinWidth = .1f;

    void Start()
    {
        Destroy(gameObject, lifetime);

        Collider[] initialCollision = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (initialCollision.Length > 0)
        {
            OnHitObject(initialCollision[0], transform.position);
        }
    }
    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

	// Update is called once per frame
	void Update () {
        float moveDistance = speed * Time.deltaTime;
        CheckCollicion(moveDistance);
        transform.Translate(Vector3.forward * moveDistance);
	}

    void CheckCollicion(float moveDistance)
    {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray,out hit, moveDistance + skinWidth, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit.collider, hit.point);
        }
    }
    

    void OnHitObject(Collider c, Vector3 hitPoint)
    {
        IDamageble damagebleObject = c.GetComponent<IDamageble>();
        if (damagebleObject != null)
        {
            damagebleObject.TakeHit(damage, hitPoint, transform.forward);
        }
        GameObject.Destroy(gameObject);
    }
}
