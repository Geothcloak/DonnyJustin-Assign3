using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DonnyJustin_Assign3
{
    class History
    {
        private uint zid;
        private string dept;
        private int courseNum;
        private string grade;

        public History()
        {
            zid = 0;
            dept = "";
            courseNum = 0;
            grade = "";
        }

        public History(string line)
        {
            // prase line with ',' as deliminator
            string[] tokens = line.Split(',');

            // convert/set values
            uint id = Convert.ToUInt32(tokens[0]);
            int num = Convert.ToInt16(tokens[2]);

            setZid(id);
            setDept(tokens[1]);
            setCourseNum(num);
            setGrade(tokens[3]);
        }

        //set zid
        public void setZid(uint zid)
        {
            this.zid = zid;
        }

        //set dept
        public void setDept(string dept)
        {
            bool isUpper;

            // check for 4 characters
            if (dept.Length > 4)
                throw new System.ArgumentException("Deparment code must be at most 4 characters.");

            //at most 4 characters all capitalized
            for (int i = 0; i < dept.Length; i++)
            {
                // check for upper case
                if (!(isUpper = Char.IsUpper(dept, i)))
                    throw new System.ArgumentException("All department code characters must be capitalized.");
            }
            
            this.dept = dept;
        }

        //set courseNum
        public void setCourseNum(int courseNum)
        {
            // range[100,499]
            if (courseNum < 100 || courseNum > 499)
                throw new System.ArgumentException("Course number must be in the range [100, 499]");
            else
                this.courseNum = courseNum;
        }

        //set grade
        public void setGrade(string grade)
        {
            this.grade = grade;
        }

        //get zid
        public uint getZid()
        {
            return this.zid;
        }

        //get dept
        public string getDept()
        {
            return this.dept;
        }
        
        //get courseNum
        public int getCourseNum()
        {
            return this.courseNum;
        }
        
        //get grade
        public string getGrade()
        {
            return this.grade;
        }
    }
}
