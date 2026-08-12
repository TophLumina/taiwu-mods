using System;
using GameData.Utilities;

namespace GameData.Domains.Character;

/// <summary>
/// 武学造诣配置盘相关辅助方法
/// </summary>
public static class CombatSkillAttainmentPanelsHelper
{
	/// <summary>
	/// 武学造诣配置盘数据长度
	/// </summary>
	private const int Size = 252;

	/// <summary>
	/// 为武学造诣配置盘数据填充默认值
	/// </summary>
	/// <param name="panels"></param>
	public unsafe static void Initialize(short[] panels)
	{
		fixed (short* pPanels = panels)
		{
			CollectionUtils.SetMemoryToMinusOne((byte*)pPanels, 252);
		}
	}

	/// <summary>
	/// 复制全部武学造诣配置盘数据
	/// </summary>
	/// <param name="src"></param>
	/// <param name="dest"></param>
	public unsafe static void CopyAll(short[] src, short[] dest)
	{
		fixed (short* pSrc = src)
		{
			fixed (short* pDest = dest)
			{
				Buffer.MemoryCopy(pSrc, pDest, 252L, 252L);
			}
		}
	}

	/// <summary>
	/// 比较全部武学造诣配置盘数据
	/// </summary>
	/// <param name="lhs"></param>
	/// <param name="rhs"></param>
	/// <returns></returns>
	public unsafe static bool EqualAll(short[] lhs, short[] rhs)
	{
		fixed (short* pLhs = lhs)
		{
			fixed (short* pRhs = rhs)
			{
				return CollectionUtils.Equals((byte*)pLhs, (byte*)pRhs, 252);
			}
		}
	}

	/// <summary>
	/// 获取指定武学类型的配置盘
	/// </summary>
	/// <param name="panels"></param>
	/// <param name="combatSkillType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillType" /></param>
	/// <param name="pCombatSkillTemplateIds">
	/// 配置盘上的从最低阶阶到最高阶的功法模板 ID. 元素值小于 0 表示未配置功法.
	/// 由调用者申请的内存, 由此方法填充. 至少能容纳 Grade.Count 个功法模板 ID.
	/// </param>
	public unsafe static void GetPanel(short[] panels, sbyte combatSkillType, short* pCombatSkillTemplateIds)
	{
		fixed (short* pPanels = panels)
		{
			byte* pSrc = (byte*)pPanels + 18 * combatSkillType;
			*(long*)pCombatSkillTemplateIds = *(long*)pSrc;
			((long*)pCombatSkillTemplateIds)[1] = ((long*)pSrc)[1];
			pCombatSkillTemplateIds[8] = ((short*)pSrc)[8];
		}
	}

	/// <summary>
	/// 设置指定武学类型的配置盘
	/// </summary>
	/// <param name="panels"></param>
	/// <param name="combatSkillType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillType" /></param>
	/// <param name="pCombatSkillTemplateIds">配置盘上的从最低阶阶到最高阶的功法模板 ID. 元素值小于 0 表示未配置功法.</param>
	public unsafe static void SetPanel(short[] panels, sbyte combatSkillType, short* pCombatSkillTemplateIds)
	{
		fixed (short* pPanels = panels)
		{
			byte* num = (byte*)pPanels + 18 * combatSkillType;
			*(long*)num = *(long*)pCombatSkillTemplateIds;
			((long*)num)[1] = ((long*)pCombatSkillTemplateIds)[1];
			((short*)num)[8] = pCombatSkillTemplateIds[8];
		}
	}

	/// <summary>
	/// 获取指定武学类型的配置盘上的某一格
	/// </summary>
	/// <param name="panels"></param>
	/// <param name="combatSkillType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillType" /></param>
	/// <param name="grade"><see cref="T:GameData.Domains.Character.Grade" /></param>
	public static short Get(short[] panels, sbyte combatSkillType, sbyte grade)
	{
		int offset = 9 * combatSkillType + grade;
		return panels[offset];
	}

	/// <summary>
	/// 设置指定武学类型的配置盘上的某一格
	/// </summary>
	/// <param name="panels"></param>
	/// <param name="combatSkillType"><see cref="T:GameData.Domains.CombatSkill.CombatSkillType" /></param>
	/// <param name="grade"><see cref="T:GameData.Domains.Character.Grade" /></param>
	/// <param name="combatSkillTemplateId">为 -1 表示清空该格的设置</param>
	public static void Set(short[] panels, sbyte combatSkillType, sbyte grade, short combatSkillTemplateId)
	{
		int offset = 9 * combatSkillType + grade;
		panels[offset] = combatSkillTemplateId;
	}
}
