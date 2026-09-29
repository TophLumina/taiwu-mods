using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class LoongFire : CombatStateEffectBase
{
	private const int ChangeToOldOdds = 50;

	protected override short CombatStateId => 256;

	public LoongFire(int charId)
		: base(charId)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		AppendAffectedAllEnemyData(context, 345, EDataModifyType.Add, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId || dataKey.FieldId != 345)
		{
			return 0;
		}
		return CMath.SumPercentOdds(currModifyValue, 50);
	}
}
