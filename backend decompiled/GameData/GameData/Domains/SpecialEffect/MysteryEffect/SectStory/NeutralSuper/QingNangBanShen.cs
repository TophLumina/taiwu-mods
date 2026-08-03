using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.NeutralSuper;

public class QingNangBanShen : MysteryEffectBase
{
	private const int RequireAttainment = 500;

	protected override short SpecialEffectId => 1777;

	private bool CanAffect => CharObj.GetLifeSkillAttainment(8) >= 500 && CharObj.GetLifeSkillAttainment(9) >= 500;

	public QingNangBanShen()
	{
	}

	public QingNangBanShen(int charId, int itemId)
		: base(charId, itemId, 50109)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(329, EDataModifyType.Custom, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId) && CanAffect)
		{
			ShowSpecialEffect(0);
		}
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 329)
		{
			return CanAffect || dataValue;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
