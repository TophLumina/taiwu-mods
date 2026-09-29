using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.World;

public static class XiangshuAvatarIds
{
	public const sbyte Monv = 0;

	public const sbyte DayueYaochang = 1;

	public const sbyte Jiuhan = 2;

	public const sbyte JinHuanger = 3;

	public const sbyte YiYihou = 4;

	public const sbyte WeiQi = 5;

	public const sbyte Yixiang = 6;

	public const sbyte Xuefeng = 7;

	public const sbyte ShuFang = 8;

	public const int Count = 9;

	public const int TombsCount = 7;

	public static short[] JuniorXiangshuTemplateIds = new short[9] { 201, 202, 203, 204, 205, 206, 207, 208, 209 };

	public static short[] XiangshuPuppetTemplateIds = new short[9] { 219, 220, 221, 222, 223, 224, 225, 226, 227 };

	public static short[] XiangshuBossBeginIds = new short[9] { 39, 48, 57, 66, 75, 84, 93, 102, 111 };

	public static short[] XiangshuBossEndIds = new short[9] { 47, 56, 65, 74, 83, 92, 101, 110, 119 };

	public static short[] WeakenedXiangshuBossBeginIds = new short[9] { 120, 129, 138, 147, 156, 165, 174, 183, 192 };

	public static readonly short[] WeakenedXiangshuBossEndIds = new short[9] { 128, 137, 146, 155, 164, 173, 182, 191, 200 };

	public static readonly short[] SwordTombBlockTemplateIds = new short[9] { 128, 129, 130, 131, 132, 133, 134, 135, 136 };

	public static string GetJuniorXiangshuAvatarName(sbyte xiangshuAvatarId)
	{
		short templateId = JuniorXiangshuTemplateIds[xiangshuAvatarId];
		return Config.Character.Instance[templateId].FixedAvatarName;
	}

	public static string GetXiangshuPuppetAvatarName(short templateId)
	{
		return Config.Character.Instance[templateId].FixedAvatarName;
	}

	public static string GetPuppetAvatarName(short templateId)
	{
		foreach (PuppetItem config in (IEnumerable<PuppetItem>)Puppet.Instance)
		{
			for (int i = 0; i < config.Difficulties.Count; i++)
			{
				if (config.CharacterId + i == templateId)
				{
					return config.Avatar;
				}
			}
		}
		return Config.Character.Instance[templateId].FixedAvatarName;
	}

	public static short GetCurrentLevelXiangshuTemplateId(sbyte xiangshuAvatarId, sbyte xiangshuLevel, bool isWeakened = false)
	{
		short beginTemplateId = (isWeakened ? WeakenedXiangshuBossBeginIds[xiangshuAvatarId] : XiangshuBossBeginIds[xiangshuAvatarId]);
		short endTemplateId = (isWeakened ? WeakenedXiangshuBossEndIds[xiangshuAvatarId] : XiangshuBossEndIds[xiangshuAvatarId]);
		return MathUtils.Clamp((short)(beginTemplateId + xiangshuLevel), beginTemplateId, endTemplateId);
	}

	public static sbyte GetXiangshuAvatarIdByCharacterTemplateId(short characterTemplateId)
	{
		for (sbyte avatarId = 0; avatarId < 9; avatarId++)
		{
			if (characterTemplateId == JuniorXiangshuTemplateIds[avatarId])
			{
				return avatarId;
			}
			if (characterTemplateId >= XiangshuBossBeginIds[avatarId] && characterTemplateId <= XiangshuBossEndIds[avatarId])
			{
				return avatarId;
			}
			if (characterTemplateId >= WeakenedXiangshuBossBeginIds[avatarId] && characterTemplateId <= WeakenedXiangshuBossEndIds[avatarId])
			{
				return avatarId;
			}
			if (SwordTomb.Instance[avatarId].ImmortalXiangshuAvatar == characterTemplateId)
			{
				return avatarId;
			}
		}
		return -1;
	}

	public static bool IsWeakenedXiangshuAvatar(short characterTemplateId)
	{
		for (sbyte avatarId = 0; avatarId < 9; avatarId++)
		{
			if (characterTemplateId >= WeakenedXiangshuBossBeginIds[avatarId] && characterTemplateId <= WeakenedXiangshuBossEndIds[avatarId])
			{
				return true;
			}
			if (characterTemplateId == SwordTomb.Instance[avatarId].ImmortalXiangshuAvatar)
			{
				return true;
			}
		}
		return false;
	}

	public static sbyte GetXiangshuAvatarIdBySwordTomb(int coreId)
	{
		foreach (SwordTombItem cfg in (IEnumerable<SwordTombItem>)SwordTomb.Instance)
		{
			if (cfg.AdventureCoreId == coreId)
			{
				return cfg.TemplateId;
			}
		}
		return -1;
	}

	public static bool IsSwordTombAdventure(int coreId)
	{
		return GetXiangshuAvatarIdBySwordTomb(coreId) >= 0;
	}
}
