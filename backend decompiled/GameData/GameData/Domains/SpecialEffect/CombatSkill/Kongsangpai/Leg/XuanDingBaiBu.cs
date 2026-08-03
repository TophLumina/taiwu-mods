using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Kongsangpai.Leg;

public class XuanDingBaiBu : CombatSkillEffectBase
{
	private const sbyte ChangeHitOrAvoid = 40;

	private const sbyte ChangeSelfHitOrAvoid = 60;

	private bool _affecting;

	public XuanDingBaiBu()
	{
	}

	public XuanDingBaiBu(CombatSkillKey skillKey)
		: base(skillKey, 10307, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.RegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.RegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.RegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_NormalAttackBegin(OnNormalAttackBegin);
		Events.UnRegisterHandler_NormalAttackAllEnd(OnNormalAttackAllEnd);
		Events.UnRegisterHandler_CastAttackSkillBegin(OnCastAttackSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
		Events.UnRegisterHandler_SkillEffectChange(OnSkillEffectChange);
	}

	private void OnNormalAttackBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, sbyte trickType, int pursueIndex)
	{
		if (IsSrcSkillPerformed && pursueIndex <= 0 && attacker.NormalAttackHitType != 3 && base.CombatChar == ((base.EffectCount % 2 != 0) ? (base.IsDirect ? defender : attacker) : (base.IsDirect ? attacker : defender)) && DomainManager.Combat.InAttackRange(attacker))
		{
			_affecting = true;
			ShowSpecialEffectTips(base.EffectCount % 2 == 0, 0, 1);
		}
	}

	private void OnNormalAttackAllEnd(DataContext context, CombatCharacter attacker, CombatCharacter defender)
	{
		if (IsSrcSkillPerformed && _affecting)
		{
			_affecting = false;
			ReduceEffectCount();
		}
	}

	private void OnCastAttackSkillBegin(DataContext context, CombatCharacter attacker, CombatCharacter defender, short skillId)
	{
		if (IsSrcSkillPerformed && base.CombatChar.SkillHitType.Exist((sbyte type) => 0 <= type && type <= 2) && base.CombatChar == ((base.EffectCount % 2 != 0) ? (base.IsDirect ? defender : attacker) : (base.IsDirect ? attacker : defender)) && DomainManager.Combat.InAttackRange(attacker))
		{
			_affecting = true;
			ShowSpecialEffectTips(base.EffectCount % 2 == 0, 0, 1);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (!IsSrcSkillPerformed)
		{
			if (charId == base.CharacterId && skillId == base.SkillTemplateId)
			{
				if (PowerMatchAffectRequire(power))
				{
					IsSrcSkillPerformed = true;
					_affecting = false;
					AddMaxEffectCount();
					AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 56 : 90), EDataModifyType.AddPercent, -1);
					AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 57 : 91), EDataModifyType.AddPercent, -1);
					AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 58 : 92), EDataModifyType.AddPercent, -1);
					AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 94 : 60), EDataModifyType.AddPercent, -1);
					AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 95 : 61), EDataModifyType.AddPercent, -1);
					AppendAffectedData(context, base.CharacterId, (ushort)(base.IsDirect ? 96 : 62), EDataModifyType.AddPercent, -1);
				}
				else
				{
					RemoveSelf(context);
				}
			}
		}
		else if (charId == base.CharacterId && skillId == base.SkillTemplateId && PowerMatchAffectRequire(power))
		{
			RemoveSelf(context);
		}
		else if (_affecting)
		{
			_affecting = false;
			ReduceEffectCount();
		}
	}

	private void OnSkillEffectChange(DataContext context, int charId, SkillEffectKey key, short oldCount, short newCount, bool removed)
	{
		if (removed && IsSrcSkillPerformed && charId == base.CharacterId && key.SkillId == base.SkillTemplateId && key.IsDirect == base.IsDirect)
		{
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (base.EffectCount % 2 == 0)
		{
			if (dataKey.FieldId == 56 || dataKey.FieldId == 57 || dataKey.FieldId == 58)
			{
				return (dataKey.CombatSkillId == base.SkillTemplateId) ? 60 : 40;
			}
			if (dataKey.FieldId == 90 || dataKey.FieldId == 91 || dataKey.FieldId == 92)
			{
				return (base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId) ? (-60) : (-40);
			}
		}
		else
		{
			if (dataKey.FieldId == 94 || dataKey.FieldId == 95 || dataKey.FieldId == 96)
			{
				return (base.CombatChar.GetPreparingSkillId() == base.SkillTemplateId) ? 60 : 40;
			}
			if (dataKey.FieldId == 60 || dataKey.FieldId == 61 || dataKey.FieldId == 62)
			{
				return (dataKey.CombatSkillId == base.SkillTemplateId) ? (-60) : (-40);
			}
		}
		return 0;
	}
}
