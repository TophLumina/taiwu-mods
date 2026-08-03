using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Shaolinpai.FistAndPalm;

public class DaJinGangQuan : CombatSkillEffectBase
{
	private const sbyte TransferPenetratePercent = 40;

	private const sbyte CostAttribute = 10;

	private const short StatePower = 250;

	private int _transferPenetrate;

	public DaJinGangQuan()
	{
	}

	public DaJinGangQuan(CombatSkillKey skillKey)
		: base(skillKey, 1104, -1)
	{
	}

	public override void OnEnable(DataContext context)
	{
		Events.RegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.RegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_PrepareSkillEnd(OnPrepareSkillEnd);
		Events.UnRegisterHandler_CastSkillEnd(OnCastSkillEnd);
	}

	private unsafe void OnPrepareSkillEnd(DataContext context, int charId, bool isAlly, short skillId)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId && DomainManager.Combat.InAttackRange(base.CombatChar))
		{
			MainAttributes selfAttributes = CharObj.GetMaxMainAttributes();
			MainAttributes enemyAttributes = base.CurrEnemyChar.GetCharacter().GetMaxMainAttributes();
			if (selfAttributes.Items[0] > enemyAttributes.Items[0])
			{
				OuterAndInnerInts penetrations = CharObj.GetPenetrations();
				_transferPenetrate = (base.IsDirect ? penetrations.Inner : penetrations.Outer) * 40 / 100;
				AppendAffectedData(context, base.CharacterId, 44, EDataModifyType.Add, -1);
				AppendAffectedData(context, base.CharacterId, 45, EDataModifyType.Add, -1);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private unsafe void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			MainAttributes selfAttributes = CharObj.GetCurrMainAttributes();
			if (PowerMatchAffectRequire(power) && selfAttributes.Items[0] >= 10)
			{
				CharObj.ChangeCurrMainAttribute(context, 0, -10);
				DomainManager.Combat.AddCombatState(context, base.CombatChar, 1, (short)(base.IsDirect ? 4 : 6), 250);
				DomainManager.Combat.AddCombatState(context, base.CombatChar, 2, (short)(base.IsDirect ? 5 : 7), 250);
				ShowSpecialEffectTips(1);
			}
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId)
		{
			return 0;
		}
		if (dataKey.FieldId == (base.IsDirect ? 44 : 45))
		{
			return _transferPenetrate;
		}
		if (dataKey.FieldId == (base.IsDirect ? 45 : 44))
		{
			return -_transferPenetrate;
		}
		return 0;
	}
}
