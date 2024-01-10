using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using DemoStudentCRUD.Models;

namespace DemoStudentCRUD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly UniversityDBContext _context;

        //public MainWindow()
        //{
        //    InitializeComponent();
        //}
        public MainWindow()
        {
            _context = new UniversityDBContext();
            InitializeComponent();
            Load_data();
        }

        private void Load_data()
        {
            ListView.ItemsSource = _context.Students.ToList();
            cboMajor.ItemsSource = _context.Majors.ToList();
        }

        private void Load_Data(object sender, RoutedEventArgs e)
        {
            Load_data();
        }

        private void Delete_Student(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Student(object sender, RoutedEventArgs e)
        {

        }

        private void Create_Student(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Student_Up(object sender, MouseButtonEventArgs e)
        {

        }

        private void btnXML_Click(object sender, RoutedEventArgs e)
        {
            var xs = new XmlSerializer(typeof(XMLStudent));
            using Stream s2 = File.OpenRead("student.xml");
            var p2 = (XMLStudent)xs.Deserialize(s2);
            var p3 = p2;
        }
    }

    public class IdToMajor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            UniversityDBContext db = new UniversityDBContext();
            if (value is int MajorId)
            {
                var tmp = db.Majors.Where(x => x.MajorId == MajorId).FirstOrDefault();
                return tmp.MajorName;
            }
            return value;
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    [XmlRoot("StudentList")]
    public class XMLStudent
    {
        [XmlElement("StudentId")]
        public int StudentId { get; set; }
        [XmlElement("StudentName")]
        public string StudentName { get; set; } = null!;
        [XmlElement("DateOfBirth")]
        public DateOnly DateOfBirth { get; set; }
        [XmlElement("Gender")]
        public string Gender { get; set; } = null!;
        [XmlElement("PhoneNumber")]
        public string? PhoneNumber { get; set; }
        [XmlElement("MajorId")]
        public int? MajorId { get; set; }
    }
}
