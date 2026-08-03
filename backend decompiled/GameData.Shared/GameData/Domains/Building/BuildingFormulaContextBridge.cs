using System.Collections.Generic;
using Config;
using Config.Common;
using GameData.Serializer;

namespace GameData.Domains.Building;

/// <summary>
/// 产业公式与数据上下文的桥接，可用于自动获取公式参数进行计算.
/// </summary>
[SerializableGameData(NotForArchive = true)]
public class BuildingFormulaContextBridge : ISerializableGameData, IFormulaContextBridge<EBuildingFormulaArgType>
{
	/// <summary>
	/// 计算参数
	/// </summary>
	public delegate int CalcArgument(BuildingBlockKey blockKey, EBuildingFormulaArgType argType);

	private BuildingBlockKey _blockKey;

	private Dictionary<EBuildingFormulaArgType, int> _argValues;

	private CalcArgument _calcArg;

	public BuildingBlockKey BlockKey => _blockKey;

	/// <summary>
	/// 初始化，设置当前正在计算的建筑的参数缓存.
	/// 只有后端需要调用, 前端数据通过后端直接序列化得到.
	/// </summary>
	/// <param name="blockKey"></param>
	/// <param name="configData">配置数据</param>
	/// <param name="calcArgHandler">参数计算方法</param>
	/// <param name="cacheAllArgs">是否直接缓存所有的参数</param>
	public void Initialize(BuildingBlockKey blockKey, BuildingBlockItem configData, CalcArgument calcArgHandler, bool cacheAllArgs = false)
	{
		if (_argValues == null)
		{
			_argValues = new Dictionary<EBuildingFormulaArgType, int>();
		}
		_argValues.Clear();
		_blockKey = blockKey;
		_calcArg = calcArgHandler;
		if (!cacheAllArgs)
		{
			return;
		}
		List<short> expandInfos = configData.ExpandInfos;
		if (expandInfos == null || expandInfos.Count <= 0)
		{
			return;
		}
		foreach (short buildingScaleId in configData.ExpandInfos)
		{
			BuildingScaleItem scaleCfg = BuildingScale.Instance[buildingScaleId];
			if (scaleCfg.Formula < 0)
			{
				continue;
			}
			BuildingFormulaItem formulaCfg = BuildingFormula.Instance[scaleCfg.Formula];
			EBuildingFormulaArgType[] arguments = formulaCfg.Arguments;
			if (arguments != null && arguments.Length > 0)
			{
				arguments = formulaCfg.Arguments;
				foreach (EBuildingFormulaArgType arg in arguments)
				{
					GetArgument(arg);
				}
			}
		}
	}

	/// <inheritdoc />
	public int GetArgument(EBuildingFormulaArgType argType)
	{
		if (_argValues.TryGetValue(argType, out var value))
		{
			return value;
		}
		value = _calcArg?.Invoke(_blockKey, argType) ?? 0;
		_argValues.Add(argType, value);
		return value;
	}

	/// <inheritdoc />
	public bool IsSerializedSizeFixed()
	{
		return false;
	}

	/// <inheritdoc />
	public int GetSerializedSize()
	{
		int totalSize = 8 + SerializationHelper.DictionaryOfBasicTypePair.GetSerializedSize(_argValues);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Serialize(byte* pData)
	{
		*(ulong*)pData = (ulong)_blockKey;
		byte* num = pData + 8;
		int totalSize = (int)(num + SerializationHelper.DictionaryOfBasicTypePair.Serialize(num, ref _argValues) - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}

	/// <inheritdoc />
	public unsafe int Deserialize(byte* pData)
	{
		byte* pCurrData = pData;
		_blockKey = (BuildingBlockKey)(*(ulong*)pCurrData);
		pCurrData += 8;
		pCurrData += SerializationHelper.DictionaryOfBasicTypePair.Deserialize(pCurrData, ref _argValues);
		int totalSize = (int)(pCurrData - pData);
		if (totalSize > 4)
		{
			return (totalSize + 3) / 4 * 4;
		}
		return totalSize;
	}
}
