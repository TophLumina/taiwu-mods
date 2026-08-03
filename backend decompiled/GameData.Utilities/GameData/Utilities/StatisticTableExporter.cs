using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace GameData.Utilities;

public class StatisticTableExporter<T>
{
	private class HandleInfo
	{
		public readonly string Header;

		protected CellValueHandle Delegate;

		public HandleInfo(string header, CellValueHandle handle)
		{
			Header = header;
			Delegate = handle;
		}

		protected HandleInfo(string header)
		{
			Header = header;
			Delegate = null;
		}

		public void Invoke(StringBuilder stringBuilder, T source)
		{
			if (Delegate != null)
			{
				Delegate(stringBuilder, source);
			}
			else
			{
				stringBuilder.Append("Undefined");
			}
		}
	}

	private class AutoFieldHandleInfo : HandleInfo
	{
		private readonly FieldInfo _fieldInfo;

		public AutoFieldHandleInfo(string fieldIdentifier, string header)
			: base(header)
		{
			_fieldInfo = typeof(T).GetField(fieldIdentifier, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			Delegate = SelectFieldValue;
		}

		private void SelectFieldValue(StringBuilder stringBuilder, T source)
		{
			if (_fieldInfo == null)
			{
				stringBuilder.Append("Undefined");
			}
			else
			{
				stringBuilder.Append(_fieldInfo.GetValue(source));
			}
		}
	}

	private class AutoPropertyHandleInfo : HandleInfo
	{
		private readonly PropertyInfo _propertyInfo;

		public AutoPropertyHandleInfo(string propertyIdentifier, string header)
			: base(header)
		{
			_propertyInfo = typeof(T).GetProperty(propertyIdentifier, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			Delegate = SelectPropertyValue;
		}

		private void SelectPropertyValue(StringBuilder stringBuilder, T source)
		{
			if (_propertyInfo == null)
			{
				stringBuilder.Append("Undefined");
			}
			else
			{
				stringBuilder.Append(_propertyInfo.GetValue(source));
			}
		}
	}

	private class AutoGetterHandleInfo : HandleInfo
	{
		private readonly MethodInfo _methodInfo;

		public AutoGetterHandleInfo(string methodIdentifier, string header)
			: base(header)
		{
			_methodInfo = typeof(T).GetMethod(methodIdentifier, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			Delegate = SelectMethodReturnValue;
		}

		private void SelectMethodReturnValue(StringBuilder stringBuilder, T source)
		{
			if (_methodInfo == null)
			{
				stringBuilder.Append("Undefined");
			}
			else
			{
				stringBuilder.Append(_methodInfo.Invoke(source, null));
			}
		}
	}

	public delegate void CellValueHandle(StringBuilder stringBuilder, T source);

	private string _separator;

	private StringBuilder _stringBuilder;

	private static readonly Dictionary<string, HandleInfo> Handles = new Dictionary<string, HandleInfo>();

	private bool _isInitialized;

	public StatisticTableExporter()
	{
		Initialize("\t");
	}

	public StatisticTableExporter(string separator)
	{
		Initialize(separator);
	}

	public void DefineHeader(string key, string header, CellValueHandle valueHandle)
	{
		HandleInfo handleInfo = new HandleInfo(header, valueHandle);
		Handles.Add(key, handleInfo);
	}

	public void DefineFieldHeader(string field, string header)
	{
		if (string.IsNullOrEmpty(header))
		{
			header = field;
		}
		AutoFieldHandleInfo handleInfo = new AutoFieldHandleInfo(field, header);
		Handles.Add(field, handleInfo);
	}

	public void DefinePropertyHeader(string property, string header)
	{
		if (string.IsNullOrEmpty(header))
		{
			header = property;
		}
		AutoPropertyHandleInfo handleInfo = new AutoPropertyHandleInfo(property, header);
		Handles.Add(property, handleInfo);
	}

