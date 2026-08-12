using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GameData.Common;
using GameData.Domains;
using NLog;

namespace GameData.Dependencies;

public static class DataDependenciesInfo
{
	private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

	private const string DomainNameSuffix = "Domain";

	private const string CalcMethodPrefix = "Calc";

	private const string CacheInfluencesFieldPrefix = "CacheInfluences";

	private const int InfluenceMaxDepth = 16;

	private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

	private static readonly Assembly SharedAssembly = typeof(ExternalDataBridge).Assembly;

	private static readonly Type BaseDomainType = typeof(BaseGameDataDomain);

	private static readonly Type DomainDataAttrType = typeof(DomainDataAttribute);

	private static readonly Type CollectionObjectFieldAttrType = typeof(CollectionObjectFieldAttribute);

	private static readonly Type DependencyAttrType = typeof(BaseDataDependencyAttribute);

	public static void Generate()
	{
		Dictionary<DataUidWithType, List<DataDependency>> dependencies = GetDependencies();
		Dictionary<DataUidWithType, HashSet<DataInfluence>> shallowInfluences = CalcShallowInfluences(dependencies);
		Dictionary<DataIndicator, DataInfluence[][]> indicator2FieldId2Influences = AssignInfluences(shallowInfluences);
	}

	private static Dictionary<DataUidWithType, List<DataDependency>> GetDependencies()
	{
		Dictionary<DataUidWithType, List<DataDependency>> dependencies = new Dictionary<DataUidWithType, List<DataDependency>>();
		Type[] types = Assembly.GetTypes();
		foreach (Type type in types)
		{
			if (type.IsSubclassOf(BaseDomainType))
			{
				GetDomainDataDependencies(type, dependencies);
			}
		}
		return dependencies;
	}

