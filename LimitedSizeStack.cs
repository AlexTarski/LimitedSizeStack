using System;
using System.Collections.Generic;

namespace LimitedSizeStack;

public class LimitedSizeStack<T>
{
	private LinkedList<T> stack = new ();
	private int limit;
	public LimitedSizeStack(int undoLimit)
	{
		this.limit = undoLimit;
	}

	public void Push(T item)
	{
		if (stack.Count < limit)
		{
			stack.AddLast(item);
		}
		else
		{
			stack.AddLast(item);
			stack.RemoveFirst();
		}
	}

	public T Pop()
	{
		if (stack.Count == 0) throw new InvalidCastException();
		T item = stack.Last.Value;
		stack.RemoveLast();
		return item;
	}

	public int Count => stack.Count;
}