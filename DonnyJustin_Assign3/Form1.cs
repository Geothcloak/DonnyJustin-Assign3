﻿///////////////////////////////////////
/// Donny Kapic z1855273
/// Justin Roesner z1858242
/// CSCI 473 .NET programming
/// Assign 3
///////////////////////////////////////
using System;
using System.Collections;
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

            // populate the majors in combobox
            foreach (string line in majorLines)
            {
                major_ComboBox.Items.Add((line));
            }

            /* EXTRA CREDIT
            topStudents();
            hardestClasses();
            */
        }

        // add items to grade_ComboBox
        private void addGrades(ComboBox box)
        {
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

        // Sort Courses alphabetically
        private List<Course> sortCourses(List<Course> coursePool)
        {
            var sortedCourses = coursePool.OrderBy(c => c.GetDepartmentCode()).ToList();
            return sortedCourses;
        }

        // print all the grades for a given ZID
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

            // run query based on zid and print results
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

        // print grades above or below specified threshold for a given class
        private void gradeThreshold_Button_Click(object sender, EventArgs e)
        {
            query_ListBox.Items.Clear();
            // get user input
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

            // run query
            if (classExists)
            {
                if (lessThan_RadioButton1.Checked)
                {
                    var Query =
                    from N in historyPool
                    where getAsciiValue(N.getGrade()) >= getAsciiValue(grade) && courseTokens[0] == N.getDept() && courseTokens[1] == N.getCourseNum().ToString()
                    select N.getZid() + "   " + N.getDept() + "    " + N.getCourseNum() + "     " + N.getGrade();

                    query_ListBox.Items.Add("Grade Threshold Report for (" + courseTokens[0] + " " + courseTokens[1] + ")");
                    query_ListBox.Items.Add("------------------------------------");

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
                }

                query_ListBox.Items.Add("### END RESULTS ###");
            }
            else
                query_ListBox.Items.Add("This class does not exist.");
        }

        // black magic
        private int getAsciiValue(string grade)
        {
            /* Get ascii value of letter grade
             * Multiply by 3 to make room for positive and negative grades
             * + subtracts 1
             * - adds 1 
             * This turns every letter grade variation into an integer
             * that can be used elsewhere in the program.
             */

            char letter = ' ';
            char sign = ' ';
            int asciiVal = 0;

            // get letter grade ascii value and multiply by 3
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

        // print grade report for a single course
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

        // print failure rate based on specified percentage
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

                // calculate failure rate
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

        // calculates # of students enrolled and # of students who failed
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

        // print pass rate based on specified letter grade
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
                // calculate pass rate
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

        // calculate $ of students enrolled and # of students who passed based on letter grade
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

        // ### EXTRA CREDIT ###
        // Determine the 4 smartest students.
        private void topStudents()
        {
            IDictionary<uint, decimal> gradePool = new Dictionary<uint, decimal>();
            List<uint> zidCheck = new List<uint>();

            // get list of unique zid
            foreach (var z in historyPool)
            {
                if (!zidCheck.Contains(z.getZid()))
                    zidCheck.Add(z.getZid());
            }
            
            // get total grade values for each student
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

            // find lowest total grade value and remove it from dictionary
            // lower grade total == better average grade (counter-intuitive, I know)
            int top4 = 1;
            while (top4 <= 4)
            {
                var keyR = gradePool.OrderBy(kvp => kvp.Value).First();
                query_ListBox.Items.Add("#" + top4 + " student: " + keyR.Key);
                gradePool.Remove(keyR.Key);
                top4++;
            }
        }

        // ### EXTRA CREDIT ###
        // Determine the 3 hardest classes.
        private void hardestClasses()
        {
            List<string> courseList = new List<string>();
            IDictionary<string, decimal> failRateDict = new Dictionary<string, decimal>();
            
            // get all the class names
            foreach (History h in historyPool)
            {
                string dept = h.getDept();
                string courseNum = h.getCourseNum().ToString();
                string course = dept + " " + courseNum;
                if (!courseList.Contains(course))
                    courseList.Add(course);
            }

            // find fail rate for each course
            foreach (var c in courseList)
            {
                int[] report = failReport(c);
                decimal numFailed = report[0];
                decimal numEnrolled = report[1];
                decimal failPercent = (numFailed / numEnrolled)*100;
                failRateDict.Add(c, failPercent);
            }

            var list =
                (from t in failRateDict
                 orderby t.Value descending
                 select t).Take(3);

            foreach (var i in list)
                query_ListBox.Items.Add(i);
        }

        // Print fails by students of a major button
        private void majorFails_Button_Click(object sender, EventArgs e)
        {
            //clear box
            query_ListBox.Items.Clear();

            //grab string for major
            string tempMajor = major_ComboBox.Text;

            //grab department and course number
            string course = courseFail_RichTextBox.Text;
            string[] courseTokens = course.Split(' ');

            //get only students of the given major
            var majorQuery =
                from S in studentPool
                where S.Value.getMajor().Equals(tempMajor)
                select S.Value.getZid();

            //get only the student history for the students of the given major
            var historyQuery =
                from Q in majorQuery
                join H in historyPool
                on Q equals H.getZid()
                //left combine only students of given major
                into combined
                from combined_group in combined
                where combined_group.getDept() == courseTokens[0] && courseTokens[1] == combined_group.getCourseNum().ToString()
                select new
                {
                    Zid = combined_group.getZid(),
                    Grade = combined_group.getGrade()
                };

            //get only the student id's of the students who have failed the course
            var onlyFails =
                from hQ in historyQuery
                where hQ.Grade == "F"
                select hQ.Zid;


            //print the students
            query_ListBox.Items.Add("Fail Report of Majors (" + tempMajor + ") in " + courseTokens[0] + " " + courseTokens[1]);
            query_ListBox.Items.Add("----------------------------------------------");

            foreach (var i in onlyFails)
            {
                query_ListBox.Items.Add("z" + i + "    |     " + courseTokens[0] + "-" + courseTokens[1] + "    |    " + "F");
            }
            query_ListBox.Items.Add(" ");
            query_ListBox.Items.Add("### END RESULTS ###");
        }
    }
}