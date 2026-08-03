using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using MoonSharp.Interpreter;
using Newtonsoft.Json.Linq;

namespace GameData.Serializer;

public static class CommonObjectSerializer
{
	public enum MarshalFormat
	{
		Lua,
		LuaWithReturnPrefix,
		Json
	}

	private sealed class CodeWriter : TextWriter
	{
		private int _indentLevel;

		private bool _tabsPending;

		private readonly string _tabString;

		public override Encoding Encoding => InnerWriter.Encoding;

		public override string NewLine
		{
			get
			{
				return InnerWriter.NewLine;
			}
			set
			{
				InnerWriter.NewLine = value;
			}
		}

		public int Indent
		{
			get
			{
				return _indentLevel;
			}
			set
			{
				if (value < 0)
				{
					value = 0;
				}
				_indentLevel = value;
			}
		}

		private TextWriter InnerWriter { get; }

		public CodeWriter(TextWriter writer, string tabString = "\t")
			: base(CultureInfo.InvariantCulture)
		{
			InnerWriter = writer;
			_tabString = tabString;
			_indentLevel = 0;
			_tabsPending = false;
		}

		public override void Close()
		{
			InnerWriter.Close();
		}

		public override void Flush()
		{
			InnerWriter.Flush();
		}

		private void OutputTabs()
		{
			if (_tabsPending)
			{
				for (int index = 0; index < _indentLevel; index++)
				{
					InnerWriter.Write(_tabString);
				}
				_tabsPending = false;
			}
		}

		public override void Write(string s)
		{
			OutputTabs();
			InnerWriter.Write(s);
		}

		public override void Write(bool value)
		{
			OutputTabs();
			InnerWriter.Write(value);
		}

		public override void Write(char value)
		{
			OutputTabs();
			InnerWriter.Write(value);
		}

		public override void Write(char[] buffer)
		{
			OutputTabs();
			InnerWriter.Write(buffer);
		}

		public override void Write(char[] buffer, int index, int count)
		{
			OutputTabs();
			InnerWriter.Write(buffer, index, count);
		}

		public override void Write(double value)
		{
			OutputTabs();
			InnerWriter.Write(value);
		}

		public override void Write(float value)
		{
			OutputTabs();
			InnerWriter.Write(value);
		}

		public override void Write(int value)
		{
			OutputTabs();
			InnerWriter.Write(value);
		}

		public override void Write(long value)
		{
			OutputTabs();
			InnerWriter.Write(value);
		}

		public override void Write(object value)
		{
			OutputTabs();
			InnerWriter.Write(value);
		}

		public override void Write(string format, object arg0)
		{
			OutputTabs();
			InnerWriter.Write(format, arg0);
		}

		public override void Write(string format, object arg0, object arg1)
		{
			OutputTabs();
			InnerWriter.Write(format, arg0, arg1);
		}

		public override void Write(string format, params object[] arg)
		{
			OutputTabs();
			InnerWriter.Write(format, arg);
		}

		public override void WriteLine(string s)
		{
			OutputTabs();
			InnerWriter.WriteLine(s);
			_tabsPending = true;
		}

		public override void WriteLine()
		{
			OutputTabs();
			InnerWriter.WriteLine();
			_tabsPending = true;
		}

		public override void WriteLine(bool value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}

		public override void WriteLine(char value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}

		public override void WriteLine(char[] buffer)
		{
			OutputTabs();
			InnerWriter.WriteLine(buffer);
			_tabsPending = true;
		}

		public override void WriteLine(char[] buffer, int index, int count)
		{
			OutputTabs();
			InnerWriter.WriteLine(buffer, index, count);
			_tabsPending = true;
		}

		public override void WriteLine(double value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}

		public override void WriteLine(float value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}

		public override void WriteLine(int value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}

		public override void WriteLine(long value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}

		public override void WriteLine(object value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}

