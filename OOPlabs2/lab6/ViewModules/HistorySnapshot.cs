using System;
using System.Collections.Generic;

namespace lab6.ViewModules
{
    public enum HistoryAction
    {
        Add, Remove, Clear
    }
    public class HistorySnapshot<T>
    {
        private readonly List<T> Data;
        private readonly HistoryAction Action;
        public HistorySnapshot(List<T> data, HistoryAction action)
        {
            Data = data;
            Action = action;
        }
        public HistorySnapshot(T data, HistoryAction action)
        {
            Data = new List<T>() { data };
            Action = action;
        }
        public HistorySnapshot(HistorySnapshot<T> snapshot)
        {
            Data = snapshot.Data;
            Action = snapshot.Action;
        }
        public void Redo(ICollection<T> collection)
        {
            switch (Action)
            {
                case HistoryAction.Add:
                    foreach (var item in Data)
                    {
                        collection.Add(item);
                    }
                    break;
                case HistoryAction.Remove:
                    foreach (var item in Data)
                    {
                        collection.Remove(item);
                    }
                    break;
                case HistoryAction.Clear:
                    collection.Clear();
                    break;
                default:
                    break;
            }
        }
        public void Undo(ICollection<T> collection)
        {
            switch (Action)
            {
                case HistoryAction.Add:
                    foreach (var item in Data)
                    {
                        collection.Remove(item);
                    }
                    break;
                case HistoryAction.Remove:
                    foreach (var item in Data)
                    {
                        collection.Add(item);
                    }
                    break;
                case HistoryAction.Clear:
                    foreach (var item in Data)
                    {
                        collection.Add(item);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
