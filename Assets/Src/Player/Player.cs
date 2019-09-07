using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 1f;
	public float initialVelocity = 2f;
	public float decay = 0.1f;

	private int score = 0;
	private float velocity = 0;
	private int moveCount = 0;
	private CharacterController cc;

    private GameManager gameManager;

    enum State {
        Idle,
        Moving,
		Won
    }

    private State currentState = State.Idle;
    private static Player _instance;

    public static Player GetPlayer()
    {
        if (Player._instance == null)
        {
            return null;
        }
        return Player._instance;
    }

    // Use this for initialization
    void Start() {
		cc = this.GetComponent<CharacterController>();
        _instance = this;
        gameManager = GameManager.GetGameManager();
        gameManager.player = gameObject;
    }

	// Update is called once per frame
	void Update() {
        Vector3 direction = Physics.gravity;
		direction += this.transform.forward * velocity;

		cc.Move(direction * Time.deltaTime);

		switch (this.currentState) {
			case State.Idle:
				this.Idle();
				break;
			case State.Moving:
				this.Moving();
				break;
			case State.Won:
				this.Won();
				break;
		}
	}

	void Idle () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			this.transform.rotation *= Quaternion.Euler(0, -this.speed * Time.deltaTime, 0);
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			this.transform.rotation *= Quaternion.Euler(0, this.speed * Time.deltaTime, 0);
		}

		if (Input.GetKey(KeyCode.Space)) {
			// let's gooo
			this.currentState = State.Moving;
			this.velocity = this.initialVelocity;
			this.moveCount++;
            gameManager.CountMove();
		}
	}

	void Moving () {
		if (velocity > 0f) {
			this.velocity -= this.decay;
			this.velocity = Mathf.Clamp(this.velocity, 0, float.MaxValue);
		} else {
			this.velocity = 0;
			this.currentState = State.Idle;
		}
	}

	void Won () {
		//print("I Win");
		this.velocity = 0;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (this.currentState != State.Won) {
			//hit.gameObject.GetComponent<PlayerInteractable>()?.OnHit(hit, this);
			PlayerInteractable pi = hit.gameObject.GetComponent<PlayerInteractable>();
			if (pi) {
                if(pi.GetType() == typeof(Killing))
                {
                    gameManager.CountDeath();
                    gameManager.RespawnPlayer();
                }
				pi.OnHit(hit, this);
			}
		}
	}

	public float GetVelocity () {
		return this.velocity;
	}

	public void SetVelocity (float vel) {
		this.velocity = vel;
	}

	public void HasWon () {
		this.currentState = State.Won;
        gameManager.LoadNextLevel();
	}

	public void AccumulateScore (int scoreAdd) {
        gameManager.AddScore(scoreAdd);	
	}

    /*private void OnDestroy()
    {
        print("still alive~");
        gameManager.CountDeath();
        gameManager.ReloadScene();
        //gameManager.RespawnPlayer();
    }*/
}
