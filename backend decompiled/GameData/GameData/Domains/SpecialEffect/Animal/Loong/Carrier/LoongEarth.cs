using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;

namespace GameData.Domains.SpecialEffect.Animal.Loong.Carrier;

public class LoongEarth : CombatStateEffectBase
{
	private const int AddSilenceFramePercent = 50;

	protected override short CombatStateId => 257;

	public LoongEarth(int charId)
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
		AppendAffectedAllEnemyData(context, 264, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId || dataKey.FieldId != 264)
		{
			return 0;
		}
		return 50;
	}
}
