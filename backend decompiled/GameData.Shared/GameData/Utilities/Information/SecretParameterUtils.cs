using System;
using Config;
using GameData.Domains.Item;
using GameData.Domains.Map;

namespace GameData.Utilities.Information;

public static class SecretParameterUtils
{
	public unsafe static int ExtractSecretParameters(this byte[] data, SecretInformationItem secretTemplate, Action<int, int> onCharacter, Action<int, Location> onLocation, Action<int, sbyte> onResourceType, Action<int, ItemKey> onItemKey, Action<int, short> onCombatSkillTemplateId, Action<int, short> onLifeSkillTemplateId, Action<int, int> onIntegerValue)
	{
		sbyte[] parameters = secretTemplate.Parameters;
		fixed (byte* ptr = data)
		{
			return ExtractSecretParameters(ptr, parameters, onCharacter, onLocation, onResourceType, onItemKey, onCombatSkillTemplateId, onLifeSkillTemplateId, onIntegerValue);
		}
	}

	public unsafe static int ExtractSecretParameters(this byte[] data, SecretInformationItem secretTemplate, Action<int, int> onCharacter)
	{
		sbyte[] parameters = secretTemplate.Parameters;
		fixed (byte* ptr = data)
		{
			return ExtractSecretParameters(ptr, parameters, onCharacter);
		}
	}

	private unsafe static int ExtractSecretParameters(byte* pData, sbyte[] secretParameterTypes, Action<int, int> onCharacter, Action<int, Location> onLocation, Action<int, sbyte> onResourceType, Action<int, ItemKey> onItemKey, Action<int, short> onCombatSkillTemplateId, Action<int, short> onLifeSkillTemplateId, Action<int, int> onIntegerValue)
	{
		int i = 0;
		for (int len = secretParameterTypes.Length; i < len; i++)
		{
			switch (secretParameterTypes[i])
			{
			case 0:
			{
				int charId = *(int*)pData;
				pData += 4;
				onCharacter?.Invoke(i, charId);
				break;
			}
			case 1:
			{
				short areaId = *(short*)pData;
				pData += 2;
				short blockId = *(short*)pData;
				pData += 2;
				onLocation?.Invoke(i, new Location(areaId, blockId));
				break;
			}
			case 2:
			{
				sbyte resourceType = (sbyte)(*pData);
				pData++;
				onResourceType?.Invoke(i, resourceType);
				break;
			}
			case 3:
			{
				ItemKey itemKey = (ItemKey)(*(ulong*)pData);
				pData += 8;
				onItemKey?.Invoke(i, itemKey);
				break;
			}
			case 4:
			{
				short combatSkillTemplateId = *(short*)pData;
				pData += 2;
				onCombatSkillTemplateId?.Invoke(i, combatSkillTemplateId);
				break;
			}
			case 5:
			{
				short lifeSkillTemplateId = *(short*)pData;
				pData += 2;
				onLifeSkillTemplateId?.Invoke(i, lifeSkillTemplateId);
				break;
			}
			case 6:
			{
				int integerValue = *(int*)pData;
				pData += 4;
				onIntegerValue?.Invoke(i, integerValue);
				break;
			}
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		return i;
	}

	private unsafe static int ExtractSecretParameters(byte* pData, sbyte[] secretParameterTypes, Action<int, int> onCharacter)
	{
		int i = 0;
		for (int len = secretParameterTypes.Length; i < len; i++)
		{
			switch (secretParameterTypes[i])
			{
			case 0:
			{
				int charId = *(int*)pData;
				pData += 4;
				onCharacter(i, charId);
				break;
			}
			case 1:
				pData += 2;
				pData += 2;
				break;
			case 2:
				pData++;
				break;
			case 3:
				pData += 8;
				break;
			case 4:
			case 5:
				pData += 2;
				break;
			case 6:
				pData += 4;
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
		return i;
	}
}
