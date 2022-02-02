using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a simple Implamentaion of a Finite State Machine
/// </summary>
public class SimpleFSM : FSM
{
    public enum FSMState
    {
        None,
        Patrol,
        Chase,
        Attack,
        Dead,
    };
    // 
    public FSMState curState;
    // Speed of NPC 
    private float curSpeed;

    [SerializeField] GameObject Bullet;

    // Check states
    private bool bDead;
    private int healh;

    new private Rigidbody2D rigidbody2D;
    // Need a way to animate and change the animation state.
    public Animator anim;
    private float animationSpeed = 0.0f;
    private float movement = 0f;
    protected override void Initialize()
    {
        curState = FSMState.Patrol;
        curSpeed = 150.0f;
        bDead = false;
        elapsedTime = 0.0f;
        shootRate = 3.0f;
        healh = 100;

        pointList = GameObject.FindGameObjectsWithTag("WanderPoint");
        FindNextPoint();

        GameObject objPlayer = GameObject.FindGameObjectWithTag("Player");
        // Get Rigid Body
        rigidbody2D = GetComponent<Rigidbody2D>();

        playerTransform = objPlayer.transform;

        if (!playerTransform)
        {
            Debug.Log("Player Does not exist... Please add one " + "with Tag Named 'Player'");
        }
        // need to add a way to fire from the object



    }
    protected override void FSMUpdate()
    {
        switch (curState)
        {
            case FSMState.Patrol: UpdatePatrolState();break;
            case FSMState.Chase: UpdateChaseState(); break;
            case FSMState.Attack: UpdateAttackState();break;
            case FSMState.Dead: UpdateDeadState();break;

        }
        elapsedTime += Time.deltaTime;
        if(healh <= 0)
        {
            curState = FSMState.Dead;
        }
        // So any time We check the state we also want to check where the animation will be facing 
        animationUpdate();
    }
    protected void UpdatePatrolState()
    {
        if(Vector3.Distance(transform.position, destPos)<= 100.0f)
        {
            Debug.Log("Reached the destination point\n" + "Calculating next point");
            FindNextPoint();
        }
        else if (Vector3.Distance(transform.position, playerTransform.position) <= 300.0f)
        {
            Debug.Log("Switched to Chase Postion");
            curState = FSMState.Chase;
        }

        transform.Translate(Vector3.forward * Time.deltaTime * curSpeed);
    }
    protected void FindNextPoint()
    {
        int rndIndex = Random.Range(0, pointList.Length);
        float rndRadius = 10.0f;
        Vector3 rndPostion = Vector3.zero;
        destPos = pointList[rndIndex].transform.position + rndPostion;

        // Checks range and decided random points
        if (IsInCurrentRange(destPos))
        {
            rndPostion = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
            destPos = pointList[rndIndex].transform.position + rndPostion;
        }
    }
    protected bool IsInCurrentRange(Vector3 pos)
    {
        float xPos = Mathf.Abs(pos.x - transform.position.x);
        float zPos = Mathf.Abs(pos.z - transform.position.x);
        if(xPos <= 50 && zPos <= 50)
            return true;
        return false;
    }

    protected void UpdateChaseState()
    {

    }
    protected void UpdateAttackState()
    {

    }
    protected void UpdateDeadState()
    {

    }
    protected void Explode()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    private void animationUpdate()
    {
        anim.SetFloat("Speed", Mathf.Abs(animationSpeed));
        Vector3 charecterScale = transform.localScale;
        movement = Input.GetAxis("Horizontal");
        if (movement > 0f)
        {
            charecterScale.x = 10;
            animationSpeed = 1.0f;
        }
        else if (movement < 0f)
        {
            charecterScale.x = -10;
            animationSpeed = 1.0f;
        }
    }
}
