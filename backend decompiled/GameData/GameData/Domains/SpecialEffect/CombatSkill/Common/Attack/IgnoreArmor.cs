using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;

public class IgnoreArmor : CombatSkillEffectBase
{
	private const sbyte CostMainAttribute = 10;

	private const sbyte PenetrateOrResistChangeUnitPercent = 3;

	protected sbyte RequireMainAttributeType;

	private bool _affecting;

	private int _deltaMainAttribute;

	protected IgnoreArmor()
	{
	}

	protected IgnoreArmor(CombatSkillKey skillKey, int type)
		: base(skillKey, type, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(280, EDataModifyType.Custom, -1);
		CreateAffectedData((ushort)(base.IsDirect ? 44 : 46), EDataModifyType.AddPercent, -1);
		CreateAffectedData((ushort)(base.IsDirect ? 45 : 47), EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_AttackSkillAttackBegin(OnAttackSkillAttackBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
	}

	private void OnAttackSkillAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId, int index, bool hit)
	{
		if (attacker.GetId() == base.CharacterId && skillId == base.SkillTemplateId && hit)
		{
			ShowSpecialEffectTips(0);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (_affecting && (base.IsDirect ? (charId == base.CharacterId) : (isAlly != base.CombatChar.IsAlly)))
		{
			_affecting = false;
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 44 : 46));
			DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 45 : 47));
		}
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			AddMaxEffectCount();
		}
	}

	private void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (!DomainManager.Combat.IsCurrentCombatCharacter(base.CombatChar) || base.EffectCount <= 0 || charId != (base.IsDirect ? base.CharacterId : base.CurrEnemyChar.GetId()) || Config.CombatSkill.Instance[skillId].EquipType != 1)
		{
			return;
		}
		short originalMainAttribute = CharObj.GetCurrMainAttribute(RequireMainAttributeType);
		if (originalMainAttribute >= 10)
		{
			CharObj.ChangeCurrMainAttribute(context, RequireMainAttributeType, -10);
			short currentMainAttribute = CharObj.GetCurrMainAttribute(RequireMainAttributeType);
			if (originalMainAttribute > currentMainAttribute)
			{
				_deltaMainAttribute = originalMainAttribute - currentMainAttribute;
				_affecting = true;
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 44 : 46));
				DomainManager.SpecialEffect.InvalidateCache(context, base.CharacterId, (ushort)(base.IsDirect ? 45 : 47));
				ShowSpecialEffectTips(1);
				ReduceEffectCount();
			}
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !_affecting)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if ((uint)(fieldId - 44) <= 3u)
		{
			return _deltaMainAttribute * 3;
		}
		return 0;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.SkillKey != SkillKey || dataKey.FieldId != 280)
		{
			return dataValue;
		}
		return true;
	}
}
