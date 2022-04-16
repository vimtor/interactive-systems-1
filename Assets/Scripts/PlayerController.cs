using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed;

	private Rigidbody _rigidbody;
	private bool _movementEnabled;

	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody>();
		_movementEnabled = true;

		EventManager.GameWinned.AddListener(HandleGameFinished);
		EventManager.GameLost.AddListener(HandleGameFinished);
	}

	void FixedUpdate ()
	{
		if (_movementEnabled)
		{
			MovePlayer();
		}
	}


	private void MovePlayer()
	{
		_rigidbody.AddForce(GetMovementAxis() * speed);
	}

	private Vector3 GetMovementAxis()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		return new Vector3 (moveHorizontal, 0.0f, moveVertical);
	}

	private void HandleGameFinished()
	{
		_movementEnabled = false;
	}
}