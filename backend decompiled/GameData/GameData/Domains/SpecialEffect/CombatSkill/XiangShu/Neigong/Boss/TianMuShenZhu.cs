using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Implement;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class TianMuShenZhu : CombatSkillEffectBase, IMarkAppearHandler
{
	private const int ReduceDamagePerEffectCount = -10;

	private readonly MarkAppearInvoker _invoker;

	public TianMuShenZhu()
	{
		_invoker = new MarkAppearInvoker(this);
	}

	public TianMuShenZhu(CombatSkillKey skillKey)
		: base(skillKey, -1, -1)
	{
		_invoker = new MarkAppearInvoker(this);
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		_invoker.Setup();
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		CreateAffectedData(102, EDataModifyType.AddPercent, -1);
		CreateAffectedData(327, EDataModifyType.Custom, -1);
	}

	public override void OnDisable(DataContext context)
	{
		_invoker.Close();
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AddMaxEffectCount(autoRemoveOnNoCount: false);
	}

	public void OnMarkAppear(DataContext context, CombatCharacter combatChar, int appearCount)
	{
		if (combatChar == base.CombatChar)
		{
			AddEffectCount(appearCount);
			ShowSpecialEffectTips(2);
		}
		else if (combatChar.IsAlly != base.CombatChar.IsAlly)
		{
			ReduceEffectCount(appearCount);
			ShowSpecialEffectTips(1);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 102)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		ShowSpecialEffectTipsOnceInFrame(0);
		return -10 * base.EffectCount;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 327)
		{
			return base.GetModifiedValue(dataKey, dataValue);
		}
		return true;
	}
}
