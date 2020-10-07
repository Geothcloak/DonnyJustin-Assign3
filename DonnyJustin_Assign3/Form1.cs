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
            string[] historyLines = File.ReadAllLines("../../input_04.txt");

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

            // add items to grade_ComboBox
            addGrades(grade1_ComboBox);

            // add items to grade_ComboBox
            addGrades(passReport_ComboBox);

           
            topStudents();
            
        }

        private void addGrades(ComboBox box)
        {
            // add items to grade_ComboBox
            box.Items.Add("A");
            box.Items.Add("A-");
            box.Items.Add("B+");
            box.Items.Add("B");
            box.Items.Add("B-");
            box.Items.Add("C++");
            box.Items.Add("C");
            box.Items.Add("C-");
            box.Items.Add("D+");
            box.Items.Add("D");
            box.Items.Add("D-");
            box.Items.Add("F");
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

            // check if student exists
            bool studentExists = false;
            foreach (KeyValuePair<uint, Student> kvp in studentPool)
            {
                if (zid != kvp.Key)
                    studentExists = false;
                else
                {
                    studentExists = true;
                    break;
                }
            }

            if (studentExists)
            {
                var Query =
                from N in historyPool
                where N.getZid() == zid
                select N.getZid() + " | " + N.getDept() + " | " + N.getCourseNum() + " | " + N.getGrade();

                query_ListBox.Items.Add("Single Student Grade Report (" + zid + ")");
                query_ListBox.Items.Add("--------------------------------------");

                foreach (var i in Query)
                    query_ListBox.Items.Add(i.ToString());

                query_ListBox.Items.Add("### END RESULTS ###");
            }
            else
                query_ListBox.Items.Add("Student does not exist.");

        }

        private void gradeThreshold_Button_Click(object sender, EventArgs e)
        {
            query_ListBox.Items.Clear();
            string grade = (string)grade1_ComboBox.SelectedItem;
            string course = courseThreshold_RichTextBox.Text;

            // parse course input
            string[] courseTokens = course.Split(' ');

            // check if class exists
            bool classExists = false;
            foreach (Course c in coursePool)
            {
                if (courseTokens[0] == c.GetDepartmentCode() && courseTokens[1] == c.GetCourseNumber().ToString())
                    classExists = true;
            }

            if (classExists)
            {
                query_ListBox.Items.Add("Grade Threshold Report for (" + course + ")");
                query_ListBox.Items.Add("-----------------------------------------");

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

                    query_ListBox.Items.Add("Grade Threshold Report for (" + courseTokens[0] + " " + courseTokens[1] + ")");
                    query_ListBox.Items.Add("------------------------------------");

                    foreach (var i in Query)
                        query_ListBox.Items.Add(i.ToString());

                    query_ListBox.Items.Add("### END RESULTS ###");
                }

                query_ListBox.Items.Add("### END RESULTS ###");
            }
            else
                query_ListBox.Items.Add("This class does not exist.");
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

            // check if class exists
            string[] courseTokens = temp.Split(' ');
            bool classExists = false;
            foreach (Course c in coursePool)
            {
                if (courseTokens[0] == c.GetDepartmentCode() && courseTokens[1] == c.GetCourseNumber().ToString())
                   classExists = true;
            }

            // print grade report for specified class
            if (classExists)
            {
                var Query =
                    from N in historyPool
                    where N.getDept() == courseTokens[0] && N.getCourseNum().ToString() == courseTokens[1]
                    select N.getZid() + " | " + N.getDept() + " " + N.getCourseNum() + " | " + N.getGrade();

                query_ListBox.Items.Add("Grade Report for (" + courseTokens[0] + " " + courseTokens[1] + ")");
                query_ListBox.Items.Add("-----------------------------------");

                foreach (var i in Query)
                    query_ListBox.Items.Add(i);

                query_ListBox.Items.Add("### END RESULTS ###");
            }
            else
                query_ListBox.Items.Add("This class does not exist.");
        }

        private void failReport_Button_Click(object sender, EventArgs e)
        {
            query_ListBox.Items.Clear();

            // get all the class names
            List<string> courseList = new List<string>();
            foreach (History h in historyPool)
            {
                string dept = h.getDept();
                string courseNum = h.getCourseNum().ToString();
                string course = dept + " " + courseNum;
                if (!courseList.Contains(course))
                    courseList.Add(course);
            }

            query_ListBox.Items.Add("Fail Percentage (>= " + failReport_UpDown.Value + "%) Report for Classes.\n");
            query_ListBox.Items.Add("-------------------------------------------------");

            // get num failed & num enrolled
            foreach (var c in courseList)
            {
                int[] report = failReport(c);

                decimal failPercentThreshold = failReport_UpDown.Value;
                decimal numFailed = report[0];
                decimal numEnrolled = report[1];
                decimal failPercent = numFailed / numEnrolled;

                if (lessThan_RadioButton2.Checked)
                {
                    if ((numFailed / numEnrolled)*100 <= failPercentThreshold)
                    {
                        query_ListBox.Items.Add("Out of " + numEnrolled + " enrolled in CSCI-240, " + numFailed + " failed " +
                                                "( " + string.Format("{0:#.##}", failPercent * 100) + "%)");
                    }
                }
                else if (greaterThan_RadioButton2.Checked)
                {
                    if ((numFailed / numEnrolled)*100 >= failPercentThreshold)
                    {
                        query_ListBox.Items.Add("Out of " + numEnrolled + " enrolled in " + c + ", " + numFailed + " failed " +
                                                "( " + string.Format("{0:#.##}", failPercent * 100) + "%)");
                    }
                }
            }

            query_ListBox.Items.Add("\n### END RESULTS ###");
        }

        private int[] failReport(string className)
        {
            int enrolledCount = 0;
            int failCount = 0;
            string[] classTokens = className.Split(' ');
            foreach (History h in historyPool)
            {
                if (h.getDept() == classTokens[0] && h.getCourseNum() == Convert.ToInt16(classTokens[1]))
                {
                    enrolledCount++;
                    if (h.getGrade() == "F")
                        failCount++;
                }

            }

            int[] report = { failCount, enrolledCount };
            return report;
        }

        private void passReport_Button_Click(object sender, EventArgs e)
        {
            query_ListBox.Items.Clear();

            // get all the class names
            List<string> courseList = new List<string>();
            foreach (History h in historyPool)
            {
                string dept = h.getDept();
                string courseNum = h.getCourseNum().ToString();
                string course = dept + " " + courseNum;
                if (!courseList.Contains(course))
                    courseList.Add(course);
            }

            query_ListBox.Items.Add("Fail Percentage (>= " + passReport_ComboBox.SelectedItem + "%) Report for Classes.\n");
            query_ListBox.Items.Add("-------------------------------------------------");

            foreach (var c in courseList)
            {
                int[] report = passReport(c);
                decimal numPassed = report[0];
                decimal numEnrolled = report[1];
                decimal passPercent = numPassed / numEnrolled;
                string grade = (string)passReport_ComboBox.SelectedItem;

                // output results
               if (lessThan_RadioButton3.Checked)
                {
                   query_ListBox.Items.Add("Out of " + report[1] + " enrolled in " + c + ", " + report[0] +
                                           " passed at or below this threshold (" + string.Format("{0:#.##}", passPercent * 100) + "%)");
                }
               else if (greaterThan_RadioButton3.Checked)
                {
                    query_ListBox.Items.Add("Out of " + report[1] + " enrolled in " + c + ", " + report[0] +
                                            " passed at or below this threshold (" + string.Format("{0:#.##}", passPercent * 100) + "%)");
                }
            }
        }

        private int[] passReport(string className)
        {
            int enrolledCount = 0;
            int passCount = 0;
            string[] classTokens = className.Split(' ');
            string grade = (string)passReport_ComboBox.SelectedItem;

            if (lessThan_RadioButton3.Checked)
            {
                foreach (History h in historyPool)
                {
                    if (h.getDept() == classTokens[0] && h.getCourseNum() == Convert.ToInt16(classTokens[1]))
                    {
                        enrolledCount++;
                        if (getAsciiValue(h.getGrade()) <= getAsciiValue(grade))
                            passCount++;
                    }
                }
            }
            else if (greaterThan_RadioButton3.Checked)
            {
                foreach (History h in historyPool)
                {
                    if (h.getDept() == classTokens[0] && h.getCourseNum() == Convert.ToInt16(classTokens[1]))
                    {
                        enrolledCount++;
                        if (getAsciiValue(h.getGrade()) >= getAsciiValue(grade))
                            passCount++;
                    }
                }
            }

            int[] report = { passCount, enrolledCount };
            return report;
        }

        private void topStudents()
        {
            IDictionary<uint, decimal> gradePool = new Dictionary<uint, decimal>();

            List<uint> zidCheck = new List<uint>();

            foreach (var z in historyPool)
            {
                if (!zidCheck.Contains(z.getZid()))
                    zidCheck.Add(z.getZid());
            }
            
            foreach (var i in zidCheck)
            { 
                int total = 0;
                var Query =
                    from H in historyPool
                    where H.getZid() == i
                    select H.getGrade();

                foreach (var g in Query)
                    total += getAsciiValue(g);
                gradePool.Add(i, total);
            }

            foreach (KeyValuePair<uint, decimal> kvp in gradePool)
            {
                query_ListBox.Items.Add(kvp.Key + " " + kvp.Value);
            }

            int top4 = 1;
            while (top4 <= 4)
            {
                var keyR = gradePool.OrderBy(kvp => kvp.Value).First();
                query_ListBox.Items.Add("#" + top4 + " student: " + keyR.Key);
                gradePool.Remove(keyR.Key);
                top4++;
            }
        }
    }
}