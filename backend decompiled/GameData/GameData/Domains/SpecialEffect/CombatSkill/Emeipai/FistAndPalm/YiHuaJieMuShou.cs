using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;

namespace GameData.Domains.SpecialEffect.CombatSkill.Emeipai.FistAndPalm;

public class YiHuaJieMuShou : CombatSkillEffectBase
{
	private const sbyte TransferPenetrateResistPercent = 40;

	private const sbyte CostAttribute = 10;

	private const short StatePower = 250;

	private int _transferPenetrateResist;

	public YiHuaJieMuShou()
	{
	}

	public YiHuaJieMuShou(CombatSkillKey skillKey)
		: base(skillKey, 2104, -1)
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
			if (selfAttributes.Items[1] > enemyAttributes.Items[1])
			{
				OuterAndInnerInts penetrationResists = base.CurrEnemyChar.GetCharacter().GetPenetrationResists();
				_transferPenetrateResist = (base.IsDirect ? penetrationResists.Outer : penetrationResists.Inner) * 40 / 100;
				AppendAffectedCurrEnemyData(context, 46, EDataModifyType.Add, -1);
				AppendAffectedCurrEnemyData(context, 47, EDataModifyType.Add, -1);
				ShowSpecialEffectTips(0);
			}
		}
	}

	private unsafe void OnCastSkillEnd(DataContext context, int charId, bool isAlly, short skillId, sbyte power, bool interrupted)
	{
		if (charId == base.CharacterId && skillId == base.SkillTemplateId)
		{
			MainAttributes selfAttributes = CharObj.GetCurrMainAttributes();
			if (PowerMatchAffectRequire(power) && selfAttributes.Items[1] >= 10)
			{
				CharObj.ChangeCurrMainAttribute(context, 1, -10);
				DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 1, (short)(base.IsDirect ? 13 : 15), 250);
				DomainManager.Combat.AddCombatState(context, base.CurrEnemyChar, 2, (short)(base.IsDirect ? 14 : 16), 250);
				ShowSpecialEffectTips(1);
			}
			RemoveSelf(context);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CurrEnemyChar.GetId())
		{
			return 0;
		}
		if (dataKey.FieldId == (base.IsDirect ? 47 : 46))
		{
			return _transferPenetrateResist;
		}
		if (dataKey.FieldId == (base.IsDirect ? 46 : 47))
		{
			return -_transferPenetrateResist;
		}
		return 0;
	}
}
