using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Baihuagu.Music;

public class BuSiGui : CombatSkillEffectBase
{
	private const sbyte AddPowerUnit = 5;

	private const sbyte ChangeAttackDistanceUnit = 3;

	private int _addPower;

	private int _changeDistance;

	public BuSiGui()
	{
	}

	public BuSiGui(CombatSkillKey skillKey)
		: base(skillKey, 3301, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		CreateAffectedData(199, EDataModifyType.AddPercent, base.SkillTemplateId);
		if (base.IsDirect)
		{
			CreateAffectedData(145, EDataModifyType.Add, -1);
			CreateAffectedData(146, EDataModifyType.Add, -1);
		}
		else
		{
			CreateAffectedAllEnemyData(145, EDataModifyType.Add, -1);
			CreateAffectedAllEnemyData(146, EDataModifyType.Add, -1);
		}
		Events.RegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillBegin(OnPrepareSkillBegin);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private void OnPrepareSkillBegin(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (SkillKey.IsMatch(charId, skillId))
		{
			sbyte happinessType = HappinessType.GetHappinessType((base.IsDirect ? base.CombatChar : base.CurrEnemyChar).GetHappiness());
			if (happinessType > 3)
			{
				_addPower = 5 * (happinessType - 3);
				InvalidateCache(context, 199);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		TryClearChangeDistance(context, charId, isAlly, skillId);
		if (SkillKey.IsMatch(charId, skillId))
		{
			_addPower = 0;
			InvalidateCache(context, 199);
			if (power > 0)
			{
				DomainManager.Combat.AddCombatState(context, base.IsDirect ? base.CombatChar : base.CurrEnemyChar, 0, 36, power * 2);
			}
			sbyte happinessType = HappinessType.GetHappinessType((base.IsDirect ? base.CombatChar : base.CurrEnemyChar).GetHappiness());
			if (PowerMatchAffectRequire(power) && happinessType > 3)
			{
				_changeDistance = 3 * (happinessType - 3) * (base.IsDirect ? 1 : (-1));
				InvalidCacheAttackRange(context);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private void TryClearChangeDistance(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (_changeDistance != 0 && CombatSkillEquipType.IsAttack(skillId) && !(base.IsDirect ? (charId != base.CharacterId) : (isAlly == base.CombatChar.IsAlly)))
		{
			_changeDistance = 0;
			InvalidCacheAttackRange(context);
		}
	}

	private void InvalidCacheAttackRange(DataContext context)
	{
		if (base.IsDirect)
		{
			InvalidateCache(context, 145);
		}
		else
		{
			InvalidateAllEnemyCache(context, 145);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.FieldId == 199 && dataKey.CombatSkillId == base.SkillTemplateId)
		{
			return _addPower;
		}
		ushort fieldId = dataKey.FieldId;
		bool flag = (uint)(fieldId - 145) <= 1u;
		if (flag && !dataKey.IsNormalAttack)
		{
			return _changeDistance;
		}
		return 0;
	}
}
