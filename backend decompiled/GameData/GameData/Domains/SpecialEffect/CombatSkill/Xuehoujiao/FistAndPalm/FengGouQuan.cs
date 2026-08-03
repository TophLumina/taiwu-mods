using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.FistAndPalm;

public class FengGouQuan : CombatSkillEffectBase
{
	private const short DamageChangePercent = 90;

	private const sbyte BuffOdds = 60;

	private bool _firstCast;

	private short _costedSkillId;

	public FengGouQuan()
	{
	}

	public FengGouQuan(CombatSkillKey skillKey)
		: base(skillKey, 15100, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		_firstCast = true;
		_costedSkillId = -1;
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.RegisterHandler_CastAttackSkillBegin(CastAttackSkillBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
		Events.UnRegisterHandler_CastAttackSkillBegin(CastAttackSkillBegin);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			if (_firstCast)
			{
				_firstCast = false;
				AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 69 : 102), EDataModifyType.AddPercent, -1);
				AddMaxEffectCount();
			}
			else
			{
				RemoveSelf(context);
			}
		}
	}

	private void CastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		_costedSkillId = -1;
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && !_firstCast && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CombatSkillId < 0 || Config.CombatSkill.Instance[dataKey.CombatSkillId].EquipType != 1)
		{
			return 0;
		}
		if (dataKey.FieldId == (base.IsDirect ? 69 : 102) && (!base.IsDirect || (DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) && base.CombatChar.TeammateBeforeMainChar < 0)))
		{
			DataContext context = DomainManager.Combat.Context;
			if (dataKey.CombatSkillId != _costedSkillId)
			{
				ShowSpecialEffectTips(0);
				ReduceEffectCount();
				_costedSkillId = dataKey.CombatSkillId;
			}
			return (!context.Random.CheckPercentProb(60)) ? (base.IsDirect ? (-90) : 90) : (base.IsDirect ? 90 : (-90));
		}
		return 0;
	}
}
