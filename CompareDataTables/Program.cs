using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; 
 


namespace CompareDataTables
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtMaths = new DataTable("Maths");
            dtMaths.Columns.Add("StudID", typeof(int));
            dtMaths.Columns.Add("StudName", typeof(string));
            dtMaths.Rows.Add(1, "Mike");
            dtMaths.Rows.Add(2, "Mukesh");
            dtMaths.Rows.Add(3, "Erin");
            dtMaths.Rows.Add(4, "Roshni");
            dtMaths.Rows.Add(5, "Ajay");

            DataTable dtEnglish = new DataTable("English");
            dtEnglish.Columns.Add("StudID", typeof(int));
            dtEnglish.Columns.Add("StudName", typeof(string));
            dtEnglish.Rows.Add(6, "Arjun");
            dtEnglish.Rows.Add(2, "Mukesh");
            dtEnglish.Rows.Add(7, "John");
            dtEnglish.Rows.Add(4, "Roshni");
            dtEnglish.Rows.Add(8, "Kumar");
            
            DataTable dtOnlyMaths = dtMaths.AsEnumerable().Except(dtEnglish.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            
            Console.WriteLine("Students enrolled only for Maths");
            foreach(DataRow dr in dtOnlyMaths.Rows)
            {
                Console.WriteLine(string.Format("StudentID: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString())); 
            }


            Console.WriteLine("");
            Console.WriteLine("Students enrolled only for English");
            DataTable dtOnlyEnglish = dtEnglish.AsEnumerable().Except(dtMaths.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();            
            foreach (DataRow dr in dtOnlyEnglish.Rows)
            {
                Console.WriteLine(string.Format("StudentID: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }


            Console.WriteLine("");
            Console.WriteLine("Students enrolled for both Math and English");
            DataTable dtIntersect = dtMaths.AsEnumerable().Intersect(dtEnglish.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtIntersect.Rows)
            {
                Console.WriteLine(string.Format("StudentID: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }

            Console.WriteLine("");
            Console.WriteLine("List of all students");
            DataTable dtBoth = dtMaths.AsEnumerable().Union(dtEnglish.AsEnumerable(), DataRowComparer.Default).CopyToDataTable();
            foreach (DataRow dr in dtBoth.Rows)
            {
                Console.WriteLine(string.Format("StudentID: {0}, StudentName: {1}", dr[0].ToString(), dr[1].ToString()));
            }

            Console.Read(); 
            
        }
    }
}
