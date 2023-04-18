using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20._20_ex2
{
	internal class Program
	{
		//繪製星號三角形

		//靠左對齊三角形
		//靠右對齊三角形
		//等腰三角形
		//使用委派
		static void Main(string[] args)
		{
			TriangleBuilder tri = new TriangleBuilder();

			char triSymbol = '*'; // 三角形建構符號
			int triHeight = 10; // 三角形高度

			// 靠左三角形
			Func< char, int, int, string > leftTri = (symbol, row, maxRow)
				=> new string(symbol, row); 
			tri.GetResult(triSymbol, triHeight, leftTri);

			// 靠右三角形
			Func<char, int, int, string> rightTri = (symbol, row, maxRow) 
				=> new string(' ', maxRow-row) + new string(symbol, row);
			tri.GetResult(triSymbol, triHeight, rightTri);

			// 等腰三角形
			Func<char, int, int, string> isoscelesTri = (char symbol, int row, int maxRow) 
				=> new string(' ', maxRow-row) + new string(symbol, 2*row-1); 
			tri.GetResult(triSymbol, triHeight, isoscelesTri);

			// 倒置靠左三角形
			Func<char, int, int, string> revLeftTri = (symbol, row, maxRow)
				=>  new string(symbol, maxRow-row+1)+ new string(' ', row - 1);
			tri.GetResult(triSymbol, triHeight, revLeftTri);

			// 倒置靠右三角形
			Func<char, int, int, string> revRightTri = (symbol, row, maxRow)
				=>  new string(' ', row - 1)+ new string(symbol, maxRow - row + 1);
			tri.GetResult(triSymbol, triHeight, revRightTri);

			// 倒置等腰三角形
			Func<char, int, int, string> revisoscelesTri = (symbol, row, maxRow)
				=> new string(' ', row - 1) + new string(symbol, 2 * (maxRow - row) + 1);
			tri.GetResult(triSymbol, triHeight, revisoscelesTri);

		}


	}

	public class TriangleBuilder
	{
		/// <summary>
		/// 符號三角形委派
		/// </summary>
		/// <param name="symbol">三角形建構符號</param>
		/// <param name="row">三角形中第幾排(由上而下)</param>
		/// <param name="maxRow">三角形最多幾排</param>
		/// <param name="func">各種形狀三角形function</param>
		public void GetResult(char symbol, int maxRow, Func<char, int, int, string> func)
		{
			for (int row=1; row<=maxRow; row++)
			{
				Console.WriteLine(func(symbol, row, maxRow));

			}
			Console.WriteLine(""); // 留空白
		}
	}
	//
	
}
