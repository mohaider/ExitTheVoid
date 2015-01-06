using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
	public float speed = 5f;
    public float maxSpeed = 5f;
    public float jumpMoveScalar = 0.3f;

    public GUIText info;
    private string[] information;

	private bool lookingRight = false;
	private bool isGrounded=true;
    bool isLanded = true;

    //this is used to calculate the starting jumping point position in order to calculate the angle at which the player is in
    private bool startJumpingPoint = false;
    private Vector2 jumpingPoint;
    public bool IsLanded
    {
        get { return isLanded; }
        set { isLanded = value; }
    }
	public LayerMask groundMask;
	public float playerJumpForceVertical = 800f;
	public float playerJumpForceHorizontal = 10f;
	public float runSpeed=0;
	private Animation anim;
	public AnimationClip idle;
	public AnimationClip run;
	private Animator animator;
//	tk2dSpriteAnimator animator;
	float moveHorizontally;
	//private int countToIdle = 50;
	//private int i = 0;
	private bool playerHasLanded = true;

	private bool isRidingElevator = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
   


	BoxCollider2D boxCollider;
	//PolygonCollider2D polyCollider;
	Collider2D collider;
	SpriteRenderer sp;

	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();
        information = new string[8];

	}
	void Awake()
	{
		boxCollider = GetComponent<BoxCollider2D>();

		collider = GetComponent<CircleCollider2D> ();
		sp = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		Animate ();
        UpdateInfo();
        if (!isRidingElevator)
        {
            JumpWithCircleColliderAttached();
            Movement2();

        }
	}
    void UpdateInfo()
    {
        if (info != null)
        {
            info.guiText.text = "";
            for (int i = 0; i < information.Length; i++)
            {
                info.guiText.text += information[i];
                info.guiText.text += "\n";
            }
        }
    }

    void FixedUpdate()
    {
    


    }

	void Animate()
	{

		if(isLanded)
			animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis ("Horizontal")));

		animator.SetBool ("isJumping", !isLanded);

	}

	void Movement()
	{
		 moveHorizontally = Input.GetAxis("Horizontal");  	//for buttons a,d

		Vector2 horizontalMovement = new Vector2(moveHorizontally * speed,rigidbody2D.velocity.y); 
        float hSpeed = moveHorizontally=moveHorizontally * speed;
        if (isLanded)
             horizontalMovement = new Vector2( hSpeed ,rigidbody2D.velocity.y);

        else if (!isLanded)
        {

            float adj = transform.position.x - jumpingPoint.x;
            float opp = transform.position.y - jumpingPoint.y;

           // float theta = Mathf.Atan2(transform.position.y, jumpingPoint.x);
            float theta = Mathf.Atan2(opp, adj);
            information[0] = "theta: " + theta;
            float prevVel = rigidbody2D.velocity.x;
            information[1] = "prevVel: " + prevVel;
            

           // float hv = 50f*Time.fixedDeltaTime * Mathf.Cos(theta ) * prevVel;

            float hv = 50f*Time.fixedDeltaTime * Mathf.Cos(theta) * prevVel;
            information[2] = "hv: " + hv;

            if (hv > -0.1 && hv < 0.1)
                hv = 0;
            print("fixedDeltaTime: " + Time.fixedDeltaTime);
            information[5] = "current position : " + transform.position;

            horizontalMovement = new Vector2( hv, rigidbody2D.velocity.y);
        }


    		rigidbody2D.velocity = horizontalMovement;

		if (moveHorizontally > 0 && !lookingRight || moveHorizontally < 0 && lookingRight)
			Flip ();

	}
    void Movement2()
    {

        moveHorizontally = Input.GetAxis("Horizontal");  	//for buttons a,d
        Vector2 horizontalSpeed = new Vector2(); 
        
        float hSpeed = moveHorizontally * speed;


        if (isLanded)
            horizontalSpeed = new Vector2(hSpeed, rigidbody2D.velocity.y);


        else if (!isLanded)
        {
            float prevVel = rigidbody2D.velocity.x;
            information[0] = "prevVel: " + prevVel;

            float newVel = Mathf.Lerp(prevVel, 0, Time.deltaTime) + (moveHorizontally * speed* 0.03f);
            information[1] = "newVel: " + newVel;


            horizontalSpeed = new Vector2(newVel, rigidbody2D.velocity.y);
        }


        rigidbody2D.velocity = horizontalSpeed;

        if (moveHorizontally > 0 && !lookingRight || moveHorizontally < 0 && lookingRight)
            Flip();
    }
    

    /*
     * useless. Add force isn't intuitive for 2D
     * This method takes into account if the player is already jumping.
     * If he is jumping then we multiply the horizontal force by  jumpMoveScalar
     */
      [System.Obsolete("Use Movement() instead ", true)]
	void Move()
	{
		moveHorizontally = Input.GetAxis("Horizontal");  	//for buttons a,d

        //will use this to compute the difference between the current speed and max speed
        float currSpeed =Mathf.Abs( Mathf.Sqrt(Vector2.SqrMagnitude(rigidbody2D.velocity)));
        Vector2 horizontalMovement = new Vector2(moveHorizontally * speed, rigidbody2D.velocity.y);

        //if the current speed is higher than the maxspeed
        //apply a force in the opposite direction proportional to the current 
        if (currSpeed > maxSpeed && isLanded)
        {
            
            //if (!IsLanded)
            //{
            //  //  horizontalMovement = new Vector2(moveHorizontally *  jumpMoveScalar, rigidbody2D.velocity.y);
            //    float differenceInJumpVel = rigidbody2D.velocity.x - maxSpeed;
                
            //}
            //if (isLanded)
            //{
                float differenceInVel = currSpeed - maxSpeed;
                float f = differenceInVel * rigidbody2D.mass / Time.fixedDeltaTime * Mathf.Sign(Input.GetAxis("Horizontal"))*-1;

          
              
                Vector2 oppForce = new Vector2(f, 0);
                rigidbody2D.AddForce(oppForce);
                
     //       }
        }
           
		//if he's in the air, then halve his horizontal force
        if (isLanded)
            rigidbody2D.AddForce(horizontalMovement);
    
    
        
	//	if (!isLanded)
      //      horizontalMovement.x = horizontalMovement.x * jumpMoveScalar;

	//	rigidbody2D.velocity = horizontalMovement;
		
		if (moveHorizontally > 0 && !lookingRight || moveHorizontally < 0 && lookingRight)
			Flip ();

	}
	void Flip()
	{
			lookingRight = !lookingRight;
		//Vector3 newScale = transform.localScale;
		//newScale.x *= -1f;
		//transform.localScale = newScale;
		if (!lookingRight)
			transform.localEulerAngles = new Vector3(0f,0f,0f);
		else
			transform.localEulerAngles = new Vector3(0f,180f,0f);
	}

    [System.Obsolete("Use JumpWithCircleColliderAttached() instead ",true)]
	void Jump()
	{

		Vector2 pointA = transform.position;
		pointA += new Vector2(-boxCollider.size.x/2f, -boxCollider.size.y/2f);
		//print ("PointA is " + pointA);
		Vector2 pointB = pointA;
		pointB += new Vector2(boxCollider.size.x,  -0.1f);
		//print ("pointB is " + pointB);
		isGrounded = Physics2D.OverlapArea(pointA, pointB, groundMask);

		//isGrounded = Physics2D.Raycast(transform.position,-Vector2.up, 
//		print ("isgrounded" + isGrounded);
		if (isGrounded && !isLanded)
		{
			isLanded = true;
			//landAudio.Play();
		}
		if (isGrounded && Input.GetButtonDown("Jump"))
		{
            float f = Vector3.Magnitude(rigidbody2D.velocity) * rigidbody2D.mass / Time.fixedDeltaTime;
            
			rigidbody2D.AddForce(new Vector2(f, playerJumpForceVertical));
		}
		else if (Input.GetButtonUp("Jump") && rigidbody2D.velocity.y > 0)
		{
			rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
		}
		if (!isGrounded)
			isLanded = false;


	}
	void JumpWithCircleColliderAttached()
	{
		isGrounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, groundMask);

		
		if (isGrounded && !isLanded)
		{
			isLanded = true;
			//landAudio.Play();
		}
        // if moving before jumping, add the current speed of the horizontal movement to the jump
		if (isGrounded && Input.GetButtonDown("Jump"))
		{

            jumpingPoint = transform.position;
            //float f = Mathf.Sqrt(Vector2.SqrMagnitude(rigidbody2D.velocity)) * rigidbody2D.mass / Time.fixedDeltaTime;
            //f *= Input.GetAxis("Horizontal");
            float f = Vector3.Magnitude(rigidbody2D.velocity) * rigidbody2D.mass / Time.fixedDeltaTime * Mathf.Sign(Input.GetAxis("Horizontal"))/2;
            
            information[3] = "current velocity" + rigidbody2D.velocity.x;
			rigidbody2D.AddForce(new Vector2(f, playerJumpForceVertical));
            information[4] = "jumping point " + jumpingPoint;
            
		}
        //else if (Input.GetButtonUp("Jump") && rigidbody2D.velocity.y > 0)
        //{
        //    rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0);
        //}
		if (!isGrounded)
			isLanded = false;
	}


	public Vector2 getDirection()
	{
		if (lookingRight)
			return new Vector2(1,0);
		else 
			return new Vector2(-1,0);
	}

	void OnTriggerStay2D(Collider2D col)
	{
		if (col.tag == "Elevator" && Input.GetButtonDown("Interact") && !isRidingElevator)
		{
			col.gameObject.SendMessage ("Activate", this.gameObject);
			moveHorizontally= 0f;
		}			
			

	}

	void DeactivateControls()
	{
		isRidingElevator = true;
	}

	void ReactivateControls()
	{
		isRidingElevator = false;
	}



}
