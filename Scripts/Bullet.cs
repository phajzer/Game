using UnityEngine;

public class Bullet : MonoBehaviour {


    public GameObject explosion;
    private Transform target;
    public float speed = 5f;

    public void Seek(Transform target)
    {
        this.target = target;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
		
	}

    void HitTarget()
    {
        GameObject effect = (GameObject) Instantiate(explosion, transform.position, transform.rotation);
        Destroy(effect, 2f);
        Destroy(gameObject);
    }
}
