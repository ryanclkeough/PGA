using System;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PGA_Document_Creation
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
      LoadData();
    }

    private void LoadData()
    {
      try
      {
        string currentDirectory = Directory.GetCurrentDirectory();
        string jsonPath = System.IO.Path.Combine(currentDirectory, "Previous_Information.json");

        while (currentDirectory != null)
        {
          if (File.Exists(jsonPath))
          {
            break;
          }
          else
          {
            currentDirectory = System.IO.Path.GetDirectoryName(currentDirectory);
            jsonPath = System.IO.Path.Combine(currentDirectory, "Previous_Information.json");
          }
        }

        string jsonContent = File.ReadAllText(jsonPath);
        //JSObject jsonData = JSObject.Parse(jsonContent);
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}