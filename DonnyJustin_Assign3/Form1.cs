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
        List<History> historyPool = new List<History>();
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
            string[] historyLines = File.ReadAllLines("../../input_05.txt");

            // add courses to coursePool list
            for (int i = 0; i < courseLines.Length; i++)
            {
                Course course = new Course(courseLines[i]);
                coursePool.Add(course);
            }

            // add attempt to historyPool list
            for (int i = 0; i < historyLines.Length; i++)
            {
                History attempt = new History(historyLines[i]);
                historyPool.Add(attempt);
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

            // add items to major_ComboBox
            grade1_ComboBox.Items.Add("A");
            grade1_ComboBox.Items.Add("A-");
            grade1_ComboBox.Items.Add("B+");
            grade1_ComboBox.Items.Add("B");
            grade1_ComboBox.Items.Add("B-");
            grade1_ComboBox.Items.Add("C++");
            grade1_ComboBox.Items.Add("C");
            grade1_ComboBox.Items.Add("C-");
            grade1_ComboBox.Items.Add("D+");
            grade1_ComboBox.Items.Add("D");
            grade1_ComboBox.Items.Add("D-");
            grade1_ComboBox.Items.Add("F");
        }

        private List<Course> sortCourses(List<Course> coursePool)
        {
            // Sort Courses alphabetically
            var sortedCourses = coursePool.OrderBy(c => c.GetDepartmentCode()).ToList();
            return sortedCourses;
        }

        private void gradeReportOneStudent_Button_Click(object sender, EventArgs e)
        {
            query_ListBox.Items.Clear();
            string temp = ZID_RichTextBox.Text;
            int zid = Convert.ToInt32(temp);


            var Query =
                from N in historyPool
                where N.getZid() == zid
                select N.getDept() + "       " + N.getCourseNum()  + "       " + N.getGrade();

            foreach (var i in Query)
                query_ListBox.Items.Add(i.ToString());
  
        }

        private void gradeThreshold_Button_Click(object sender, EventArgs e)
        {
            query_ListBox.Items.Clear();
            string grade = (string)grade1_ComboBox.SelectedItem;
            string course = courseThreshold_RichTextBox.Text;

            // parse course input
            string[] courseTokens = course.Split(' ');

            if (lessThan_RadioButton1.Checked)
            {
                var Query =
                from N in historyPool
                where getAsciiValue(N.getGrade()) >= getAsciiValue(grade) && courseTokens[0] == N.getDept() && courseTokens[1] == N.getCourseNum().ToString()
                select N.getZid() + "   " + N.getDept() + "    " + N.getCourseNum() + "     " + N.getGrade();

                foreach (var i in Query)
                    query_ListBox.Items.Add(i.ToString());
            }
            else if (greaterThan_RadioButton1.Checked)
            {
                var Query =
                from N in historyPool
                where getAsciiValue(N.getGrade()) <= getAsciiValue(grade) && courseTokens[0] == N.getDept() && courseTokens[1] == N.getCourseNum().ToString()
                select N.getZid() + "   " + N.getDept() + "    " + N.getCourseNum() + "     " + N.getGrade();

                foreach (var i in Query)
                    query_ListBox.Items.Add(i.ToString());
            }
        }

        // return adjusted ascii value
        private int getAsciiValue(string grade)
        {
            char letter = ' ';
            char sign = ' ';
            int asciiVal = 0;

            if (grade.Length == 1)
            {
                letter = grade[0];
                asciiVal = (int)letter;
                return asciiVal * 3;
            }
            else if (grade.Length > 1)
            {
                letter = grade[0];
                sign = grade[1];
                int letterVal = (int)letter * 3;
                int signVal = (int)sign;
                if (signVal == 43)
                {
                    // sign is +
                    signVal -= (signVal + 1);
                }
                else
                {
                    // sign is -
                    signVal -= (signVal - 1);
                }

                asciiVal = letterVal + signVal;
                return asciiVal;
            }
            return 0;
        }

        private void gradeReportOneCourse_Button_Click(object sender, EventArgs e)
        {
            query_ListBox.Items.Clear();

            string temp = gradeReport_RichTextBox.Text;

            var Query =
                from N in historyPool
                where N.getDept() == temp
                select N.getZid() + "   "+ N.getGrade();

            foreach (var i in Query)
                query_ListBox.Items.Add(i);
        }
    }
}