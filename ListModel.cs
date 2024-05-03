using Avalonia.Controls;
using Microsoft.CodeAnalysis;
using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;

namespace LimitedSizeStack;

public class Operation<TItem>
{
	public string OperationType { get; set; }
	public int OperationId { get; set; }
	public TItem Item { get; set; }

    public Operation(string name, int index, TItem item)
    {
        OperationType = name;
		OperationId = index;
		Item = item;
    }
}

public class ListModel<TItem>
{
	public List<TItem> Items { get; }
	public int UndoLimit;
	public LimitedSizeStack<Operation<TItem>> History;
        
	public ListModel(int undoLimit) : this(new List<TItem>(), undoLimit)
	{
	}

	public ListModel(List<TItem> items, int undoLimit)
	{
		Items = items;
		UndoLimit = undoLimit;
		History = new(undoLimit);
	}

	public void AddItem(TItem item)
	{
		Items.Add(item);
		Operation<TItem> operation = new("Add", Items.Count - 1, item);
		History.Push(operation);
	}

	public void RemoveItem(int index)
	{
        Operation<TItem> operation = new("Remove", index, Items[index]);
		History.Push(operation);
        Items.RemoveAt(index);
	}

	public bool CanUndo()
	{
		if(History.Count > 0)
		{
			return true;
		}
		return false;
	}

	public void Undo()
	{
		Operation<TItem> operation = History.Pop();
		if(operation.OperationType == "Remove")
		{
			Items.Insert(operation.OperationId, operation.Item);
		}
        else
        {
			Items.RemoveAt(operation.OperationId);
        }
    }
}