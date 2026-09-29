using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace GameData.Common.Algorithm;

public class PriorityEvent<TPriority, TContext> where TPriority : IComparable
{
	public delegate void PriorityEventHandlerSimple(TContext context);

	public delegate TContext PriorityEventHandlerWithoutStatus(TContext context);

	public delegate EPriorityEventStatus PriorityEventHandlerWithoutContext(TContext context);

	public delegate(TContext Context, EPriorityEventStatus Status) PriorityEventHandler(TContext context);

	private readonly record struct PriorityEventData(long Id, PriorityEventHandler Handler, TPriority Priority) : IComparable<PriorityEventData>
	{
		public readonly long Id;

		public readonly TPriority Priority;

		public readonly PriorityEventHandler Handler;

		public int CompareTo(PriorityEventData other)
		{
			int priorityComparison = Comparer<TPriority>.Default.Compare(Priority, other.Priority);
			if (priorityComparison == 0)
			{
				return Id.CompareTo(other.Id);
			}
			return priorityComparison;
		}

		[CompilerGenerated]
		public void Deconstruct(out long Id, out PriorityEventHandler Handler, out TPriority Priority)
		{
			Id = this.Id;
			Handler = this.Handler;
			Priority = this.Priority;
		}
	}

	private readonly TPriority _defaultPriority;

	private PriorityEventData[] _events = Array.Empty<PriorityEventData>();

	private readonly ConcurrentDictionary<long, int> _eventStates = new ConcurrentDictionary<long, int>();

	private static void ThrowIfNull(object value, string parameterName)
	{
		if (value == null)
		{
			throw new ArgumentNullException(parameterName);
		}
	}

	public PriorityEvent(TPriority defaultPriority)
	{
		_defaultPriority = defaultPriority;
	}

	private bool IsActive(long eventId)
	{
		if (_eventStates.TryGetValue(eventId, out var state))
		{
			return state == 0;
		}
		return false;
	}

	public long AddEvent(PriorityEventHandler handler)
	{
		return AddEvent(handler, _defaultPriority);
	}

	public long AddEvent(PriorityEventHandler handler, TPriority priority)
	{
		ThrowIfNull(handler, "handler");
		return AddEventInternal(handler.Invoke, priority);
	}

	private long AddEventInternal(PriorityEventHandler handler, TPriority priority)
	{
		long id = Interlocked.Increment(ref PriorityEventHelper.NextId);
		PriorityEventData data = new PriorityEventData(id, handler, priority);
		if (!_eventStates.TryAdd(id, 0))
		{
			throw new InvalidOperationException("Unable to register the priority event.");
		}
		PublishWithAddedEvent(data);
		return id;
	}

	private void PublishWithAddedEvent(PriorityEventData addedEvent)
	{
		PriorityEventData[] snapshot;
		List<PriorityEventData> updated;
		do
		{
			snapshot = Volatile.Read(in _events);
			updated = new List<PriorityEventData>(snapshot.Length + 1);
			PriorityEventData[] array = snapshot;
			for (int i = 0; i < array.Length; i++)
			{
				PriorityEventData data = array[i];
				if (IsActive(data.Id))
				{
					updated.Add(data);
				}
			}
			if (IsActive(addedEvent.Id))
			{
				updated.Add(addedEvent);
			}
			updated.Sort((PriorityEventData left, PriorityEventData right) => left.CompareTo(right));
		}
		while (Interlocked.CompareExchange(ref _events, updated.ToArray(), snapshot) != snapshot);
	}

	public long AddEventOnce(PriorityEventHandlerSimple handler)
	{
		return AddEventOnce(handler, _defaultPriority);
	}

	public long AddEventOnce(PriorityEventHandlerSimple handler, TPriority priority)
	{
		ThrowIfNull(handler, "handler");
		return AddEventInternal(delegate(TContext context)
		{
			handler(context);
			return (Context: context, Status: EPriorityEventStatus.Done);
		}, priority);
	}

	public long AddEventOnce(PriorityEventHandlerWithoutStatus handler)
	{
		return AddEventOnce(handler, _defaultPriority);
	}

	public long AddEventOnce(PriorityEventHandlerWithoutStatus handler, TPriority priority)
	{
		ThrowIfNull(handler, "handler");
		return AddEventInternal((TContext context) => (Context: handler(context), Status: EPriorityEventStatus.Done), priority);
	}

	public long AddEventLoop(PriorityEventHandlerSimple handler)
	{
		return AddEventLoop(handler, _defaultPriority);
	}

	public long AddEventLoop(PriorityEventHandlerSimple handler, TPriority priority)
	{
		ThrowIfNull(handler, "handler");
		return AddEventInternal(delegate(TContext context)
		{
			handler(context);
			return (Context: context, Status: EPriorityEventStatus.Keep);
		}, priority);
	}

	public long AddEventLoop(PriorityEventHandlerWithoutStatus handler)
	{
		return AddEventLoop(handler, _defaultPriority);
	}

	public long AddEventLoop(PriorityEventHandlerWithoutStatus handler, TPriority priority)
	{
		ThrowIfNull(handler, "handler");
		return AddEventInternal((TContext context) => (Context: handler(context), Status: EPriorityEventStatus.Keep), priority);
	}

	public long AddEvent(PriorityEventHandlerWithoutContext handler)
	{
		return AddEvent(handler, _defaultPriority);
	}

	public long AddEvent(PriorityEventHandlerWithoutContext handler, TPriority priority)
	{
		ThrowIfNull(handler, "handler");
		return AddEventInternal((TContext context) => (Context: context, Status: handler(context)), priority);
	}

	public void RemoveEvent(long eventId)
	{
		if (_eventStates.TryUpdate(eventId, 1, 0))
		{
			_eventStates.TryRemove(eventId, out var _);
		}
	}

	public TContext InvokeEvent(TContext context)
	{
		PriorityEventData[] array = Volatile.Read(in _events);
		for (int i = 0; i < array.Length; i++)
		{
			PriorityEventData data = array[i];
			if (IsActive(data.Id))
			{
				(TContext Context, EPriorityEventStatus Status) tuple = data.Handler(context);
				TContext nextContext = tuple.Context;
				EPriorityEventStatus item = tuple.Status;
				context = nextContext;
				if (item.Contains(EPriorityEventStatus.Done))
				{
					RemoveEvent(data.Id);
				}
				if (item.Contains(EPriorityEventStatus.BreakNext))
				{
					break;
				}
			}
		}
		return context;
	}
}
