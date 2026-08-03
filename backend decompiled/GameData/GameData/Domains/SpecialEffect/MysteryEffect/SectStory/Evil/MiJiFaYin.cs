using System.Linq;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.MysteryEffect.SectStory.Evil;

public class MiJiFaYin : MysteryEffectBase
{
	private const int StatePowerToPower = 100;

	private int _addPower;

	protected override short SpecialEffectId => 1763;

	public MiJiFaYin()
	{
	}

	public MiJiFaYin(int charId, int itemId)
		: base(charId, itemId, 50010)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(199, EDataModifyType.Add, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		Events.RegisterHandler_CombatSettlement(OnCombatSettlement);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			AutoMonitor(ParseCombatCharacterDataUid(76), Update);
			AutoMonitor(ParseCombatCharacterDataUid(77), Update);
			Update(context, default(DataUid));
		}
	}

	private void OnCombatSettlement(DataContext context, sbyte combatStatus)
	{
		ClearMonitors();
		SetPower(context, 0);
	}

	private void Update(DataContext context, DataUid dataUid)
	{
		int power = base.CombatChar.GetBuffCombatStateCollection().StateDict.Values.Sum(((short power, bool reverse, int srcCharId) x) => x.power);
		power -= base.CombatChar.GetDebuffCombatStateCollection().StateDict.Values.Sum(((short power, bool reverse, int srcCharId) x) => x.power);
		power /= 100;
		if (power != _addPower)
		{
			SetPower(context, power);
		}
	}

	private void SetPower(DataContext context, int power)
	{
		_addPower = power;
		InvalidateCache(context, 199);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 199)
		{
			return _addPower;
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}
}
