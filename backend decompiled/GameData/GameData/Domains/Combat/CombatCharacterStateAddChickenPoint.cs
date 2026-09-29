using GameData.Combat.Chicken;
using GameData.Common;
using GameData.Domains.Combat.Chicken;
using GameData.GameDataBridge;

namespace GameData.Domains.Combat;

public class CombatCharacterStateAddChickenPoint : CombatCharacterStateBase
{
	private const string EnterAni = "SC_001";

	private const string LeaveAniWithoutChicken = "SC_002_1";

	private const string LeaveAniWithChicken = "SC_002_2";

	private const string SoundName = "sc_001";

	private CombatCharacter _teammateChar;

	private ChickenPointRuntime _newChickenPoint;

	private ChickenPointRuntime? _chickenReleased;

	public CombatCharacterStateAddChickenPoint(CombatDomain combatDomain, CombatCharacter combatChar)
		: base(combatDomain, combatChar, CombatCharacterStateType.AddChickenPoint)
	{
		IsUpdateOnPause = true;
	}

	public override void OnEnter()
	{
		base.OnEnter();
		DataContext context = CombatChar.GetDataContext();
		_teammateChar = CombatChar.ActingTeammateCommandChar;
		sbyte type = _teammateChar.GetCharacter().CalcSmarterChickenPersonalityType();
		if (type == -1)
		{
			type = sbyte.MaxValue;
		}
		int value = context.Random.Next(1, 10);
		_newChickenPoint = CurrentCombatDomain.CreateTemporaryChickenPoint(type, value);
		SetTeammateChicken(_newChickenPoint);
		_teammateChar.SetVisible(visible: true, context);
		_teammateChar.SetAnimationToLoop(null, context);
		_teammateChar.SetParticleToLoop(null, context);
		_teammateChar.SetParticleToPlay(null, context);
		_teammateChar.SetAnimationToPlayOnce("SC_001", context);
		_teammateChar.SetSkillSoundToPlay("sc_001", context);
		DelayCall(OnEnterAniEnd, AnimDataCollection.GetDurationFrame(GetFullAni("SC_001")));
	}

	private void OnEnterAniEnd()
	{
		DataContext context = CombatChar.GetDataContext();
		_chickenReleased = CurrentCombatDomain.AddChickenPointToCurrent(context, _newChickenPoint);
		ClearTeammateChicken();
		ChickenPointRuntime? chickenReleased = _chickenReleased;
		if (chickenReleased.HasValue)
		{
			ChickenPointRuntime removedStable = chickenReleased.GetValueOrDefault();
			if (true)
			{
				SetTeammateChicken(removedStable);
			}
		}
		string leaveAni = (_chickenReleased.HasValue ? "SC_002_2" : "SC_002_1");
		_teammateChar.SetAnimationToPlayOnce(leaveAni, context);
		DelayCall(Finish, AnimDataCollection.GetDurationFrame(GetFullAni(leaveAni)));
	}

	private void Finish()
	{
		DataContext context = CombatChar.GetDataContext();
		ClearTeammateChicken();
		_teammateChar.SetVisible(visible: false, context);
		_teammateChar.SetDisplayPosition(int.MinValue, context);
		_teammateChar.SetAnimationToLoop(null, context);
		_teammateChar.SetParticleToLoop(null, context);
		_teammateChar.SetParticleToPlay(null, context);
		_teammateChar.ClearTeammateCommand(context);
		CombatChar.StateMachine.TranslateState();
	}

	private string GetFullAni(string ani)
	{
		return _teammateChar.GetWrappedFullAnimationName(ani);
	}

	private void SetTeammateChicken(ChickenPointRuntime chickenPoint)
	{
		ChickenPointDto dto = (ChickenPointDto)chickenPoint;
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatShowChickenWithTeammate, _teammateChar.GetId(), dto);
	}

	private void ClearTeammateChicken()
	{
		GameData.GameDataBridge.GameDataBridge.AddDisplayEvent(DisplayEventType.CombatHideChickenWithTeammate, _teammateChar.GetId());
	}
}
