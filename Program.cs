using System;
using System.Collections.Generic;
using System.Linq;
					
public class Program
{
	public static void Main()
	{
		List<customer> clist = new List<customer>();
		clist.Add(new customer(1, "Tom")); //no order
		clist.Add(new customer(2, "Sara"));
		clist.Add(new customer(3, "John"));
		clist.Add(new customer(4, "Joe"));
		clist.Add(new customer(5, "Ben")); // many orders

		List<orders> olist = new List<orders>();
		olist.Add(new orders(1, 2, 1000));
		olist.Add(new orders(2, 3, 1001));
		olist.Add(new orders(3, 3, 1002));
		olist.Add(new orders(4, 3, 1003));
		olist.Add(new orders(5, 4, 1004));
		olist.Add(new orders(6, 5, 1006));
		olist.Add(new orders(7, 5, 1007));
		olist.Add(new orders(8, 5, 1008));

		//Part 1 
		IEnumerable<string> listofcustomer = from c in clist
											 orderby c.Name ascending
											 select c.Name;

		foreach (string s in listofcustomer)
			Console.WriteLine(s);

		Console.WriteLine();
		//Part 2
		IEnumerable<int> listoforder = from s in olist
									   orderby s.CustNum ascending
									   select s.CustNum;
		foreach (int o in listoforder)
			Console.WriteLine(o);
		
		// Part 3
		var GroupedByquery = olist.GroupBy(user => user.CustNum);

		foreach (var group in GroupedByquery)
		{
			Console.WriteLine("Users from " + group.Key + ":");
			foreach (var user in group)
				Console.WriteLine("* " + user.CustNum);
		}



	}
}
public class customer
{
	public int CustNum { get; set; }
	public string Name { get; set; }

	public customer(int cust, string name)
	{
		CustNum = cust;
		Name = name;
	}

}
public class orders
{
	public int OrderNum { get; set; }
	public int CustNum { get; set; }
	public int NumofItem { get; set; }

	public orders(int ordernum, int custno, int numofitem)
	{
		OrderNum = ordernum;
		CustNum = custno;
		NumofItem = numofitem;
	}
}

