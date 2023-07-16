using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;



namespace UI_Design
{
    public partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection <Student_Details> student;
        [ObservableProperty]
        public Student_Details selectedStudent=null;
        
        
        
        public MainWindowVM()
        {

            student = new ObservableCollection<Student_Details>();
            BitmapImage image1 = new BitmapImage(new Uri("/Images/1.png", UriKind.Relative));
            student.Add(new Student_Details(image1, 4024, "Yasas", "Wijerathna", "12/12/2000", "Male", "yasas1234@mail", "0777569556", "3.58"));
            BitmapImage image2 = new BitmapImage(new Uri("/Images/2.png", UriKind.Relative));
            student.Add(new Student_Details(image2, 4158, "Visula", "Dunusinghe", "12/12/2000", "Male", "dunu9724@mail", "0772458759", "3.21"));
            BitmapImage image3 = new BitmapImage(new Uri("/Images/3.png", UriKind.Relative));
            student.Add(new Student_Details(image3, 4312, "Pawan", "Bandaragama", "12/12/2000", "Male", "pbandara10@mail", "0777564582", "3.01"));
            BitmapImage image4 = new BitmapImage(new Uri("/Images/4.png", UriKind.Relative));
            student.Add(new Student_Details(image4, 4257, "Nipuni", "Wijesekara", "12/12/2000", "Female", "nipuniwije@mail", "0701245878", "3.11"));
            BitmapImage image5 = new BitmapImage(new Uri("/Images/5.png", UriKind.Relative));
            student.Add(new Student_Details(image5, 4156, "Sathsara", "Senanayaka", "12/12/2000", "Male", "sathsara1199@mail", "0777536894","3.40"));


        }

         public void CloseMainWindow()
        {
            Application.Current.MainWindow.Close();
        }



        [RelayCommand]
        public void AddStudent()
        {
            var newWindow = new Add_StudentVM();
            newWindow.title = "Add Student";
            Add_StudentWindow window = new Add_StudentWindow(newWindow);
            window.ShowDialog();
            if (newWindow.Student.StudentID != null)
            {
                student.Add(newWindow.Student);
                 
            }

        }

        [RelayCommand]
        public void EditStudent()
        {
            if(selectedStudent != null)
            {
                var newWindow = new Add_StudentVM(selectedStudent);
                newWindow.title = "Edit Student";
                Add_StudentWindow window = new Add_StudentWindow(newWindow);
                window.ShowDialog();

                int select = student.IndexOf(selectedStudent);
                student.RemoveAt(select);
                student.Insert(select, newWindow.Student);



            }
            else
            {
                MessageBox.Show("Please Select the Student!");
            }

        }

        [RelayCommand]
        public void DeleteStudent()
        {
            if (selectedStudent != null)
            {
                int id = selectedStudent.StudentID;
                student.Remove(selectedStudent);
                MessageBox.Show($" Student {id} is deleted successfully!");

             
            }
            else
            {
                MessageBox.Show("Please Select the Student!");
            }

        }


    }
}
