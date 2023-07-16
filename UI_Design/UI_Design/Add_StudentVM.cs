using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;





namespace UI_Design
{
    public partial class Add_StudentVM:ObservableObject
    {
        [ObservableProperty]
        public BitmapImage selectedImage;

        [ObservableProperty]
        public int id;

        [ObservableProperty]
        public string firstname;

        [ObservableProperty]
        public string lastname;

        [ObservableProperty]
        public string dateofbirth;

        [ObservableProperty]
        public string gender;


        [ObservableProperty]
        public string email;

        [ObservableProperty]
        public string contactNo;


        [ObservableProperty]
        public string gpa;

        [ObservableProperty]
        public string title;

        public Student_Details Student { get; private set; }
        public Action CloseAction { get; internal set; }



        public Add_StudentVM(Student_Details student)
        {
            Student = student;

            selectedImage = Student.Image;
            id = Student.StudentID;
            firstname = Student.FirstName;
            lastname = Student.LastName;
            dateofbirth = Student.DateOfBirth;
            gender = Student.Gender;
            email = Student.Email;
            contactNo = Student.ContactNo;
            gpa = Student.GPA;


        }

        public Add_StudentVM()
        {
        }

      
        



        [RelayCommand]
        public void UploadPhoto()
        {
            OpenFileDialog opendialog = new OpenFileDialog();
            opendialog.Filter = "Image files | *.bmp; *.png; *.jpg";
            opendialog.FilterIndex = 1;
            if (opendialog.ShowDialog() == true)
            {
                selectedImage = new BitmapImage(new Uri(opendialog.FileName));
                         
                MessageBox.Show("Image successfuly uploded!");
            }
        }

        [RelayCommand]
        public void Save()
        {
            if(id.ToString().Length != 4)
            {
                MessageBox.Show("Student ID is incorrect!");
                return;

            }
            if (selectedImage == null)
            {
                MessageBox.Show("Image should upload.");
                return;

            }

            if (double.Parse(gpa) < 0 || double.Parse(gpa) > 4)
            {
                MessageBox.Show("GPA value must be between 0 and 4.");
                return;
            }
            if (contactNo.Length !=10)
            {
                MessageBox.Show("Insert Contact No Correctly.");
                return ;
            }
            if (Student == null)
            {
                Student = new Student_Details()
                {
                    Image = selectedImage,
                    StudentID = id,
                    FirstName = firstname,
                    LastName = lastname,
                    DateOfBirth =dateofbirth,
                    Gender = gender,
                    Email = email,
                    ContactNo = contactNo,
                    GPA = gpa,

                };

            }
            else
            {
                Student.Image = selectedImage;
                Student.StudentID = id;
                Student.FirstName = firstname;
                Student.LastName = lastname;
                Student.DateOfBirth = dateofbirth;
                Student.Gender = gender;
                Student.Email = email;
                Student.ContactNo = contactNo;
                Student.GPA = gpa;

            }
            if (Student.FirstName != null)
            {

                CloseAction();
            }

            Application.Current.MainWindow.Show();


        } 
    }
}
