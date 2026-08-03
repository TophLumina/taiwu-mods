using GameData.Combat.Math;
using GameData.Common;
using GameData.Domains.Character;
using GameData.Domains.Character.Relation;
using GameData.Domains.CombatSkill;
using GameData.Domains.SpecialEffect.CombatSkill.Common.Attack;
using GameData.Utilities;

namespace GameData.Domains.SpecialEffect.CombatSkill.Xuannvpai.FistAndPalm;

public class YaoJiYunYuShi : PowerUpOnCast
{
	protected override EDataModifyType ModifyType => EDataModifyType.AddPercent;

	public YaoJiYunYuShi()
	{
	}

	public YaoJiYunYuShi(CombatSkillKey skillKey)
		: base(skillKey, 8105)
	{
	}

	public override void OnEnable(DataContext context)
	{
		GameData.Domains.Character.Character enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true).GetCharacter();
		GameData.Domains.Character.Character likeChar = (base.IsDirect ? enemyChar : CharObj);
		GameData.Domains.Character.Character charmChar = (base.IsDirect ? CharObj : enemyChar);
		if (enemyChar.GetCreatingType() == 1 && (likeChar.GetBisexual() || charmChar.GetAvatar().Gender == Gender.Flip(likeChar.GetGender())))
		{
			PowerUpValue = charmChar.GetAttraction() / 15;
		}
		base.OnEnable(context);
	}

	protected override void OnCastSelf(DataContext context, sbyte power, bool interrupted)
	{
		if (PowerMatchAffectRequire(power) && AllowAddAdore(base.CurrEnemyChar.GetId()))
		{
			GameData.Domains.Character.Character enemyChar = DomainManager.Combat.GetCombatCharacter(!base.CombatChar.IsAlly, tryGetCoverCharacter: true).GetCharacter();
			GameData.Domains.Character.Character likeChar = (base.IsDirect ? enemyChar : CharObj);
			GameData.Domains.Character.Character charmChar = (base.IsDirect ? CharObj : enemyChar);
			int rate = charmChar.GetAttraction() / 100;
			if (context.Random.CheckPercentProb(rate))
			{
				GameData.Domains.Character.Character.ApplyAddRelation_Adore(context, likeChar, charmChar, likeChar.GetBehaviorType(), targetLovesBack: false, selfIsTaiwuPeople: false, targetIsTaiwuPeople: false);
				ShowSpecialEffectTips(1);
			}
		}
	}

	private bool AllowAddAdore(int relatedCharId)
	{
		int charId = base.CharacterId;
		if (!DomainManager.Character.TryGetElement_Objects(relatedCharId, out var relatedChar))
		{
			return false;
		}
		if (relatedChar.GetAgeGroup() != 2 || relatedChar.GetCreatingType() != 1)
		{
			return false;
		}
		if (!DomainManager.Character.TryGetRelation(charId, relatedCharId, out var relation))
		{
			relation.RelationType = ushort.MaxValue;
		}
		if (relation.RelationType == ushort.MaxValue)
		{
			return true;
		}
		return !RelationType.HasRelation(relation.RelationType, 511);
	}
}
