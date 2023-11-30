using System;
using System.IO;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;
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
            if (currentDirectory != System.IO.Path.GetPathRoot(currentDirectory))
            {
              currentDirectory = System.IO.Path.GetDirectoryName(currentDirectory);
              jsonPath = System.IO.Path.Combine(currentDirectory, "Previous_Information.json");
            }
            else
            {
              MessageBox.Show($"Error with path: {currentDirectory} is a root directory, and .json was not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          }
        }

        string jsonContent = File.ReadAllText(jsonPath);
        JsonDocument jsonDocument = JsonDocument.Parse(jsonContent);
        JsonElement root = jsonDocument.RootElement;
        if (root.TryGetProperty("date", out JsonElement displayTextElement))
        {
          string displayText = displayTextElement.GetString() ?? "ERROR: JSON DID NOT CONTAIN DATA";
          Date_TextBox.Text = displayText;
        }
        else
        {
          MessageBox.Show("Key 'displayText' not found in the JSON file.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Date_TextBox.Text = jsonContent;

        //MessageBox.Show($"Hi");
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
      }
    }
  }
}