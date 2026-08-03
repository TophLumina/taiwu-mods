using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.Item;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.DefenseAndAssist;

public class FoMenShiZiHou : AssistSkillBase
{
	private const int AddCostPercent = 100;

	private int _addingCostCharId;

	private short _addingCostSkillId;

	public FoMenShiZiHou()
	{
	}

	public FoMenShiZiHou(CombatSkillKey skillKey)
		: base(skillKey, 1606)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnCombatBegin(DataContext context)
	{
		_addingCostCharId = -1;
		_addingCostSkillId = -1;
		AppendAffectedAllEnemyData(context, 207, EDataModifyType.AddPercent, -1);
		AppendAffectedAllEnemyData(context, 9, EDataModifyType.Custom, -1);
		AppendAffectedAllEnemyData(context, 14, EDataModifyType.Custom, -1);
		AppendAffectedAllEnemyData(context, 11, EDataModifyType.Custom, -1);
		AppendAffectedAllEnemyData(context, 204, EDataModifyType.AddPercent, -1);
		AppendAffectedAllEnemyData(context, 13, EDataModifyType.Custom, -1);
		AppendAffectedAllEnemyData(context, 10, EDataModifyType.Custom, -1);
		AppendAffectedAllEnemyData(context, 12, EDataModifyType.Custom, -1);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && base.CanAffect && CombatSkillEquipType.IsAttack(skillId) && DomainManager.Combat.InAttackRange(base.CombatChar) && !base.CombatChar.GetAutoCastingSkill())
		{
			_addingCostCharId = base.EnemyChar.GetId();
			_addingCostSkillId = skillId;
			DoClearSkill(context);
			DoMakeAttack();
			InvalidAllCache(context);
			ShowSpecialEffectTips(1);
			ShowSpecialEffectTips(2);
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && _addingCostCharId >= 0 && skillId == _addingCostSkillId)
		{
			_addingCostCharId = -1;
			_addingCostSkillId = -1;
			InvalidAllCache(context);
		}
	}

	private void DoClearSkill(DataContext context)
	{
		if (!(base.IsDirect ? (base.EnemyChar.GetAffectingMoveSkillId() < 0) : (base.EnemyChar.GetAffectingDefendSkillId() < 0)))
		{
			if (base.IsDirect)
			{
				ClearAffectingAgileSkill(context, base.EnemyChar);
			}
			else
			{
				DomainManager.Combat.ClearAffectingDefenseSkill(context, base.EnemyChar);
			}
			ShowSpecialEffectTips(0);
		}
	}

	private void DoMakeAttack()
	{
		Weapon weapon = DomainManager.Combat.GetUsingWeapon(base.CombatChar);
		if (weapon.GetTemplateId() == 884)
		{
			CombatContext context = CombatContext.Create(base.CombatChar, null, -1, -1);
			int hitOdds = context.CalcProperty(3).HitOdds;
			int damageValue = CFormula.FormulaCalcDamageValue(context.BaseDamage, hitOdds, 100L, context.AttackOdds);
			damageValue *= (CValuePercent)base.SkillInstance.GetPower();
			context.Defender.AddMindDamage(context, damageValue, context.SkillTemplateId);
			ShowSpecialEffectTips(3);
		}
	}

	private void InvalidAllCache(DataContext context)
	{
		InvalidateAllEnemyCache(context, (ushort)(base.IsDirect ? 207 : 204));
		InvalidateAllEnemyCache(context, (ushort)(base.IsDirect ? 9 : 13));
		InvalidateAllEnemyCache(context, (ushort)(base.IsDirect ? 14 : 10));
		InvalidateAllEnemyCache(context, (ushort)(base.IsDirect ? 11 : 12));
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		if (_addingCostCharId < 0 || dataKey.CharId != _addingCostCharId)
		{
			return dataValue;
		}
		bool isDirect = base.IsDirect;
		bool flag = isDirect;
		if (flag)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag2 = ((fieldId == 9 || fieldId == 11 || fieldId == 14) ? true : false);
			flag = flag2;
		}
		if (flag)
		{
			return 0;
		}
		bool flag3 = !base.IsDirect;
		bool flag4 = flag3;
		if (flag4)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag2 = ((fieldId == 10 || (uint)(fieldId - 12) <= 1u) ? true : false);
			flag4 = flag2;
		}
		if (flag4)
		{
			return 0;
		}
		return dataValue;
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.IsNormalAttack || dataKey.CharId != _addingCostCharId || _addingCostCharId < 0 || !base.CanAffect)
		{
			return 0;
		}
		ushort fieldId = dataKey.FieldId;
		if (1 == 0)
		{
		}
		int result = fieldId switch
		{
			207 => (base.IsDirect && CombatSkillEquipType.IsAgile(dataKey.CombatSkillId)) ? 100 : 0, 
			204 => (!base.IsDirect && CombatSkillEquipType.IsDefense(dataKey.CombatSkillId)) ? 100 : 0, 
			_ => 0, 
		};
		if (1 == 0)
		{
		}
		return result;
	}
}
