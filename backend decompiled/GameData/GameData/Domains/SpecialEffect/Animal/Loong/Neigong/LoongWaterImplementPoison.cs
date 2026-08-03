using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.SpecialEffect.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Neigong;

public class LoongWaterImplementPoison : ISpecialEffectImplement, ISpecialEffectModifier
{
	private const int AddPoisonLevel = 3;

	private readonly int _addPoisonDelayFrame;

	private readonly int _addPoisonValue;

	private int _addPoisonFrameCounter;

	public CombatSkillEffectBase EffectBase { get; set; }

	public LoongWaterImplementPoison(int addPoisonDelayFrame, int addPoisonValue)
	{
		_addPoisonDelayFrame = addPoisonDelayFrame;
		_addPoisonValue = addPoisonValue;
	}

	public void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	public void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatStateMachineUpdateEnd(OnCombatStateMachineUpdateEnd);
	}

	private void OnCombatStateMachineUpdateEnd(DataContext context, CombatCharacter combatChar)
	{
		if (combatChar.GetId() == EffectBase.CharacterId && !DomainManager.Combat.Pause)
		{
			_addPoisonFrameCounter++;
			if (_addPoisonFrameCounter >= _addPoisonDelayFrame)
			{
				_addPoisonFrameCounter -= _addPoisonDelayFrame;
				CombatCharacter enemyChar = DomainManager.Combat.GetCombatCharacter(!combatChar.IsAlly);
				DomainManager.Combat.AddPoison(context, combatChar, enemyChar, (sbyte)context.Random.Next(6), 3, _addPoisonValue, EffectBase.SkillTemplateId);
				EffectBase.ShowSpecialEffectTips(0);
			}
		}
	}
}
