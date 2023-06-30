using System;

namespace GPACalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==================Welcome to GPA Calculator==================================");
            Console.Write("How many course do you want to compute: ");
            var numberofCourses = int.Parse(Console.ReadLine());
            var courses = new Course[numberofCourses];
            while (numberofCourses > 0)
            {
                Console.Write("Enter course code: ");
                var courseCode = Console.ReadLine();
                Console.Write("Enter course unit: ");
                var courseUnit = Console.ReadLine();
                Console.Write("Enter your course score: ");
                var score = Console.ReadLine();
                var course = new Course
                {
                    CourseCode = courseCode,
                    CourseUnit = int.Parse(courseUnit),
                    Score = GetScoreDetails(double.Parse(score))
                };

                courses[numberofCourses - 1] = course;
                numberofCourses--;
            }
            var gpa = CalculateGPA(courses);

            Console.WriteLine("===================================================================================================");
            Console.WriteLine("|| CourseCode    ||   CreditUnit     ||   Score     ||      Grade   ||    GradePoint    ||");
            Console.WriteLine("===================================================================================================");

            for(int i = 0; i< courses.Length; i++)
            {
                Console.WriteLine("===================================================================================================");
                Console.WriteLine($"||{courses[i].CourseCode}\t\t||   {courses[i].CourseUnit} \t\t    ||   {courses[i].Score.CourseScore}     ||      {courses[i].Score.Grade}   ||    {courses[i].Score.GradeUnit}    ||");
                Console.WriteLine("===================================================================================================");
            }
            Console.WriteLine("Your calculated GPA is "+ gpa);

        }
        public static double CalculateGPA(Course[] courses)
        {
            var totalCreditUnit = 0d;
            var tcu = 0;
            for(int i = 0; i< courses.Length; i++)
            {
                totalCreditUnit +=  (courses[i].CourseUnit * courses[i].Score.GradeUnit);
                tcu += courses[i].CourseUnit;
            }
            var GPA = totalCreditUnit/tcu;
            return GPA;
        }
     
        public static Score GetScoreDetails(double score)
        {
            var courseScore = new Score();
            courseScore.CourseScore = score;
            switch (score)
            {
                case double n when (n < 40):
                    courseScore.Grade = 'F';
                    courseScore.GradeUnit = 1;
                    break;
                case double n when (n >= 40 && n < 50):
                    courseScore.Grade = 'D';
                    courseScore.GradeUnit = 2;
                    break;
                case double n when (n >= 50 && n < 60):
                    courseScore.Grade = 'c';
                    courseScore.GradeUnit = 3;
                    break;
                case double n when (n >= 60 && n < 70):
                    courseScore.Grade = 'B';
                    courseScore.GradeUnit = 4;
                    break;
                case double n when (n >= 70 && n < 100):
                    courseScore.Grade = 'A';
                    courseScore.GradeUnit = 5;
                    break;
            }
            return courseScore;
        }
    }
  
    

    class Course
    {
        public string CourseCode { get; set; }
        public int CourseUnit { get; set; }
        public Score Score { get; set; }
        
    }
    class Score
    {
        public double CourseScore { get; set; }
        public char Grade { get; set; }
        public int GradeUnit { get; set; }

    }
}