	public void DefineGetterHeader(string getter, string header)
	{
		if (string.IsNullOrEmpty(header))
		{
			header = getter;
		}
		AutoGetterHandleInfo handleInfo = new AutoGetterHandleInfo(getter, header);
		Handles.Add(getter, handleInfo);
	}

	public void Initialize(string separator)
	{
		_isInitialized = true;
		_separator = separator;
		Handles.Clear();
		MethodInfo[] methods = GetType().GetMethods((BindingFlags)(-1));
		foreach (MethodInfo method in methods)
		{
			CellValueHandleAttribute attr = method.GetCustomAttribute<CellValueHandleAttribute>();
			if (attr != null)
			{
				CellValueHandle handle = (CellValueHandle)(method.IsStatic ? method.CreateDelegate(typeof(CellValueHandle)) : method.CreateDelegate(typeof(CellValueHandle), this));
				HandleInfo handleInfo = new HandleInfo(attr.DisplayName, handle);
				Handles.Add(attr.Key, handleInfo);
			}
		}
	}

	public void Export(StringBuilder stringBuilder, ICollection<string> keys, ICollection<T> sources)
	{
		CheckInitialized();
		AppendHeaderRow(stringBuilder, keys);
		stringBuilder.AppendLine();
		foreach (T source in sources)
		{
			AppendValueRow(stringBuilder, keys, source);
			stringBuilder.AppendLine();
		}
	}

	public void Export(string filePath, ICollection<string> keys, ICollection<T> sources)
	{
		CheckInitialized();
		DirectoryInfo directory = Directory.GetParent(filePath);
		if (directory != null && !directory.Exists)
		{
			directory.Create();
		}
		using TextWriter textWriter = new StreamWriter(filePath);
		if (_stringBuilder == null)
		{
			_stringBuilder = new StringBuilder();
		}
		_stringBuilder.Clear();
		AppendHeaderRow(_stringBuilder, keys);
		textWriter.WriteLine((object?)_stringBuilder);
		_stringBuilder.Clear();
		foreach (T source in sources)
		{
			AppendValueRow(_stringBuilder, keys, source);
			textWriter.WriteLine((object?)_stringBuilder);
			_stringBuilder.Clear();
		}
	}

	public void AppendHeaderLine(StringBuilder stringBuilder, ICollection<string> keys)
	{
		AppendHeaderRow(stringBuilder, keys);
		stringBuilder.AppendLine();
	}

	public void AppendValueLine(StringBuilder stringBuilder, ICollection<string> keys, T source)
	{
		AppendValueRow(stringBuilder, keys, source);
		stringBuilder.AppendLine();
	}

	public void AppendValueRow(StringBuilder stringBuilder, ICollection<string> keys, T source)
	{
		int count = 0;
		int maxCount = keys.Count;
		foreach (string key in keys)
		{
			if (Handles.TryGetValue(key, out var handleInfo))
			{
				handleInfo.Invoke(stringBuilder, source);
			}
			else
			{
				AppendFieldValue(stringBuilder, key, source);
			}
			count++;
			if (count < maxCount)
			{
				stringBuilder.Append(_separator);
			}
		}
	}

	public void AppendHeaderRow(StringBuilder stringBuilder, ICollection<string> keys)
	{
		int count = 0;
		int maxCount = keys.Count;
		foreach (string key in keys)
		{
			stringBuilder.Append(Handles.TryGetValue(key, out var handleInfo) ? handleInfo.Header : key);
			count++;
			if (count < maxCount)
			{
				stringBuilder.Append(_separator);
			}
		}
	}

	protected void AppendFieldValue(StringBuilder stringBuilder, string fieldName, T source)
	{
		FieldInfo fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (fieldInfo != null)
		{
			stringBuilder.Append(fieldInfo.GetValue(source));
		}
		else
		{
			stringBuilder.Append("Undefined");
		}
	}

	private void CheckInitialized()
	{
		if (!_isInitialized)
		{
			throw new Exception("Current Statistic table exporter " + GetType().FullName + " is not initialized.");
		}
	}
}