		public override void WriteLine(string format, object arg0)
		{
			OutputTabs();
			InnerWriter.WriteLine(format, arg0);
			_tabsPending = true;
		}

		public override void WriteLine(string format, object arg0, object arg1)
		{
			OutputTabs();
			InnerWriter.WriteLine(format, arg0, arg1);
			_tabsPending = true;
		}

		public override void WriteLine(string format, params object[] arg)
		{
			OutputTabs();
			InnerWriter.WriteLine(format, arg);
			_tabsPending = true;
		}

		[CLSCompliant(false)]
		public override void WriteLine(uint value)
		{
			OutputTabs();
			InnerWriter.WriteLine(value);
			_tabsPending = true;
		}
	}

	private static readonly ConcurrentDictionary<Type, Dictionary<string, MemberInfo>> CachedMemberDict = new ConcurrentDictionary<Type, Dictionary<string, MemberInfo>>();

	public static void Serialize(object obj, out string marshalData, MarshalFormat formatHint)
	{
		switch (formatHint)
		{
		case MarshalFormat.Lua:
			SerializeAsLuaString(obj, out marshalData, 0);
			break;
		case MarshalFormat.LuaWithReturnPrefix:
		{
			Serialize(obj, out var rawMarshalData, MarshalFormat.Lua);
			marshalData = "return " + rawMarshalData;
			break;
		}
		case MarshalFormat.Json:
			SerializeAsJsonString(obj, out marshalData, 0);
			break;
		default:
			throw new ArgumentOutOfRangeException("formatHint", formatHint, null);
		}
	}

	public static void Serialize<T>(T obj, out string marshalData, MarshalFormat formatHint)
	{
		Serialize((object)obj, out marshalData, formatHint);
	}

	public static void Deserialize<T>(string marshalData, out T obj, MarshalFormat formatHint)
	{
		Deserialize(marshalData, out var raw, typeof(T), formatHint);
		obj = (T)raw;
	}

	public static void Deserialize(string marshalData, out object obj, Type typeHint, MarshalFormat formatHint)
	{
		switch (formatHint)
		{
		case MarshalFormat.Lua:
			DeserializeFromLuaValue(LuaParser.Parse("return " + marshalData), out obj, typeHint);
			break;
		case MarshalFormat.LuaWithReturnPrefix:
			DeserializeFromLuaValue(LuaParser.Parse(marshalData), out obj, typeHint);
			break;
		case MarshalFormat.Json:
			DeserializeFromJsonValue(JToken.Parse(marshalData), out obj, typeHint);
			break;
		default:
			throw new ArgumentOutOfRangeException("formatHint", formatHint, null);
		}
	}

	public static void RestoreObjectArray<T>(string marshalData, T[] obj, MarshalFormat formatHint)
	{
		if ((uint)formatHint <= 1u)
		{
			Table luaTable = LuaParser.Parse((formatHint == MarshalFormat.Lua) ? ("return " + marshalData) : marshalData).Table;
			if (luaTable == null)
			{
				return;
			}
			for (int i = 0; i < obj.Length; i++)
			{
				if (obj[i] != null)
				{
					DeserializeFromLuaValue(luaTable.Get(DynValue.NewNumber(i)), out var raw, obj[i].GetType());
					obj[i] = (T)raw;
				}
			}
			return;
		}
		throw new ArgumentOutOfRangeException("formatHint", formatHint, null);
	}

	public static void RestoreObject<T>(string marshalData, T obj, MarshalFormat formatHint)
	{
		Deserialize<T>(marshalData, out var template, formatHint);
		Dictionary<string, CommonObjectSerializationMember> dict = new Dictionary<string, CommonObjectSerializationMember>();
		foreach (KeyValuePair<string, CommonObjectSerializationMember> member in GetMembers(template, deserializing: false))
		{
			dict[member.Key] = member.Value;
		}
		foreach (KeyValuePair<string, CommonObjectSerializationMember> member2 in GetMembers(obj, deserializing: true))
		{
			if (dict.TryGetValue(member2.Key, out var originMember))
			{
				member2.Value.Setter(originMember.Getter());
			}
		}
	}

