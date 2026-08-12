using System.Collections.Generic;
using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.CombatSkill;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.XiangShu.Neigong.Boss;

public class WanXiangHeShu : BossNeigongBase
{
	private const sbyte AddDamagePercent = 30;

	private const sbyte ReduceDamagePercent = -15;

	private const sbyte ChangeInjuryOdds = 80;

	private static bool CanAffect => !DomainManager.Extra.IsProfessionalSkillUnlockedAndEquipped(51);

	public WanXiangHeShu()
	{
	}

	public WanXiangHeShu(CombatSkillKey skillKey)
		: base(skillKey, 16109)
	{
	}

	protected override void ActivePhase2Effect(DataContext context)
	{
		AppendAffectedData(context, base.CharacterId, 69, EDataModifyType.AddPercent, -1);
		AppendAffectedData(context, base.CharacterId, 102, EDataModifyType.AddPercent, -1);
	}

	public override int GetModifyValue(AffectedDataKey dataKey, int currModifyValue)
	{
		if (dataKey.CharId != base.CharacterId || !CanAffect)
		{
			return 0;
		}
		int damagePercent = 0;
		int samsaraCharId = base.CurrEnemyChar.GetId();
		List<short> featureIds = DomainManager.Character.GetElement_Objects(samsaraCharId).GetFeatureIds();
		int samsaraCount = (featureIds.Exists(GameData.Domains.Character.Character.IsReincarnationBonusFeature) ? 9 : DomainManager.Character.GetCharacterSamsaraData(samsaraCharId).DeadCharacters.Count);
		int randomCount = 9 - samsaraCount;
		DataContext context = DomainManager.Combat.Context;
		for (int i = 0; i < randomCount; i++)
		{
			if (context.Random.CheckPercentProb(80))
			{
				damagePercent += ((dataKey.FieldId == 69) ? 30 : (-15));
			}
		}
		if (featureIds.Exists(GameData.Domains.Character.Character.IsProfessionReincarnationBonusFeature))
		{
			damagePercent /= 2;
		}
		if (damagePercent != 0)
		{
			ShowSpecialEffectTips(dataKey.CharId == base.CharacterId, 2, 1);
		}
		return damagePercent;
	}
}
