using System.Collections.Generic;
using Config;
using GameData.Utilities;

namespace GameData.Domains.World;

/// <summary>
/// 相枢化身 ID
/// </summary>
public static class XiangshuAvatarIds
{
	/// <summary>
	/// 莫女
	/// </summary>
	public const sbyte Monv = 0;

	/// <summary>
	/// 大岳瑶常
	/// </summary>
	public const sbyte DayueYaochang = 1;

	/// <summary>
	/// 九寒
	/// </summary>
	public const sbyte Jiuhan = 2;

	/// <summary>
	/// 金凰儿
	/// </summary>
	public const sbyte JinHuanger = 3;

	/// <summary>
	/// 衣以候
	/// </summary>
	public const sbyte YiYihou = 4;

	/// <summary>
	/// 卫起
	/// </summary>
	public const sbyte WeiQi = 5;

	/// <summary>
	/// 以向
	/// </summary>
	public const sbyte Yixiang = 6;

	/// <summary>
	/// 血枫
	/// </summary>
	public const sbyte Xuefeng = 7;

	/// <summary>
	/// 术方
	/// </summary>
	public const sbyte ShuFang = 8;

	/// <summary>
	/// 相枢化身的数量
	/// </summary>
	public const int Count = 9;

	/// <summary>
	/// 有剑冢的相枢化身的数量
	/// </summary>
	public const int TombsCount = 7;

	/// <summary>
	/// 小相枢紫竹化身的模板ID
	/// </summary>
	public static short[] JuniorXiangshuTemplateIds = new short[9] { 201, 202, 203, 204, 205, 206, 207, 208, 209 };

	/// <summary>
	/// 相枢木人的模板ID
	/// </summary>
	public static short[] XiangshuPuppetTemplateIds = new short[9] { 219, 220, 221, 222, 223, 224, 225, 226, 227 };

	/// <summary>
	/// 用于战斗中使用的相枢化身起始模板ID，实际使用时为 起始模板ID + 相枢进度
	/// </summary>
	public static short[] XiangshuBossBeginIds = new short[9] { 39, 48, 57, 66, 75, 84, 93, 102, 111 };

	/// <summary>
	/// 用于战斗中使用的相枢化身终止模板ID，实际使用时代表 起始模板ID + 相枢进度 的上限值。
	/// </summary>
	public static short[] XiangshuBossEndIds = new short[9] { 47, 56, 65, 74, 83, 92, 101, 110, 119 };

	/// <summary>
	/// 用于战斗中使用的相枢化身起始模板ID，实际使用时为 起始模板ID + 相枢进度
	/// </summary>
	public static short[] WeakenedXiangshuBossBeginIds = new short[9] { 120, 129, 138, 147, 156, 165, 174, 183, 192 };

	/// <summary>
	/// 用于战斗中使用的相枢化身终止模板ID，实际使用时代表 起始模板ID + 相枢进度 的上限值。
	/// </summary>
	public static readonly short[] WeakenedXiangshuBossEndIds = new short[9] { 128, 137, 146, 155, 164, 173, 182, 191, 200 };

	/// <summary>
	/// 相枢化身对应的剑冢地块模板 ID
	/// </summary>
	public static readonly short[] SwordTombBlockTemplateIds = new short[9] { 128, 129, 130, 131, 132, 133, 134, 135, 136 };

	/// <summary>
	/// 根据化身ID获取紫竹化身的头像
	/// </summary>
	/// <param name="xiangshuAvatarId"></param>
	/// <returns></returns>
	public static string GetJuniorXiangshuAvatarName(sbyte xiangshuAvatarId)
	{
		short templateId = JuniorXiangshuTemplateIds[xiangshuAvatarId];
		return Config.Character.Instance[templateId].FixedAvatarName;
	}

	/// <summary>
	/// 根据化身ID获取相枢木人的头像
	/// </summary>
	/// <returns></returns>
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

	/// <summary>
	/// 根据当前侵袭进度获得对应相枢的角色模板ID.该方法依赖于Character表中相枢数据的配置的顺序。<see cref="T:Config.Character.DefKey" />
	/// </summary>
	/// <param name="xiangshuAvatarId">相枢化身 ID</param>
	/// <param name="xiangshuLevel">世界侵袭等级</param>
	/// <param name="isWeakened">是否为削弱后的出冢Boss</param>
	/// <returns></returns>
	public static short GetCurrentLevelXiangshuTemplateId(sbyte xiangshuAvatarId, sbyte xiangshuLevel, bool isWeakened = false)
	{
		short beginTemplateId = (isWeakened ? WeakenedXiangshuBossBeginIds[xiangshuAvatarId] : XiangshuBossBeginIds[xiangshuAvatarId]);
		short endTemplateId = (isWeakened ? WeakenedXiangshuBossEndIds[xiangshuAvatarId] : XiangshuBossEndIds[xiangshuAvatarId]);
		return MathUtils.Clamp((short)(beginTemplateId + xiangshuLevel), beginTemplateId, endTemplateId);
	}

	/// <summary>
	/// 根据角色的模板ID来获取其对应的相枢化身ID
	/// </summary>
	/// <param name="characterTemplateId">化身的角色模板ID</param>
	/// <returns><see cref="T:GameData.Domains.World.XiangshuAvatarIds" /></returns>
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

	/// <summary>
	/// 人物模板为出冢化身
	/// </summary>
	/// <param name="characterTemplateId"></param>
	/// <returns></returns>
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

	/// <summary>
	/// 根据剑冢奇遇的模板 ID 获取对应的相枢化身 ID
	/// </summary>
	/// <returns><see cref="T:GameData.Domains.World.XiangshuAvatarIds" /></returns>
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

	/// <summary>
	/// 指定奇遇是否为剑冢奇遇
	/// </summary>
	public static bool IsSwordTombAdventure(int coreId)
	{
		return GetXiangshuAvatarIdBySwordTomb(coreId) >= 0;
	}
}
