using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

public class MarkAppearInvoker
{
	private readonly IMarkAppearHandler _handler;

	public MarkAppearInvoker(IMarkAppearHandler handler)
	{
		_handler = handler;
	}

	public void Setup()
	{
		Events.RegisterHandler_AddInjury(OnAddInjury);
		Events.RegisterHandler_FlawAdded(OnFlawAdded);
		Events.RegisterHandler_AcuPointAdded(OnAcuPointAdded);
		Events.RegisterHandler_AddMindMark(OnAddMindMark);
		Events.RegisterHandler_AddFatalDamageMark(OnAddFatalDamageMark);
	}

	public void Close()
	{
		Events.UnRegisterHandler_AddInjury(OnAddInjury);
		Events.UnRegisterHandler_FlawAdded(OnFlawAdded);
		Events.UnRegisterHandler_AcuPointAdded(OnAcuPointAdded);
		Events.UnRegisterHandler_AddMindMark(OnAddMindMark);
		Events.UnRegisterHandler_AddFatalDamageMark(OnAddFatalDamageMark);
	}

	private void OnAddInjury(DataContext context, CombatCharacter character, sbyte bodyPart, bool isInner, int value, bool changeToOld)
	{
		_handler.OnMarkAppear(context, character, value);
	}

	private void OnFlawAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		_handler.OnMarkAppear(context, combatChar, 1);
	}

	private void OnAcuPointAdded(DataContext context, CombatCharacter combatChar, sbyte bodyPart, sbyte level)
	{
		_handler.OnMarkAppear(context, combatChar, 1);
	}

	private void OnAddMindMark(DataContext context, CombatCharacter character, int count)
	{
		_handler.OnMarkAppear(context, character, count);
	}

	private void OnAddFatalDamageMark(DataContext context, CombatCharacter combatChar, int count)
	{
		_handler.OnMarkAppear(context, combatChar, count);
	}
}
