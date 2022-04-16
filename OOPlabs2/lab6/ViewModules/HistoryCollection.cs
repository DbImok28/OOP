using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6.ViewModules
{
    public class HistoryCollection<T> : ICollection<T>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        public HistoryCollection(ObservableCollection<T> sourceCollection)
        {
            SourceCollection = sourceCollection;
            UndoHistory = new Stack<HistorySnapshot<T>>();
            RedoHistory = new Stack<HistorySnapshot<T>>();
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => ((INotifyPropertyChanged)SourceCollection).PropertyChanged += value;
            remove => ((INotifyPropertyChanged)SourceCollection).PropertyChanged -= value;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add => ((INotifyCollectionChanged)SourceCollection).CollectionChanged += value;
            remove => ((INotifyCollectionChanged)SourceCollection).CollectionChanged -= value;
        }

        public ObservableCollection<T> SourceCollection { get; private set; }
        public Stack<HistorySnapshot<T>> UndoHistory { get; private set; }
        public Stack<HistorySnapshot<T>> RedoHistory { get; private set; }

        public void TakeSnapshot(List<T> data, HistoryAction action)
        {
            UndoHistory.Push(new HistorySnapshot<T>(data, action));
            RedoHistory.Clear();
        }
        public void TakeSnapshot(T data, HistoryAction action)
        {
            UndoHistory.Push(new HistorySnapshot<T>(data, action));
            RedoHistory.Clear();
        }
        public void Undo()
        {
            if (UndoHistory.Count < 0)
                return;
            var snapshot = UndoHistory.Pop();
            snapshot.Undo(SourceCollection);
            RedoHistory.Push(snapshot);
        }
        public void Redo()
        {
            if (RedoHistory.Count < 0)
                return;
            var snapshot = RedoHistory.Pop();
            snapshot.Redo(SourceCollection);
            UndoHistory.Push(snapshot);
        }

        public void Add(T item)
        {
            SourceCollection.Add(item);
            TakeSnapshot(item, HistoryAction.Add);
        }

        public void Clear()
        {
            var saveItems = new List<T>();
            saveItems.AddRange(SourceCollection);
            SourceCollection.Clear();
            TakeSnapshot(saveItems, HistoryAction.Clear);
        }
        public bool Remove(T item)
        {
            if (SourceCollection.Remove(item))
            {
                TakeSnapshot(item, HistoryAction.Remove);
                return true;
            }
            return false;
        }

        public bool Contains(T item) => SourceCollection.Contains(item);
        public void CopyTo(T[] array, int arrayIndex) => SourceCollection.CopyTo(array, arrayIndex);
        public IEnumerator<T> GetEnumerator() => SourceCollection.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)SourceCollection).GetEnumerator();
        public int Count => SourceCollection.Count;
        public bool IsReadOnly => false;
        
    }
}
