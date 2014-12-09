using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BST
{
	class Program
	{
		static void Main (string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine ("\n==> BST START <==\n");
			Console.ResetColor ();

			Console.WriteLine ("Interpreting Args ...");
			int size = Convert.ToInt32(args [0]);
			Console.WriteLine ("Input: {0}\n", size);

			Console.WriteLine ("Setting Up\n");
			Random rand = new Random ();
			Node root = new Node (0, 0);
			Node node;
			Node clone;
			int index;
			int numindex;

			Console.WriteLine ("Building Random Machine ...");
			List<int> numbers = new List<int> ();
			for (int i = 1; i <= size; i++) {
				numbers.Add (i);
			}
			Console.WriteLine ("Random Machine Built Successfully!\n");

			Console.WriteLine ("Building Tree ...");
			for (int i = 1; i <= size; i++) {
				numindex = rand.Next(0, numbers.Count () - 1);
				index = numbers [numindex];
				numbers.RemoveAt (numindex);

				node = new Node (index, i);
				clone = node.Clone ();
				root.AddLink (ref clone);
			}
			Console.WriteLine ("Tree Built Successfully!\n");

			do {
				Console.ForegroundColor = ConsoleColor.Yellow;
				Console.Write ("Find (0 to end program): ");
				Console.ResetColor ();
				index = Convert.ToInt32 (Console.ReadLine ());

				Node found = root.Find (index);
				Console.WriteLine ("\nFound!\nIndex: {0}, Data {1}\n", found.Index, found.Data);
			} while (0 != index);

			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine ("==> BST END <==\n");
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
					return null;
				} else {
					return this.right.Find (index, path);
				}
			} else if (this.Index > index) {
				if (null == this.Left) {
					return null;
				} else {
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

			if (i < index) {
				if (null == this.Right) {
					return null;
				} else {
					return this.right.Find (index, path);
				}
			} else if (i > index) {
				if (null == this.Left) {
					return null;
				} else {
					return this.left.Find (index, path);
				}
			} else {
				path.ForEach (delegate(int ie) { Console.Write(">> {0} ", ie); });
				Console.Write ("\n");
				return this;
			}
		}
	}
}
