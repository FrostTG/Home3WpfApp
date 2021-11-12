using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace Home3WpfApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (tBox != null)
            {
                tBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as TextBlock).Text;
            if (tBox != null)
            {
                tBox.FontSize = Convert.ToDouble(fontSize);
            }
        }
        private void bold_Click(object sender, RoutedEventArgs e)
        {
            if (tBox.FontWeight != FontWeights.Bold)
            {
                tBox.FontWeight = FontWeights.Bold;
            }
            else
            {
                tBox.FontWeight = FontWeights.Normal;
            }

        }

        private void italic_Click(object sender, RoutedEventArgs e)
        {
            if (tBox.FontStyle != FontStyles.Italic)
            {
                tBox.FontStyle = FontStyles.Italic;
            }
            else
            {
                tBox.FontStyle = FontStyles.Normal;
            }
        }

        private void underline_Click(object sender, RoutedEventArgs e)
        {
            if (tBox.TextDecorations != TextDecorations.Underline)
            {
                tBox.TextDecorations = TextDecorations.Underline;
            }
            else
            {
                tBox.TextDecorations = null;
            }
        }
        private void black_Click(object sender, RoutedEventArgs e)
        {
            tBox.Foreground = Brushes.Black;
        }

        private void red_Click(object sender, RoutedEventArgs e)
        {
            tBox.Foreground = Brushes.Red;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                tBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog()==true)
            {
                File.WriteAllText(saveFileDialog.FileName, tBox.Text);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
