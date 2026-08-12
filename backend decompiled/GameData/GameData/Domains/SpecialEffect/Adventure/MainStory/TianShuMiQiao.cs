using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.Combat;

namespace GameData.Domains.SpecialEffect.Adventure.MainStory;

public class TianShuMiQiao : FeatureEffectBase
{
	private const int AddGoneMadInjury = 500;

	public TianShuMiQiao()
	{
	}

	public TianShuMiQiao(int charId, short featureId)
		: base(charId, featureId, 100001)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		CreateAffectedData(126, EDataModifyType.Custom, -1);
		CreateAffectedData(131, EDataModifyType.Custom, -1);
		CreateAffectedData(114, EDataModifyType.Custom, -1);
		CreateAffectedData(117, EDataModifyType.AddPercent, -1);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (DomainManager.Combat.IsCharInCombat(base.CharacterId))
		{
			ChangeBreathValue(context, base.CombatChar, 30000);
			ChangeStanceValue(context, base.CombatChar, 4000);
			DomainManager.Combat.AddTrick(context, base.CombatChar, 12, 9);
		}
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 117)
		{
			return base.GetModifyValue(dataKey, currModifyValue);
		}
		return 500;
	}

	public override bool GetModifiedValue(AffectedDataKey dataKey, bool dataValue)
	{
		bool flag = dataKey.CharId == base.CharacterId;
		bool flag2 = flag;
		if (flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = ((fieldId == 126 || fieldId == 131) ? true : false);
			flag2 = flag3;
		}
		if (flag2)
		{
			return false;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}

	public override long GetModifiedValue(AffectedDataKey dataKey, long dataValue)
	{
		if (dataKey.CharId != base.CharacterId || dataKey.FieldId != 114)
		{
			return dataValue;
		}
		EDamageType damageType = (EDamageType)dataKey.CustomParam0;
		if (damageType != EDamageType.Direct)
		{
			return dataValue;
		}
		return 0L;
	}
}