	private static void GetDomainDataDependencies(Type domainType, Dictionary<DataUidWithType, List<DataDependency>> dependencies)
	{
		string domainName = GetDomainName(domainType);
		ushort domainId = DomainHelper.DomainName2DomainId[domainName];
		string helperTypeName = domainType.Namespace + "." + domainName + "DomainHelper";
		Type helperType = SharedAssembly.GetType(helperTypeName);
		Dictionary<string, ushort> fieldName2DataId = GetStaticFieldValue<Dictionary<string, ushort>>(helperType, "FieldName2DataId");
		FieldInfo[] fields = domainType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			object[] fieldAttributes = fieldInfo.GetCustomAttributes(DomainDataAttrType, inherit: false);
			if (fieldAttributes.Length != 0)
			{
				DomainDataAttribute fieldAttr = (DomainDataAttribute)fieldAttributes[0];
				if (fieldAttr.IsCache)
				{
					string fieldPublicName = ToPublicName(fieldInfo.Name);
					ushort dataId = fieldName2DataId[fieldPublicName];
					DataUid targetUid = new DataUid(domainId, dataId, ulong.MaxValue);
					DataUidWithType targetUidWithType = new DataUidWithType(DomainDataType.SingleValue, targetUid);
					List<DataDependency> fieldDependencies = GetCacheFieldDependencies(domainType, fieldPublicName);
					dependencies.Add(targetUidWithType, fieldDependencies);
				}
				else if (fieldAttr.DomainDataType == DomainDataType.ObjectCollection)
				{
					string fieldPublicName2 = ToPublicName(fieldInfo.Name);
					ushort dataId2 = fieldName2DataId[fieldPublicName2];
					Type elementType = GetObjectCollectionElementType(fieldInfo.FieldType);
					GetCollectionObjectFieldsDependencies(domainId, dataId2, elementType, dependencies);
				}
			}
		}
	}

	private static void GetCollectionObjectFieldsDependencies(ushort domainId, ushort dataId, Type objectType, Dictionary<DataUidWithType, List<DataDependency>> dependencies)
	{
		string helperTypeName = objectType.Namespace + "." + objectType.Name + "Helper";
		Type helperType = SharedAssembly.GetType(helperTypeName);
		Dictionary<string, ushort> fieldName2FieldId = GetStaticFieldValue<Dictionary<string, ushort>>(helperType, "FieldName2FieldId");
		FieldInfo[] fields = objectType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		foreach (FieldInfo fieldInfo in fields)
		{
			object[] fieldAttributes = fieldInfo.GetCustomAttributes(CollectionObjectFieldAttrType, inherit: false);
			if (fieldAttributes.Length != 0)
			{
				CollectionObjectFieldAttribute fieldAttr = (CollectionObjectFieldAttribute)fieldAttributes[0];
				if (fieldAttr.IsCache)
				{
					string fieldPublicName = ToPublicName(fieldInfo.Name);
					ushort fieldId = fieldName2FieldId[fieldPublicName];
					DataUid targetUid = new DataUid(domainId, dataId, 18446744073709551614uL, fieldId);
					DataUidWithType targetUidWithType = new DataUidWithType(DomainDataType.ObjectCollection, targetUid);
					List<DataDependency> fieldDependencies = GetCacheFieldDependencies(objectType, fieldPublicName);
					dependencies.Add(targetUidWithType, fieldDependencies);
				}
			}
		}
	}

	private static List<DataDependency> GetCacheFieldDependencies(Type classType, string fieldPublicName)
	{
		string methodName = "Calc" + fieldPublicName;
		MethodInfo methodInfo = classType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
		if (methodInfo == null)
		{
			throw new Exception("Failed to get method " + classType.FullName + "." + methodName);
		}
		object[] dependencyAttributes = methodInfo.GetCustomAttributes(DependencyAttrType, inherit: false);
		if (dependencyAttributes.Length == 0)
		{
			throw new Exception("Calc-method of cache field must be annotated with derived class of BaseDataDependencyAttribute: " + classType.FullName + "." + methodName);
		}
		List<DataDependency> dependencies = new List<DataDependency>();
		object[] array = dependencyAttributes;
		for (int i = 0; i < array.Length; i++)
		{
			BaseDataDependencyAttribute attr = (BaseDataDependencyAttribute)array[i];
			if (attr.SourceUids.Length == 0)
			{
				throw new Exception($"You have to set at least one DataUid in one dependency ({attr}): {classType.FullName}.{methodName}");
			}
			dependencies.Add(new DataDependency(attr.SourceType, attr.SourceUids, attr.Condition, attr.Scope));
		}
		return dependencies;
	}

	private static Dictionary<DataUidWithType, HashSet<DataInfluence>> CalcShallowInfluences(Dictionary<DataUidWithType, List<DataDependency>> dependencies)
	{
		Dictionary<DataUidWithType, HashSet<DataInfluence>> influences = new Dictionary<DataUidWithType, HashSet<DataInfluence>>();
		DataInfluence templateInfluence = new DataInfluence(default(DataIndicator), InfluenceCondition.None, InfluenceScope.All);
		foreach (KeyValuePair<DataUidWithType, List<DataDependency>> entry in dependencies)
		{
			DataUidWithType targetUidWithType = entry.Key;
			List<DataDependency> currDependencies = entry.Value;
			DataIndicator targetIndicator = (templateInfluence.TargetIndicator = new DataIndicator(targetUidWithType.Type, targetUidWithType.DataUid.DomainId, targetUidWithType.DataUid.DataId));
			foreach (DataDependency currDependency in currDependencies)
			{
				templateInfluence.Condition = currDependency.Condition;
				templateInfluence.Scope = currDependency.Scope;
				DataUid[] sourceUids = currDependency.SourceUids;
				foreach (DataUid sourceUid in sourceUids)
				{
					DataUidWithType sourceUidWithType = new DataUidWithType(currDependency.SourceType, sourceUid);
					if (!influences.TryGetValue(sourceUidWithType, out var currInfluences))
					{
						currInfluences = new HashSet<DataInfluence>();
						influences.Add(sourceUidWithType, currInfluences);
					}
					if (!currInfluences.TryGetValue(templateInfluence, out var currInfluence))
					{
						currInfluence = new DataInfluence(targetIndicator, currDependency.Condition, currDependency.Scope);
						currInfluences.Add(currInfluence);
					}
					currInfluence.TargetUids.Add(targetUidWithType.DataUid);
				}
			}
		}
		return influences;
	}

	private static Dictionary<DataIndicator, DataInfluence[][]> AssignInfluences(Dictionary<DataUidWithType, HashSet<DataInfluence>> influences)
	{
		Dictionary<DataIndicator, DataInfluence[][]> indicator2FieldId2Influences = new Dictionary<DataIndicator, DataInfluence[][]>();
		foreach (KeyValuePair<DataUidWithType, HashSet<DataInfluence>> entry in influences)
		{
			DataUidWithType sourceUidWithType = entry.Key;
			HashSet<DataInfluence> dataInfluences = entry.Value;
			DataIndicator sourceIndicator = new DataIndicator(sourceUidWithType.Type, sourceUidWithType.DataUid.DomainId, sourceUidWithType.DataUid.DataId);
			if (!indicator2FieldId2Influences.TryGetValue(sourceIndicator, out var fieldId2Influences))
			{
				switch (sourceIndicator.DataType)
				{
				case DomainDataType.SingleValue:
				case DomainDataType.SingleValueCollection:
					fieldId2Influences = GetCacheInfluencesOfDomain(sourceIndicator);
					break;
				case DomainDataType.ElementList:
					fieldId2Influences = GetCacheInfluencesOfElementList(sourceIndicator);
					break;
				default:
					fieldId2Influences = GetCacheInfluencesOfCollectionObject(sourceIndicator);
					break;
				}
				indicator2FieldId2Influences.Add(sourceIndicator, fieldId2Influences);
			}
			DataInfluence[] influenceArray = HashSetToArray(dataInfluences);
			switch (sourceIndicator.DataType)
			{
			case DomainDataType.SingleValue:
			case DomainDataType.SingleValueCollection:
				fieldId2Influences[sourceUidWithType.DataUid.DataId] = influenceArray;
				break;
			case DomainDataType.ElementList:
				fieldId2Influences[(uint)sourceUidWithType.DataUid.SubId0] = influenceArray;
				break;
			default:
				fieldId2Influences[sourceUidWithType.DataUid.SubId1] = influenceArray;
				break;
			}
		}
		return indicator2FieldId2Influences;
	}

	private static DataInfluence[][] GetCacheInfluencesOfDomain(DataIndicator indicator)
	{
		BaseGameDataDomain domainInstance = DomainManager.Domains[indicator.DomainId];
		Type domainType = domainInstance.GetType();
		FieldInfo fieldInfo = domainType.GetField("CacheInfluences", BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic);
		if (fieldInfo == null)
		{
			throw new Exception("Cannot find field CacheInfluences on class " + domainType.FullName);
		}
		return (DataInfluence[][])fieldInfo.GetValue(null);
	}

	private static DataInfluence[][] GetCacheInfluencesOfElementList(DataIndicator indicator)
	{
		BaseGameDataDomain domainInstance = DomainManager.Domains[indicator.DomainId];
		Type domainType = domainInstance.GetType();
		string dataFieldName = DomainHelper.DomainId2DataId2FieldName[indicator.DomainId][indicator.DataId];
		string fieldName = "CacheInfluences" + dataFieldName;
		FieldInfo fieldInfo = domainType.GetField(fieldName, BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic);
		if (fieldInfo == null)
		{
			throw new Exception("Cannot find field " + fieldName + " on class " + domainType.FullName);
		}
		return (DataInfluence[][])fieldInfo.GetValue(null);
	}

	private static DataInfluence[][] GetCacheInfluencesOfCollectionObject(DataIndicator indicator)
	{
		BaseGameDataDomain domainInstance = DomainManager.Domains[indicator.DomainId];
		Type domainType = domainInstance.GetType();
		string dataFieldName = DomainHelper.DomainId2DataId2FieldName[indicator.DomainId][indicator.DataId];
		string fieldName = "CacheInfluences" + dataFieldName;
		FieldInfo fieldInfo = domainType.GetField(fieldName, BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.NonPublic);
		if (fieldInfo == null)
		{
			throw new Exception("Cannot find field " + fieldName + " on class " + domainType.FullName);
		}
		return (DataInfluence[][])fieldInfo.GetValue(null);
	}

	private static Dictionary<DataUid, HashSet<DataUid>> CalcDeepInfluences(Dictionary<DataUidWithType, List<DataDependency>> dependencies)
	{
		Dictionary<DataUid, HashSet<DataUid>> influences = new Dictionary<DataUid, HashSet<DataUid>>();
		foreach (KeyValuePair<DataUidWithType, List<DataDependency>> entry in dependencies)
		{
			DataUid targetUid = entry.Key.DataUid;
			List<DataDependency> currDependencies = entry.Value;
			foreach (DataDependency currDependency in currDependencies)
			{
				DataUid[] sourceUids = currDependency.SourceUids;
				foreach (DataUid sourceUid in sourceUids)
				{
					if (!influences.TryGetValue(sourceUid, out var targetUids))
					{
						targetUids = new HashSet<DataUid>();
						influences.Add(sourceUid, targetUids);
					}
					targetUids.Add(targetUid);
				}
			}
		}
		foreach (KeyValuePair<DataUid, HashSet<DataUid>> entry2 in influences)
		{
			CalcDeeperInfluences(influences, entry2.Key, entry2.Value, entry2.Value, 0);
		}
		return influences;
	}

	private static void CalcDeeperInfluences(Dictionary<DataUid, HashSet<DataUid>> influences, DataUid sourceUid, HashSet<DataUid> targetUids, HashSet<DataUid> currTargetUids, int depth)
	{
		if (++depth > 16)
		{
			throw new Exception($"Encountered max depth of influence: {sourceUid}");
		}
		DataUid[] array = HashSetToArray(currTargetUids);
		foreach (DataUid currTargetUid in array)
		{
			if (influences.TryGetValue(currTargetUid, out var childTargetUids))
			{
				targetUids.UnionWith(childTargetUids);
				CalcDeeperInfluences(influences, sourceUid, targetUids, childTargetUids, depth);
			}
		}
	}

	private static void LogDependencies(Dictionary<DataUidWithType, List<DataDependency>> dependencies)
	{
		StringBuilder message = new StringBuilder();
		message.AppendLine("Dependencies:");
		foreach (KeyValuePair<DataUidWithType, List<DataDependency>> entry in dependencies)
		{
			DataUid sourceUid = entry.Key.DataUid;
			List<DataDependency> currDependencies = entry.Value;
			StringBuilder stringBuilder = message;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, stringBuilder);
			handler.AppendLiteral("  ");
			handler.AppendFormatted(sourceUid.ToString());
			handler.AppendLiteral(":");
			stringBuilder2.AppendLine(ref handler);
			foreach (DataDependency dependency in currDependencies)
			{
				stringBuilder = message;
				StringBuilder stringBuilder3 = stringBuilder;
				handler = new StringBuilder.AppendInterpolatedStringHandler(4, 1, stringBuilder);
				handler.AppendLiteral("    ");
				handler.AppendFormatted(dependency);
				stringBuilder3.AppendLine(ref handler);
			}
		}
		Logger.Debug(message.ToString());
	}

	private static void LogDeepInfluences(Dictionary<DataUid, HashSet<DataUid>> influences)
	{
		StringBuilder message = new StringBuilder();
		message.AppendLine("Deep influences:");
		foreach (KeyValuePair<DataUid, HashSet<DataUid>> entry in influences)
		{
			DataUid sourceUid = entry.Key;
			HashSet<DataUid> targetUids = entry.Value;
			StringBuilder stringBuilder = message;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, stringBuilder);
			handler.AppendLiteral("  ");
			handler.AppendFormatted(sourceUid.ToString());
			handler.AppendLiteral(":");
			stringBuilder2.AppendLine(ref handler);
			foreach (DataUid targetUid in targetUids)
			{
				stringBuilder = message;
				StringBuilder stringBuilder3 = stringBuilder;
				handler = new StringBuilder.AppendInterpolatedStringHandler(4, 1, stringBuilder);
				handler.AppendLiteral("    ");
				handler.AppendFormatted(targetUid.ToString());
				stringBuilder3.AppendLine(ref handler);
			}
		}
		Logger.Debug(message.ToString());
	}

	private static void LogInfluences(Dictionary<DataIndicator, DataInfluence[][]> indicator2FieldId2Influences)
	{
		StringBuilder message = new StringBuilder();
		message.AppendLine("Influences:");
		foreach (KeyValuePair<DataIndicator, DataInfluence[][]> entry in indicator2FieldId2Influences)
		{
			DataIndicator indicator = entry.Key;
			DataInfluence[][] fieldId2Influences = entry.Value;
			StringBuilder stringBuilder = message;
			StringBuilder stringBuilder2 = stringBuilder;
			StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(3, 1, stringBuilder);
			handler.AppendLiteral("  ");
			handler.AppendFormatted(indicator.ToString());
			handler.AppendLiteral(":");
			stringBuilder2.AppendLine(ref handler);
			switch (indicator.DataType)
			{
			case DomainDataType.SingleValue:
			case DomainDataType.SingleValueCollection:
			{
				DataInfluence[] influences = fieldId2Influences[indicator.DataId];
				if (influences != null)
				{
					string dataName = DomainHelper.DomainId2DataId2FieldName[indicator.DomainId][indicator.DataId];
					stringBuilder = message;
					StringBuilder stringBuilder3 = stringBuilder;
					handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder);
					handler.AppendLiteral("    ");
					handler.AppendFormatted(dataName);
					handler.AppendLiteral(":");
					stringBuilder3.AppendLine(ref handler);
					DataInfluence[] array = influences;
					foreach (DataInfluence influence in array)
					{
						stringBuilder = message;
						StringBuilder stringBuilder4 = stringBuilder;
						handler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder);
						handler.AppendLiteral("      ");
						handler.AppendFormatted(influence);
						stringBuilder4.AppendLine(ref handler);
					}
				}
				continue;
			}
			case DomainDataType.ElementList:
			{
				int fieldsCount = fieldId2Influences.Length;
				for (int fieldId = 0; fieldId < fieldsCount; fieldId++)
				{
					DataInfluence[] influences2 = fieldId2Influences[fieldId];
					if (influences2 != null)
					{
						stringBuilder = message;
						StringBuilder stringBuilder5 = stringBuilder;
						handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder);
						handler.AppendLiteral("    ");
						handler.AppendFormatted(fieldId.ToString());
						handler.AppendLiteral(":");
						stringBuilder5.AppendLine(ref handler);
						DataInfluence[] array2 = influences2;
						foreach (DataInfluence influence2 in array2)
						{
							stringBuilder = message;
							StringBuilder stringBuilder6 = stringBuilder;
							handler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder);
							handler.AppendLiteral("      ");
							handler.AppendFormatted(influence2);
							stringBuilder6.AppendLine(ref handler);
						}
					}
				}
				continue;
			}
			}
			string[] fieldId2FieldName = DomainHelper.DomainId2DataId2ObjectFieldId2FieldName[indicator.DomainId][indicator.DataId];
			int fieldsCount2 = fieldId2Influences.Length;
			for (int k = 0; k < fieldsCount2; k++)
			{
				DataInfluence[] influences3 = fieldId2Influences[k];
				if (influences3 != null)
				{
					string fieldName = fieldId2FieldName[k];
					stringBuilder = message;
					StringBuilder stringBuilder7 = stringBuilder;
					handler = new StringBuilder.AppendInterpolatedStringHandler(5, 1, stringBuilder);
					handler.AppendLiteral("    ");
					handler.AppendFormatted(fieldName);
					handler.AppendLiteral(":");
					stringBuilder7.AppendLine(ref handler);
					DataInfluence[] array3 = influences3;
					foreach (DataInfluence influence3 in array3)
					{
						stringBuilder = message;
						StringBuilder stringBuilder8 = stringBuilder;
						handler = new StringBuilder.AppendInterpolatedStringHandler(6, 1, stringBuilder);
						handler.AppendLiteral("      ");
						handler.AppendFormatted(influence3);
						stringBuilder8.AppendLine(ref handler);
					}
				}
			}
		}
		Logger.Debug(message.ToString());
	}

	private static T[] HashSetToArray<T>(HashSet<T> items)
	{
		int count = items.Count;
		T[] array = new T[count];
		int id = 0;
		foreach (T item in items)
		{
			array[id] = item;
			id++;
		}
		return array;
	}

	private static string GetDomainName(Type domainType)
	{
		string domainTypeShortName = domainType.Name;
		if (!domainTypeShortName.EndsWith("Domain"))
		{
			throw new Exception("Domain name must end with Domain: " + domainType.FullName);
		}
		return domainTypeShortName.Substring(0, domainTypeShortName.Length - "Domain".Length);
	}

	private static Type GetObjectCollectionElementType(Type collectionType)
	{
		Type interfaceType = collectionType.GetInterface("System.Collections.Generic.IDictionary`2");
		if (interfaceType == null)
		{
			throw new Exception("The specified type is not implement IDictionary interface: " + collectionType.FullName);
		}
		Type[] typeArguments = interfaceType.GetGenericArguments();
		return typeArguments[1];
	}

	private static T GetStaticFieldValue<T>(Type classType, string filedName)
	{
		FieldInfo fieldInfo = classType.GetField(filedName, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		if (fieldInfo == null)
		{
			throw new Exception("Failed to get field: " + classType.FullName + "." + filedName);
		}
		return (T)fieldInfo.GetValue(null);
	}

	public static string ToPublicName(string fieldName)
	{
		StringBuilder sb = new StringBuilder(fieldName);
		if (sb[0] == '_')
		{
			sb.Remove(0, 1);
		}
		sb[0] = char.ToUpper(sb[0]);
		return sb.ToString();
	}
}
