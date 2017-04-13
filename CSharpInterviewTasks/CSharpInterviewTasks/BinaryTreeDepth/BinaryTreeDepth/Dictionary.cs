using System;

namespace BinaryTreeDepth
{
	public class Dictionary
	{
		private const int HASHSIZE = 100;
		private Entry[] entries;
		private int[] buckets;
		private LinkedList holes;

		public int Count;

		public struct Entry
		{
			public int HashCode;
			//public int next;
			public BinaryTree.Node Key;
			public int Value;
		}

		public Dictionary()
		{
			entries = new Entry[HASHSIZE];
			buckets = new int[HASHSIZE];
			Count = 0;

			for (int i = 0; i < buckets.Length; i++)
			{
				buckets[i] = -1;
			}
			holes = new LinkedList();
		}

		public int GetHashCode(BinaryTree.Node key)
		{
			return key.Value; // This should be improved to be unique
		}

		public void Add(BinaryTree.Node key, int value)
		{
			int hashCode = GetHashCode(key);
			int index = holes.Size == 0 ? Count : holes.Pop();
			entries[index] = new Entry() {HashCode = hashCode, Key = key, Value = value};
			buckets[hashCode%HASHSIZE] = index;
			Count++;
		}

		public void Remove(BinaryTree.Node key)
		{
			int hashCode = GetHashCode(key);
			int index = buckets[hashCode%HASHSIZE];
			if (index == -1)
			{
				throw new ArgumentException("Key Not Found");
			}

			entries[index] = default(Entry);
			holes.Add(index);
			buckets[hashCode%HASHSIZE] = -1;
			Count--;

			if (Count == 0)
			{
				holes.Reset();
			}
		}

		public Entry First()
		{
			if (Count == 0)
			{
				throw new InvalidOperationException("Unable to find first item. Dictionary is empty");
			}

			for (int i = 0; i < entries.Length; i++)
			{
				if (entries[i].Key != null)
				{
					return entries[i];
				}
			}
			throw new InvalidOperationException("Entry not found in the list");
		}

		public int Get(BinaryTree.Node key)
		{
			int hashCode = GetHashCode(key);
			int index = buckets[hashCode % HASHSIZE];

			if (index == -1)
			{
				throw new ArgumentException("Key Not Found");
			}
			return entries[index].Value;
		}
	}
}
