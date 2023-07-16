using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace UI_Design
{
    public class Student_Details
    {
        public BitmapImage Image { get; set; }
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; } 
        public string GPA { get; set; }

        public Student_Details(BitmapImage image, int studentID, string firstName, string lastName, string dateOfBirth, string gender, string email, string contactNo, string gPA)
        {
            Image = image;
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Email = email;
            ContactNo = contactNo;
            GPA = gPA;
        }

        public Student_Details()
        {
        }

        public string ImageUrl
        {
            get { return $"/Images/{Image}"; }
        }
        
    }
}
