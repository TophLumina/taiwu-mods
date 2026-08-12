using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Assist;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Assist;

public class KaiMingTianShou : AssistSkillBase, IMarkAppearHandler
{
	private const int AddDamagePerEffectCount = 10;

	private readonly MarkAppearInvoker _invoker;

	public KaiMingTianShou()
	{
		_invoker = new MarkAppearInvoker(this);
	}

	public KaiMingTianShou(CombatSkillKey skillKey)
		: base(skillKey, -1)
	{
		_invoker = new MarkAppearInvoker(this);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_invoker.Setup();
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		CreateAffectedData(69, EDataModifyType.AddPercent, -1);
	}

	public override void OnDisable(DataContext context)
	{
		_invoker.Close();
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AddMinEffectCount(autoRemoveOnNoCount: false);
	}

	public void OnMarkAppear(DataContext context, CombatCharacter combatChar, int appearCount)
	{
		if (combatChar == base.CombatChar)
		{
			ReduceEffectCount(appearCount);
			ShowSpecialEffectTips(1);
		}
		else if (combatChar.IsAlly != base.CombatChar.IsAlly)
		{
			AddEffectCount(appearCount);
			ShowSpecialEffectTips(2);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 69)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return 10 * base.EffectCount;
	}
}
