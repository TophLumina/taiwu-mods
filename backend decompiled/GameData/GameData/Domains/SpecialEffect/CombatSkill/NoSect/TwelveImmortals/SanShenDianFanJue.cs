using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.DomainEvents;
using GameData.Domains.CombatSkill;
using GameData.Domains.Map;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.NoSect.TwelveImmortals;

public class SanShenDianFanJue : TwelveImmortalsTrickBase
{
	private const int DirectAddPower = 100;

	private const int ReverseAddPowerUnit = 5;

	private bool _hasSun;

	private bool _hasMoon;

	private bool _hasStar;

	public SanShenDianFanJue()
	{
	}

	public SanShenDianFanJue(CombatSkillKey skillKey)
		: base(skillKey, 18007)
	{
	}

	public override void OnEnable(DataContext context)
	{
		base.OnEnable(context);
		Events.RegisterHandler_CombatBegin(OnCombatBegin);
		if (base.IsDirect)
		{
			_hasSun = CheckDistance(1109);
			CreateAffectedData(199, EDataModifyType.AddPercent, -1);
			_hasMoon = CheckDistance(1110);
			CreateAffectedData(227, EDataModifyType.Custom, -1);
			CreateAffectedData(228, EDataModifyType.Custom, -1);
			_hasStar = CheckDistance(1111);
			CreateAffectedData(208, EDataModifyType.Custom, -1);
		}
		else
		{
			CreateAffectedData(199, EDataModifyType.Add, -1);
		}
	}

	public override void OnDisable(DataContext context)
	{
		Events.UnRegisterHandler_CombatBegin(OnCombatBegin);
		base.OnDisable(context);
	}

	private void OnCombatBegin(DataContext context)
	{
		if (_hasSun)
		{
			ShowSpecialEffectTips(0);
		}
		if (_hasMoon)
		{
			ShowSpecialEffectTips(1);
		}
		if (_hasStar)
		{
			ShowSpecialEffectTips(2);
		}
	}

	private bool CheckDistance(short templateId)
	{
		if (!DomainManager.Character.TryGetFixedCharacterByTemplateId(templateId, out var character))
		{
			return false;
		}
		Location locationA = character.GetLocation();
		if (!locationA.IsValid())
		{
			return false;
		}
		Location locationB = CharObj.GetLocation();
		if (locationB.AreaId != locationA.AreaId)
		{
			return false;
		}
		byte areaSize = DomainManager.Map.GetAreaSize(locationA.AreaId);
		ByteCoordinate posA = ByteCoordinate.IndexToCoordinate(locationA.BlockId, areaSize);
		ByteCoordinate posB = ByteCoordinate.IndexToCoordinate(locationB.BlockId, areaSize);
		int distance = posA.GetManhattanDistance(posB);
		return distance <= base.TwelveImmortalsConfig.ImpactRange;
	}

	protected override void OnReverseEffectChanged(DataContext context)
	{
		InvalidateCache(context, 199);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 199)
		{
			return (!base.IsDirect) ? (5 * base.ReverseEffectUnit) : (_hasSun ? 100 : 0);
		}
		return base.GetModifyValue(dataKey, currModifyValue);
	}

	public override int GetModifiedValue(AffectedDataKey dataKey, int dataValue)
	{
		bool flag = dataKey.CharId == base.CharacterId;
		bool flag2 = flag;
		if (flag2)
		{
			ushort fieldId = dataKey.FieldId;
			bool flag3 = (uint)(fieldId - 227) <= 1u;
			flag2 = flag3;
		}
		if (flag2 && _hasMoon)
		{
			return 0;
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}

	public override List<NeedTrick> GetModifiedValue(AffectedDataKey dataKey, List<NeedTrick> dataValue)
	{
		if (dataKey.CharId == base.CharacterId && dataKey.FieldId == 208 && _hasStar)
		{
			dataValue.Clear();
		}
		return base.GetModifiedValue(dataKey, dataValue);
	}
}
