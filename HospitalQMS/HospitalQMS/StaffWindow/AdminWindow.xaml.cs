using ClosedXML.Excel;
using HospitalQMS.DAO;
using HospitalQMS.Models;
using HospitalQMS.StaffWindow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.DirectoryServices;
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
using System.Windows.Shapes;

namespace HospitalQMS
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void btnOldPatient_Click(object sender, RoutedEventArgs e)
        {
            GetPatientWindow getPatientWindow = new GetPatientWindow();
            getPatientWindow.ShowDialog();
        }

        private void btnNewPatient_Click(object sender, RoutedEventArgs e)
        {
            AddPatientWindow addPatientWindow = new AddPatientWindow();
            addPatientWindow.ShowDialog();

        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                IEnumerable<Patient> items = _context.Patients.ToList();

                using var wb = new XLWorkbook();
                var ws = wb.AddWorksheet();

                // Inserts the collection to Excel as a table with a header row.
                ws.Cell("A1").InsertTable(items);

                // Adjust column size to contents.
                ws.Columns().AdjustToContents();

                // Open save file dialog to get the file path from the user
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.FileName = $"Export - {DateTime.UtcNow:yyyyMMddHHmmss}.xlsx";

                if (saveFileDialog.ShowDialog() == true)
                {
                    // Save to the selected file path.
                    wb.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Patient data exported successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HospitalQMSContext _context = new HospitalQMSContext();
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                openFileDialog.Multiselect = false;

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;

                    using (var wb = new XLWorkbook(filePath))
                    {
                        var ws = wb.Worksheet(1); // Assuming data is on the first worksheet

                        // Assuming the data starts from cell A1 and has a header row
                        var range = ws.RangeUsed();

                        // Convert the Excel range to a DataTable
                        var dataTable = range.AsTable().AsNativeDataTable();

                        foreach (System.Data.DataRow row in dataTable.Rows)
                        {
                            if (!string.IsNullOrEmpty(row["Name"].ToString()) &&
                                !string.IsNullOrEmpty(row["DateOfBirth"].ToString()) &&
                                !string.IsNullOrEmpty(row["CCNumber"].ToString()) &&
                                DateTime.TryParse(row["DateOfBirth"].ToString(), out DateTime dateOfBirth))
                            {
                                var patient = new Patient
                                {
                                    // Assuming your columns are named "Name", "DateOfBirth", etc.
                                    Pname = row["Name"].ToString(),
                                    DateOfBirth = dateOfBirth,
                                    Status = "Deactive",
                                    Ccnumber = row["CCNumber"].ToString()
                                };

                                _context.Patients.Add(patient);
                            }
                        }

                        // Save changes to the database
                        _context.SaveChanges();

                        MessageBox.Show("Patient data imported successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
