using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BFS
{
	class Program
	{
		static void Main ()
		{
			Node root = new Node (0, 0);

			Random rand = new Random ();
			Node node;
			Node clone;
			Node other;
			int index;
			for (int i = 1; i < 1000; i++)
			{
				do {
					index = rand.Next (1, 1000);
					other = root.Find (index);
				} while (null != other);

				node = new Node (index, i);
				clone = node.Clone ();
				root.AddLink (ref clone);
			}

			Node found = root.Find (1);
			Console.WriteLine ("\nFound!\nIndex: {0}, Data {1}", found.Index, found.Data);
			found = root.Find (1000);
			Console.WriteLine ("\nFound!\nIndex: {0}, Data {1}", found.Index, found.Data);
		}
	}
	
	class Node
	{
		private object data;
		public object Data {
			get { return this.data; }
			set { this.data = value; }
		}

		private int index;
		public int Index {
			get { return this.index; }
			set { }
		}
		
		private Node left;
		public Node Left {
			get { 
				if (null == this.left) {
					return null;
				} else {
					return this.left;
				}
			}
			set { }
		}
		
		private Node right;
		public Node Right {
			get {
				if (null == this.right) {
					return null;
				} else {
					return this.right;
				}
			}
			set { }
		}

		public Node (int index, object data)
		{
			this.data = data;
			this.index = index;
		}

		public Node Clone ()
		{
			Node clone = new Node (this.Index, this.Data);
			Node right = this.Right;
			Node left = this.Left;
			clone.AddLink (right);
			clone.AddLink (left);
			return clone;
		}

		public Node AddLink (ref Node link)
		{
			if (this.Index < link.Index) {
				if (null == this.Right) {
					this.right = link;
				} else {
					this.Right.AddLink (ref link);
				}
			} else {
				if (null == this.Left) {
					this.left = link;
				} else {
					this.Left.AddLink (ref link);
				}
			}

			return this;
		}

		public Node AddLink (Node link)
		{
			if (null == link) {
				return this;
			} else if (this.Index < link.Index) {
				if (null == this.Right) {
					this.right = link;
				} else {
					this.Right.AddLink (ref link);
				}
			} else {
				if (null == this.Left) {
					this.left = link;
				} else {
					this.Left.AddLink (ref link);
				}
			}

			return this;
		}

		public Node Find (int index)
		{
			List<int> path = new List<int>();
			path.Add (this.Index);

			if (this.Index < index) {
				if (null == this.Right) {
					//Console.WriteLine ("\nNULL\n");
					return null;
				} else {
					//Console.WriteLine ("Index: {0} >> {1}", this.Index, this.right.Index);
					return this.right.Find (index, path);
				}
			} else if (this.Index > index) {
				if (null == this.Left) {
					//Console.WriteLine ("\nNULL\n");
					return null;
				} else {
					//Console.WriteLine ("Index: {0} >> {1}", this.Index, this.left.Index);
					return this.left.Find (index, path);
				}
			} else {
				return this;
			}
		}

		public Node Find (int index, List<int> path)
		{
			int i = this.Index;
			path.Add (i);

			if (this.Index < index) {
				if (null == this.Right) {
					//Console.WriteLine ("\nNULL\n");
					return null;
				} else {
					//Console.WriteLine ("Index: {0} >> {1}", this.Index, this.right.Index);
					return this.right.Find (index, path);
				}
			} else if (this.Index > index) {
				if (null == this.Left) {
					//Console.WriteLine ("\nNULL\n");
					return null;
				} else {
					//Console.WriteLine ("Index: {0} >> {1}", this.Index, this.left.Index);
					path.ForEach (delegate(int ie) { Console.Write("{0} >> ", ie); });
					Console.Write ("\n");
					return this.left.Find (index, path);
				}
			} else {
				return this;
			}
		}
	}
}
