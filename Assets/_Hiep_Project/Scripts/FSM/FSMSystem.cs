using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem : MonoBehaviour
{

	private List<FSMState> lsStates = new List<FSMState> ();
	public FSMState currentState;

	#region States

	public void AddState (FSMState state)
	{
		lsStates.Add (state);
		if (lsStates.Count == 1) {
			currentState = state;
			currentState.OnEnter ();
		}
	}

	public void GotoState (FSMState state)
	{
		if (currentState != null) {
			currentState.OnExit ();
		}
		currentState = state;
		currentState.OnEnter ();
	}

	public void GotoState (FSMState state, object data)
	{
		if (currentState != null) {
			currentState.OnExit ();
		}
		currentState = state;
		currentState.OnEnter (data);
	}

	#endregion

	#region Unity function

	// Use this for initialization
	void Start ()
	{
		OnSystemStart ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		OnSystemUpdate ();
		if (currentState != null) {
			currentState.OnUpdate ();
		}
	}

	void FixedUpdate ()
	{
		OnSystemFixedUpdate();
		if (currentState != null) {
			currentState.OnFixedUpdate ();
		}
	}

	void LateUpdate ()
	{
        OnSystemLateUpdate();
		if (currentState != null) {
			currentState.OnLateUpdate ();
		}
	}

	public virtual void OnSystemUpdate ()
	{
		
	}
    public virtual void OnSystemLateUpdate()
    {

    }
	public virtual void OnSystemStart ()
	{

	}

	public virtual void OnSystemFixedUpdate()
    {

    }
	#endregion
}
