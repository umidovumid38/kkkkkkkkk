using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public float RadiusAttack;
    public float RadiusWalk;
    public Light EnemylIGHT;
    private LayerMask _layerplayer;
    private LayerMask _layerGround;// Земля

    private bool isPointWalk;

    private Transform _player;
    private Vector3 _walkPos;

    private NavMeshAgent _agent;

    private void Start()
    {
        _layerGround = LayerMask.GetMask("Ground");
        _layerplayer = LayerMask.GetMask("Player");
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }
    private void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, RadiusAttack, _layerplayer))
        {
            _agent.SetDestination(_player.position);
            RadiusAttack = 10;
            _agent.speed = 8;
            EnemylIGHT.color = Color.red;
        }
        else
        {
            Walk();
            EnemylIGHT.color = Color.blue;
            RadiusAttack = 5;
            _agent.speed = 3;
        }
    }
    private void Walk()
    {
        if (isPointWalk == true)
        {
            _agent.SetDestination(_walkPos);
        }
        else
        {
            SetPointWalk();
        }
        if (Vector3.Distance(transform.position, _walkPos) < 1)
        {
            isPointWalk = false;
        }
    }
    private void SetPointWalk()
    {
        float X = Random.Range(-RadiusWalk, RadiusWalk);
        float Z = Random.Range(-RadiusWalk, RadiusWalk);
        _walkPos = new Vector3(X + transform.position.x, transform.position.y, Z + transform.position.z);

        Collider[] colliders = Physics.OverlapSphere(_walkPos, 2);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].tag == "Wall")
            {
                isPointWalk = false;
                return;
            }
        }
        if (Physics.Raycast(_walkPos, Vector3.down, 1, _layerGround))
        {
            isPointWalk = true;
        }
        else 
        {
        isPointWalk= false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMove>().Dead();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RadiusAttack);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, RadiusWalk);
        Gizmos.DrawSphere(_walkPos,0.5f);
    }
}
