using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DonnyJustin_Assign3
{
    public partial class Form1 : Form
    {
        List<Course> coursePool = new List<Course>();
        IDictionary<uint, Student> studentPool = new Dictionary<uint, Student>();
        System.Collections.Generic.SortedDictionary<uint, Student> sortedPool = null;

        public Form1()
        {
            InitializeComponent();

            // read student input file
            string[] studentLines = File.ReadAllLines("../../input_01.txt");

            // read coures input file
            string[] courseLines = File.ReadAllLines("../../input_02.txt");

            // read major input file
            string[] majorLines = File.ReadAllLines("../../input_03.txt");

            // read grades input file
            string[] gradeLines = File.ReadAllLines("../../input_04.txt");

            // add courses to coursePool list
            for (int i = 0; i < courseLines.Length; i++)
            {
                Course course = new Course(courseLines[i]);
                coursePool.Add(course);
            }
            // add values to studentPool dictionary
            for (int i = 0; i < studentLines.Length; i++)
            {
                string[] tokens = studentLines[i].Split(',');
                uint zid = Convert.ToUInt32(tokens[0]);
                Student student = new Student(studentLines[i]);
                studentPool.Add(zid, student);
            }

            // Sort Dictionary by ZID and store in new Dictionary
            if (studentPool != null)
                sortedPool = new SortedDictionary<uint, Student>(studentPool);

            // Sort Courses alphabetically
            var sortedCourses = sortCourses(coursePool);
        }

        private List<Course> sortCourses(List<Course> coursePool)
        {
            // Sort Courses alphabetically
            var sortedCourses = coursePool.OrderBy(c => c.GetDepartmentCode()).ToList();
            return sortedCourses;
        }

        private void gradeReportOneStudent_Button_Click(object sender, EventArgs e)
        {

        }
    }
}
