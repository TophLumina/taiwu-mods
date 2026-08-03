using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.GoodSuper;

public class LiKuXiuJian : MysteryEffectBase
{
	private const int AddPowerUnit = 10;

	private int _affectedUnit;

	protected override short SpecialEffectId => 1772;

	public LiKuXiuJian()
	{
	}

	public LiKuXiuJian(int charId, int itemId)
		: base(charId, itemId, 50104)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(199, EDataModifyType.Add, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		Events.UnRegisterHandler_CombatSettlement(OnCombatSettlement);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			AutoMonitor(ParseCombatCharacterDataUid(50), Update);
			Update(context, default(DataUid));
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		_affectedUnit = 0;
		InvalidateCache(context, 199);
		ClearMonitors();
	}

	private void Update(DataContext context, DataUid uid)
	{
		int affectedUnit = (DomainManager.Combat.IsCharacterHalfFallen(base.CombatChar) ? base.CombatChar.CalcMarkTypeCount() : 0);
		if (affectedUnit != _affectedUnit)
		{
			_affectedUnit = affectedUnit;
			InvalidateCache(context, 199);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 199)
		{
			return _affectedUnit * 10;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