	internal static string GetFileExtension(MarshalFormat formatHint)
	{
		switch (formatHint)
		{
		case MarshalFormat.Lua:
		case MarshalFormat.LuaWithReturnPrefix:
			return "lua";
		case MarshalFormat.Json:
			return "json";
		default:
			throw new ArgumentOutOfRangeException("formatHint", formatHint, null);
		}
	}

	private static IReadOnlyDictionary<string, MemberInfo> GetMemberDict(Type type)
	{
		if (CachedMemberDict.TryGetValue(type, out var memberDict))
		{
			return memberDict;
		}
		memberDict = new Dictionary<string, MemberInfo>();
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public);
		foreach (FieldInfo fieldInfo in fields)
		{
			memberDict[fieldInfo.Name] = fieldInfo;
		}
		PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (propertyInfo.CanWrite && propertyInfo.CanRead && propertyInfo.GetIndexParameters().Length == 0)
			{
				memberDict[propertyInfo.Name] = propertyInfo;
			}
		}
		CachedMemberDict.TryAdd(type, memberDict);
		return memberDict;
	}

	private static IEnumerable<KeyValuePair<string, CommonObjectSerializationMember>> GetMembers(object obj, bool deserializing)
	{
		Type skipMemberAttr = typeof(CommonObjectSkipMemberAttribute);
		foreach (var (name, member) in GetMemberDict(obj.GetType()))
		{
			if (member.IsDefined(skipMemberAttr) || (obj is ICommonObjectSerializationAware aware && aware.SkipMember(member, deserializing)))
			{
				continue;
			}
			FieldInfo fieldInfo = member as FieldInfo;
			KeyValuePair<string, CommonObjectSerializationMember> keyValuePair2;
			if ((object)fieldInfo == null)
			{
				PropertyInfo propertyInfo = member as PropertyInfo;
				if ((object)propertyInfo == null)
				{
					throw new InvalidCastException();
				}
				keyValuePair2 = new KeyValuePair<string, CommonObjectSerializationMember>(name, new CommonObjectSerializationMember(member.Name, () => propertyInfo.GetValue(obj), delegate(object v)
				{
					propertyInfo.SetValue(obj, v);
				}, propertyInfo.PropertyType, member));
			}
			else
			{
				keyValuePair2 = new KeyValuePair<string, CommonObjectSerializationMember>(name, new CommonObjectSerializationMember(member.Name, () => fieldInfo.GetValue(obj), delegate(object v)
				{
					fieldInfo.SetValue(obj, v);
				}, fieldInfo.FieldType, member));
			}
			yield return keyValuePair2;
		}
		if (!(obj is ICommonObjectSerializationAware aware2))
		{
			yield break;
		}
		foreach (CommonObjectSerializationMember extra in aware2.ExtraMembers(deserializing))
		{
			yield return new KeyValuePair<string, CommonObjectSerializationMember>(extra.Name, extra);
		}
	}

	private static void SerializeAsLuaString(object obj, out string luaString, int indent)
	{
		StringWriter sw = new StringWriter();
		CodeWriter code = new CodeWriter(sw);
		code.Indent = indent;
		if (obj != null)
		{
			if (!(obj is bool objBool))
			{
				if (!(obj is Enum objEnum))
				{
					if (!(obj is ICollection objCollection))
					{
						if (!(obj is string objString))
						{
							if (obj is IConvertible objConvertible)
							{
								code.Write(objConvertible.ToString(CultureInfo.InvariantCulture));
							}
							else
							{
								if (indent > 0)
								{
									code.WriteLine();
								}
								code.WriteLine('{');
								code.Indent++;
								int i = 0;
								foreach (KeyValuePair<string, CommonObjectSerializationMember> member in GetMembers(obj, deserializing: false))
								{
									member.Deconstruct(out var key, out var value);
									string name = key;
									CommonObjectSerializationMember commonObjectSerializationMember = value;
									if (i != 0)
									{
										code.WriteLine(',');
									}
									SerializeAsLuaString(commonObjectSerializationMember.Getter(), out var subData, code.Indent);
									code.Write(int.TryParse(name, out var index) ? $"[{index}] = " : (name + " = "));
									code.Write(subData);
									i++;
								}
								if (i != 0)
								{
									code.WriteLine();
								}
								code.Indent--;
								code.Write('}');
							}
						}
						else
						{
							code.Write('"');
							string key = objString;
							foreach (char c in key)
							{
								if (c < ' ')
								{
									switch (c)
									{
									case '\r':
										code.Write("\\r");
										continue;
									case '\n':
										code.Write("\\n");
										continue;
									case '\t':
										code.Write("\\t");
										continue;
									}
									code.Write("\\x");
									int num = c;
									code.Write(num.ToString("X2"));
								}
								else
								{
									switch (c)
									{
									case '\\':
										code.Write("\\\\");
										break;
									case '"':
										code.Write("\\\"");
										break;
									default:
										code.Write(c);
										break;
									}
								}
							}
							code.Write('"');
						}
					}
					else
					{
						if (indent > 0)
						{
							code.WriteLine();
						}
						code.WriteLine('{');
						code.Indent++;
						if (obj is IDictionary objDict)
						{
							int i2 = 0;
							foreach (object key2 in objDict.Keys)
							{
								SerializeAsLuaString(key2, out var keyData, code.Indent);
								SerializeAsLuaString(objDict[key2], out var valueData, code.Indent);
								code.Write("[" + keyData + "] = ");
								code.Write(valueData);
								code.WriteLine((i2 != objDict.Count - 1) ? ((object)',') : string.Empty);
								i2++;
							}
						}
						else
						{
							int i3 = 0;
							foreach (object item in objCollection)
							{
								SerializeAsLuaString(item, out var subData2, code.Indent);
								code.Write($"[{i3}] = ");
								code.Write(subData2);
								code.WriteLine((i3 != objCollection.Count - 1) ? ((object)',') : string.Empty);
								i3++;
							}
						}
						code.Indent--;
						code.Write('}');
					}
				}
				else
				{
					code.Write(Convert.ToInt32(objEnum));
				}
			}
			else
			{
				code.Write(objBool ? "true" : "false");
			}
		}
		else
		{
			code.Write("nil");
		}
		luaString = sw.ToString();
	}

	private static void SerializeAsJsonString(object obj, out string jsonString, int indent)
	{
		StringWriter sw = new StringWriter();
		CodeWriter code = new CodeWriter(sw);
		code.Indent = indent;
		if (obj != null)
		{
			if (!(obj is bool objBool))
			{
				if (!(obj is IDictionary objDict))
				{
					if (obj is Enum objEnum)
					{
						SerializeAsJsonString(objEnum.ToString(), out jsonString, indent);
						return;
					}
					if (!(obj is ICollection objCollection))
					{
						if (!(obj is string objString))
						{
							if (!(obj is IConvertible objConvertible))
							{
								if (obj is IEnumerable enumerable)
								{
									code.Write('[');
									code.Indent++;
									int i = 0;
									foreach (object item in enumerable)
									{
										code.Write((i != 0) ? ", " : string.Empty);
										SerializeAsJsonString(item, out var subData, code.Indent);
										code.Write(subData);
										i++;
									}
									code.Indent--;
									if (indent == 0)
									{
										code.WriteLine();
									}
									code.Write(']');
								}
								else
								{
									if (indent > 0)
									{
										code.WriteLine();
									}
									code.WriteLine('{');
									code.Indent++;
									int i2 = 0;
									foreach (var (obj2, member) in GetMembers(obj, deserializing: false))
									{
										if (i2 != 0)
										{
											code.WriteLine(',');
										}
										SerializeAsJsonString(obj2, out var keyData, code.Indent);
										SerializeAsJsonString(member.Getter(), out var subData2, code.Indent);
										code.Write(keyData + ": ");
										code.Write(subData2);
										i2++;
									}
									if (i2 != 0)
									{
										code.WriteLine();
									}
									code.Indent--;
									code.Write('}');
								}
							}
							else
							{
								code.Write(objConvertible.ToString(CultureInfo.InvariantCulture));
							}
						}
						else
						{
							code.Write('"');
							string text2 = objString;
							foreach (char c in text2)
							{
								switch (c)
								{
								case '"':
									code.Write("\\\"");
									continue;
								case '\\':
									code.Write("\\\\");
									continue;
								case '\b':
									code.Write("\\b");
									continue;
								case '\f':
									code.Write("\\f");
									continue;
								case '\n':
									code.Write("\\n");
									continue;
								case '\r':
									code.Write("\\r");
									continue;
								case '\t':
									code.Write("\\t");
									continue;
								}
								if (c < ' ')
								{
									code.Write($"\\u{(int)c:X4}");
								}
								else
								{
									code.Write(c);
								}
							}
							code.Write('"');
						}
					}
					else
					{
						code.Write('[');
						code.Indent++;
						int i3 = 0;
						foreach (object item2 in objCollection)
						{
							SerializeAsJsonString(item2, out var subData3, code.Indent);
							code.Write(subData3);
							code.Write((i3 != objCollection.Count - 1) ? ", " : string.Empty);
							i3++;
						}
						code.Indent--;
						if (indent == 0)
						{
							code.WriteLine();
						}
						code.Write(']');
					}
				}
				else
				{
					if (indent > 0)
					{
						code.WriteLine();
					}
					code.WriteLine('{');
					code.Indent++;
					int i4 = 0;
					foreach (object key in objDict.Keys)
					{
						SerializeAsJsonString(key, out var keyData2, code.Indent);
						SerializeAsJsonString(objDict[key], out var valueData, code.Indent);
						code.Write(keyData2 + ": ");
						code.Write(valueData);
						code.WriteLine((i4 != objDict.Count - 1) ? ((object)',') : string.Empty);
						i4++;
					}
					code.Indent--;
					code.Write('}');
				}
			}
			else
			{
				code.Write(objBool ? "true" : "false");
			}
		}
		else
		{
			code.Write("null");
		}
		jsonString = sw.ToString();
	}

	private static void DeserializeFromLuaValue(DynValue luaValue, out object obj, Type typeHint)
	{
		switch (luaValue.Type)
		{
		case DataType.Nil:
			obj = null;
			break;
		case DataType.Boolean:
			obj = ((IConvertible)luaValue.Boolean).ToType(typeHint, (IFormatProvider?)CultureInfo.InvariantCulture);
			break;
		case DataType.Number:
			obj = (typeHint.IsEnum ? SafeEnumValue((int)luaValue.Number, typeHint) : ((IConvertible)luaValue.Number).ToType(typeHint, (IFormatProvider?)CultureInfo.InvariantCulture));
			break;
		case DataType.String:
			obj = ((IConvertible)luaValue.String).ToType(typeHint, (IFormatProvider?)CultureInfo.InvariantCulture);
			break;
		case DataType.Table:
		{
			Table luaTable = luaValue.Table;
			if (typeHint.IsArray)
			{
				Type elementType = typeHint.GetElementType() ?? typeof(object);
				int size = luaTable.Keys.Select((DynValue k) => (int)k.Number).Prepend(-1).Max() + 1;
				Array objArray = Array.CreateInstance(elementType, size);
				bool noZeroIndex = false;
				int i = 0;
				for (int len = objArray.Length; i < len; i++)
				{
					DynValue key = luaTable.RawGet(DynValue.NewNumber(i));
					if (key == null && i == 0)
					{
						noZeroIndex = true;
						continue;
					}
					DeserializeFromLuaValue(key ?? DynValue.Nil, out var element, elementType);
					objArray.SetValue(element, i);
				}
				if (noZeroIndex && objArray.Length > 1)
				{
					Array sourceArray = objArray;
					objArray = Array.CreateInstance(elementType, size - 1);
					Array.Copy(sourceArray, 1, objArray, 0, objArray.Length);
				}
				obj = objArray;
				break;
			}
			if (typeof(ITuple).IsAssignableFrom(typeHint))
			{
				if (typeHint.IsGenericType && (typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<>) || typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<, >) || typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<, , >) || typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<, , , >) || typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<, , , , >) || typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<, , , , , >) || typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<, , , , , , >) || typeHint.GetGenericTypeDefinition() == typeof(ValueTuple<, , , , , , , >)))
				{
					ITuple tuple = (ITuple)Activator.CreateInstance(typeHint);
					Type[] types = typeHint.GetGenericArguments();
					int i2 = 0;
					for (int len2 = tuple.Length; i2 < len2; i2++)
					{
						int tableIndex = i2 + 1;
						string tableIndexName = $"Item{tableIndex}";
						DynValue v = luaTable.RawGet(DynValue.NewNumber(tableIndex)) ?? luaTable.RawGet(DynValue.NewString(tableIndexName));
						if (v != null)
						{
							DeserializeFromLuaValue(v, out var item, types[i2]);
							typeHint.GetField(tableIndexName)?.SetValue(tuple, item);
						}
					}
					obj = tuple;
					break;
				}
				throw new NotImplementedException($"{typeHint} is not supported");
			}
			if (typeof(IDictionary).IsAssignableFrom(typeHint))
			{
				Type keyType = typeHint.GetGenericArguments()[0];
				Type valueType = typeHint.GetGenericArguments()[1];
				IDictionary objDict = (IDictionary)Activator.CreateInstance(typeHint);
				foreach (DynValue key2 in luaTable.Keys)
				{
					DynValue value = luaTable.Get(key2);
					DeserializeFromLuaValue(key2, out var keyData, keyType);
					DeserializeFromLuaValue(value, out var valueData, (value.Type == DataType.Table && valueType == typeof(object)) ? typeof(Dictionary<object, object>) : valueType);
					objDict[keyData] = valueData;
				}
				obj = objDict;
				break;
			}
			if (typeof(IList).IsAssignableFrom(typeHint))
			{
				Type elementType2 = typeHint.GetElementType() ?? typeHint.GetGenericArguments()[0];
				int size2 = luaTable.Keys.Select((DynValue k) => (int)k.Number).Prepend(-1).Max() + 1;
				IList objList = (IList)Activator.CreateInstance(typeHint);
				for (int i3 = 0; i3 < size2; i3++)
				{
					DynValue key3 = luaTable.RawGet(DynValue.NewNumber(i3));
					if (key3 != null || i3 != 0)
					{
						DeserializeFromLuaValue(key3 ?? DynValue.Nil, out var element2, elementType2);
						objList.Add(element2);
					}
				}
				obj = objList;
				break;
			}
			obj = (typeHint.GetConstructors().Any((ConstructorInfo c) => c.GetParameters().Length == 0) ? Activator.CreateInstance(typeHint) : FormatterServices.GetUninitializedObject(typeHint));
			if (obj is ICommonObjectSerializationAware aware)
			{
				aware.InitializeOnDeserializing();
			}
			foreach (KeyValuePair<string, CommonObjectSerializationMember> member3 in GetMembers(obj, deserializing: true))
			{
				member3.Deconstruct(out var key4, out var value2);
				string name = key4;
				CommonObjectSerializationMember member = value2;
				DynValue value3 = luaTable.RawGet(name);
				if (value3 == null)
				{
					if (obj is ICommonObjectSerializationAware aware2)
					{
						aware2.DeserializingMissingField(member);
					}
				}
				else
				{
					DeserializeFromLuaValue(value3, out var prop, member.TypeHint);
					member.Setter(prop);
					luaTable.Remove(name);
				}
			}
			if (!(obj is ICommonObjectSerializationAware aware3))
			{
				break;
			}
			foreach (DynValue key5 in luaTable.Keys)
			{
				bool originalString = key5.Type == DataType.String;
				string name2 = (originalString ? key5.String : key5.CastToString());
				if (!aware3.DeserializingUnknownField(name2, out var member2))
				{
					continue;
				}
				DynValue value4 = luaTable.RawGet(originalString ? name2 : ((key5.ToObject() is IConvertible conv) ? ((IConvertible)name2).ToType(conv.GetType(), (IFormatProvider?)CultureInfo.InvariantCulture) : name2));
				if (value4 != null)
				{
					DeserializeFromLuaValue(value4, out var prop2, member2.TypeHint);
					if (aware3 is ICommonObjectDeserializationDirectValue deserializationDirectValue)
					{
						deserializationDirectValue.OnUnknownFieldGet(name2, prop2);
					}
					else
					{
						member2.Setter(prop2);
					}
				}
			}
			aware3.FinishedDeserialization();
			break;
		}
		case DataType.Tuple:
			DeserializeFromLuaValue(DynValue.NewTable(null, luaValue.Tuple), out obj, typeHint);
			break;
		default:
			throw new ArgumentOutOfRangeException("Type", luaValue.Type.ToString(), null);
		}
	}

	private static void DeserializeFromJsonValue(JToken jsonValue, out object obj, Type typeHint)
	{
		if (jsonValue != null)
		{
			if (!(jsonValue is JValue jValue))
			{
				if (!(jsonValue is JObject jObject))
				{
					if (jsonValue is JArray jArray)
					{
						if (typeHint.IsArray)
						{
							Type elementType = typeHint.GetElementType() ?? typeof(object);
							Array objArray = Array.CreateInstance(elementType, jArray.Count);
							int i = 0;
							for (int len = objArray.Length; i < len; i++)
							{
								DeserializeFromJsonValue(jArray[i], out var element, elementType);
								objArray.SetValue(element, i);
							}
							obj = objArray;
							return;
						}
						if (typeof(IList).IsAssignableFrom(typeHint))
						{
							Type collectionType = (typeHint.IsGenericType ? typeHint : typeHint.GetInterfaces().First((Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IList<>)));
							Type elementType2 = collectionType.GetElementType() ?? collectionType.GetGenericArguments()[0];
							IList objList = (IList)Activator.CreateInstance(typeHint);
							foreach (JToken item in jArray)
							{
								DeserializeFromJsonValue(item, out var element2, elementType2);
								objList.Add(element2);
							}
							obj = objList;
							return;
						}
						if (typeof(ISet<>).IsAssignableFrom(typeHint))
						{
							Type collectionType2 = (typeHint.IsGenericType ? typeHint : typeHint.GetInterfaces().First((Type type) => type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ISet<>)));
							Type elementType3 = collectionType2.GetElementType() ?? collectionType2.GetGenericArguments()[0];
							object objList2 = Activator.CreateInstance(typeHint);
							MethodInfo addMethod = collectionType2.GetMethod("Add");
							object[] argArr = new object[1];
							foreach (JToken item2 in jArray)
							{
								DeserializeFromJsonValue(item2, out var element3, elementType3);
								argArr[0] = element3;
								addMethod?.Invoke(objList2, argArr);
							}
							obj = objList2;
							return;
						}
						if (typeHint.IsGenericType && typeof(ISet<>).MakeGenericType(typeHint.GenericTypeArguments).IsAssignableFrom(typeHint))
						{
							MethodInfo objSetAdd = typeHint.GetMethod("Add");
							if ((object)objSetAdd != null)
							{
								Type elementType4 = typeHint.GetGenericArguments()[0];
								object objSet = Activator.CreateInstance(typeHint);
								object[] args = new object[1];
								foreach (JToken item3 in jArray)
								{
									DeserializeFromJsonValue(item3, out var element4, elementType4);
									args[0] = element4;
									objSetAdd.Invoke(objSet, args);
								}
								obj = objSet;
								return;
							}
						}
						throw new InvalidCastException();
					}
					throw new ArgumentOutOfRangeException("Type", jsonValue.Type.ToString(), null);
				}
				string key;
				JToken value;
				if (typeof(IDictionary).IsAssignableFrom(typeHint))
				{
					Type valueType = typeHint.GetGenericArguments()[1];
					IDictionary objDict = (IDictionary)Activator.CreateInstance(typeHint);
					foreach (KeyValuePair<string, JToken> item4 in jObject)
					{
						item4.Deconstruct(out key, out value);
						string key2 = key;
						JToken value2 = value;
						DeserializeFromJsonValue(value2, out var valueData, (value2 is JObject && valueType == typeof(object)) ? typeof(Dictionary<object, object>) : valueType);
						objDict[key2] = valueData;
					}
					obj = objDict;
					return;
				}
				obj = (typeHint.GetConstructors().Any((ConstructorInfo c) => c.GetParameters().Length == 0) ? Activator.CreateInstance(typeHint) : FormatterServices.GetUninitializedObject(typeHint));
				if (obj is ICommonObjectSerializationAware aware)
				{
					aware.InitializeOnDeserializing();
				}
				foreach (KeyValuePair<string, CommonObjectSerializationMember> member3 in GetMembers(obj, deserializing: true))
				{
					member3.Deconstruct(out key, out var value3);
					string name = key;
					CommonObjectSerializationMember member = value3;
					if (!jObject.TryGetValue(name, out JToken value4))
					{
						if (obj is ICommonObjectSerializationAware aware2)
						{
							aware2.DeserializingMissingField(member);
						}
					}
					else
					{
						DeserializeFromJsonValue(value4, out var prop, member.TypeHint);
						member.Setter(prop);
						jObject.Remove(name);
					}
				}
				if (!(obj is ICommonObjectSerializationAware aware3))
				{
					return;
				}
				foreach (KeyValuePair<string, JToken> item5 in jObject)
				{
					item5.Deconstruct(out key, out value);
					string name2 = key;
					JToken value5 = value;
					if (aware3.DeserializingUnknownField(name2, out var member2))
					{
						DeserializeFromJsonValue(value5, out var prop2, member2.TypeHint);
						if (aware3 is ICommonObjectDeserializationDirectValue deserializationDirectValue)
						{
							deserializationDirectValue.OnUnknownFieldGet(name2, prop2);
						}
						else
						{
							member2.Setter(prop2);
						}
					}
				}
				aware3.FinishedDeserialization();
			}
			else if (typeHint.IsEnum && jValue.Value is string str)
			{
				obj = Enum.Parse(typeHint, str);
			}
			else if (typeHint == typeof(Guid) && jValue.Value is string strGuid)
			{
				obj = (Guid.TryParse(strGuid, out var result) ? result : Guid.Empty);
			}
			else
			{
				obj = ((IConvertible)jValue.Value)?.ToType(typeHint, CultureInfo.InvariantCulture);
			}
		}
		else
		{
			obj = null;
		}
	}

	private static Enum SafeEnumValue(int value, Type enumType)
	{
		foreach (Enum e in Enum.GetValues(enumType))
		{
			if (Convert.ToInt32(e) == value)
			{
				return e;
			}
		}
		throw new ArgumentOutOfRangeException("value", $"{value} is not a valid {enumType.Name}");
	}
}
