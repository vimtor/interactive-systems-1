using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	private int _totalPickups = 0;
	private int _pickupCount = 0;

	void Start ()
	{
		_totalPickups = GameObject.FindGameObjectsWithTag("Pick Up").Length;

		EventManager.PickedUp.AddListener(HandlePickup);
		EventManager.CountdownFinished.AddListener(HandleCountdownFinished);
	}

	void HandleCountdownFinished()
	{
		if (HasRemainingPickups())
		{
			EventManager.GameLost.Invoke();
		}
	}

	void HandlePickup()
	{
		_pickupCount += 1;

		if (!HasRemainingPickups())
		{
			EventManager.GameWinned.Invoke();
		}
	}

	bool HasRemainingPickups()
	{
		return _pickupCount < _totalPickups;
	}
}