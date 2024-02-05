using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    private float enemySpeed = 3.0f;
    private float obstacleRange = 5.0f;
    private float sphereRadius = 0.75f;

    public enum EnemyStates
    {
        alive,
        dead
    };

    private EnemyStates state;

    [SerializeField] private GameObject laserBeamPrefab;
    private GameObject laserBeam;
    private float fireRate = 2.0f;
    private float nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        state = EnemyStates.alive;
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case EnemyStates.alive:
                //Move Enemy
                Vector3 movement = Vector3.forward * enemySpeed * Time.deltaTime;
                transform.Translate(movement);
                //generate Ray
                Ray ray = new Ray(transform.position, transform.forward);


                //Spherecast and determine if Enemy needs to turn
                RaycastHit hit;
                if (Physics.SphereCast(ray, sphereRadius, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    if (hitObject.GetComponent<PlayerCharacter>())
                    {
                        //spherecast hit player, fire laser!
                        if(laserBeam == null && Time.time > nextFire)
                        {
                            nextFire = Time.time + fireRate;
                            laserBeam = Instantiate(laserBeamPrefab) as GameObject;
                            laserBeam.transform.position = transform.TransformPoint(0, 1.5f, 1.5f);
                            laserBeam.transform.rotation = transform.rotation;
                        }
                    }
                    else if (hit.distance < obstacleRange)
                    {
                        float turnAngle = Random.Range(-110, 110);
                        transform.Rotate(Vector3.up * turnAngle);
                    }
                }
                break;
            case EnemyStates.dead:
                //do nothing
                break;
        }
       
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //determine the range vector (starting at the enemy)
        Vector3 rangeTest = transform.position + transform.forward * obstacleRange;
        //draw a line to show the range vector
        Debug.DrawLine(transform.position, rangeTest);
        //draw a wire sphere at the point on the end of the range vector.
        Gizmos.DrawWireSphere(rangeTest, sphereRadius);
    }

    public void ChangeState(EnemyStates state)
    {
        this.state = state;
    }
}
