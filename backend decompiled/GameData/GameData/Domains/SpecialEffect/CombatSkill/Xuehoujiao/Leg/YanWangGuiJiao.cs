using System.Collections.Generic;
using Config;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Domains.Map;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuehoujiao.Leg;

public class YanWangGuiJiao : PowerUpOnCast
{
	private const sbyte AddPowerUnit = 10;

	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public YanWangGuiJiao()
	{
	}

	public YanWangGuiJiao(CombatSkillKey skillKey)
		: base(skillKey, 15306)
	{
	}

	public override void OnEnable(DataContext context)
	{
		GameData.Domains.Character.Character srcFiveElementsChar = (base.IsDirect ? base.CombatChar : DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly)).GetCharacter();
		sbyte srcFiveElementsType = (sbyte)NeiliType.Instance[srcFiveElementsChar.GetNeiliType()].FiveElements;
		PowerUpValue = 0;
		if (srcFiveElementsType != 5 && srcFiveElementsType >= 0)
		{
			Location location = CharObj.GetLocation();
			if (!location.IsValid() && base.CharacterId == DomainManager.Taiwu.GetTaiwuCharId())
			{
				location = CharObj.GetValidLocation();
			}
			if (location.IsValid())
			{
				CalcPowerUp(location, srcFiveElementsType);
			}
		}
		base.OnEnable(context);
	}

	private void CalcPowerUp(Location location, sbyte srcFiveElementsType)
	{
		MapBlockData block = DomainManager.Map.GetBlock(location.AreaId, location.BlockId);
		List<MapBlockData> viewRangeBlocks = ObjectPool<List<MapBlockData>>.Instance.Get();
		sbyte requireFiveElements = (base.IsDirect ? FiveElementsType.Produced[srcFiveElementsType] : FiveElementsType.Countered[srcFiveElementsType]);
		int viewRange = DomainManager.Map.GetTaiwuViewRange(block);
		DomainManager.Map.GetNeighborBlocks(location.AreaId, location.BlockId, viewRangeBlocks, viewRange);
		viewRangeBlocks.Add(block);
		for (int i = 0; i < viewRangeBlocks.Count; i++)
		{
			HashSet<int> graveSet = viewRangeBlocks[i].GraveSet;
			if (graveSet == null)
			{
				continue;
			}
			foreach (int deadCharId in graveSet)
			{
				sbyte birthMonth = CharacterDomain.CalcBirthYearAndMonth(DomainManager.Character.GetDeadCharacter(deadCharId).BirthDate).month;
				if (GameData.Domains.Character.SharedMethods.GetInnateFiveElementsType(birthMonth) == requireFiveElements)
				{
					PowerUpValue += 10;
				}
			}
		}
		ObjectPool<List<MapBlockData>>.Instance.Return(viewRangeBlocks);
	}
}
