using System;

namespace GameData.Utilities;

public class StateMachine<TContext>
{
	public interface IState
	{
		void OnEnter(TContext context, StateMachine<TContext> stateMachine, IState srcState);

		void OnExit(TContext context, StateMachine<TContext> stateMachine, IState dstState);

		void Update(TContext context, StateMachine<TContext> stateMachine);
	}

	private IState _currentState;

	private IState _targetState;

	private bool _isInTransition;

	public IState CurrentState => _currentState;

	public void ChangeState(TContext context, IState dstState)
	{
		if (_isInTransition)
		{
			throw new Exception($"Cannot perform transition from {_currentState} to {dstState} when another transition is already in progress.");
		}
		_isInTransition = true;
		IState srcState = _currentState;
		srcState?.OnExit(context, this, dstState);
		_currentState = dstState;
		dstState?.OnEnter(context, this, srcState);
		_isInTransition = false;
	}

	public void ChangeStateAsync(IState dstState)
	{
		if (_targetState != null)
		{
			throw new Exception($"Cannot perform async transition from {_currentState} to {dstState} when another async transition is already in schedule.");
		}
		_targetState = dstState;
	}

	public void Update(TContext context)
	{
		if (_targetState != null)
		{
			IState targetState = _targetState;
			_targetState = null;
			ChangeState(context, targetState);
		}
		_currentState.Update(context, this);
	}
}
