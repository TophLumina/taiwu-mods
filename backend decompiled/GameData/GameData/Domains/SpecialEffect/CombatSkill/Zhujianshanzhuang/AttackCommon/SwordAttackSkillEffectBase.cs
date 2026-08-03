using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Zhujianshanzhuang.AttackCommon;

public abstract class SwordAttackSkillEffectBase : SwordUnlockEffectBase
{
	private int _addingValue;

	private short _addingSkillId;

	protected abstract ushort FieldId { get; }

	protected abstract int AddValue { get; }

	private int EffectAddValue => AddValue;

	private int SelfAddValue => base.IsDirectOrReverseEffectDoubling ? (AddValue * 2) : AddValue;

	protected SwordAttackSkillEffectBase()
	{
	}

	protected SwordAttackSkillEffectBase(CombatSkillKey skillKey, int type)
		: base(skillKey, type)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(FieldId, EDataModifyType.AddPercent, -1);
		_addingValue = 0;
		_addingSkillId = -1;
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		base.OnDisable(context);
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (attacker.GetId() == base.CharacterId)
		{
			if (skillId == base.SkillTemplateId && base.IsReverseOrUsingDirectWeapon)
			{
				_addingValue += SelfAddValue;
			}
			if (base.EffectCount > 0)
			{
				ReduceEffectCount();
				_addingValue += EffectAddValue;
			}
			if (_addingValue > 0)
			{
				_addingSkillId = skillId;
				ShowSpecialEffectTips(base.IsDirect, 1, 0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == _addingSkillId)
		{
			_addingValue = 0;
			_addingSkillId = -1;
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.CombatSkillId != _addingSkillId || dataKey.FieldId != FieldId)
		{
			return 0;
		}
		return _addingValue;
	}
}
