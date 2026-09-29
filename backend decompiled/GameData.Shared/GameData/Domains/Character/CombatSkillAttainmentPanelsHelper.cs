using System;
using GameData.Utilities;

namespace GameData.Domains.Character;

public static class CombatSkillAttainmentPanelsHelper
{
	private const int Size = 252;

	public unsafe static void Initialize(short[] panels)
	{
		fixed (short* pPanels = panels)
		{
			CollectionUtils.SetMemoryToMinusOne((byte*)pPanels, 252);
		}
	}

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

	public static short Get(short[] panels, sbyte combatSkillType, sbyte grade)
	{
		int offset = 9 * combatSkillType + grade;
		return panels[offset];
	}

	public static void Set(short[] panels, sbyte combatSkillType, sbyte grade, short combatSkillTemplateId)
	{
		int offset = 9 * combatSkillType + grade;
		panels[offset] = combatSkillTemplateId;
	}
}
