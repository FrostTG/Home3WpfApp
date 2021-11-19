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
            List<string> styles = new List<string>() { "Светлая тема", "Темная тема" };
            styleBox.ItemsSource = styles;
            styleBox.SelectionChanged += ThemeChange;
            styleBox.SelectedIndex = 0;
        }

        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            int styleIndex = styleBox.SelectedIndex;
            Uri uri = new Uri("Light.xaml", UriKind.Relative);
            if (styleIndex == 1)
            {
                uri = new Uri("Dark.xaml", UriKind.Relative);
            }
            ResourceDictionary resource = App.LoadComponent(uri) as ResourceDictionary;
            //Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resource);

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (tBox != null)
            {
                tBox.FontFamily = new FontFamily(fontName);
            }
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = ((sender as ComboBox).SelectedItem as string);
            if (tBox != null)
            {
                tBox.FontSize = Convert.ToDouble(fontSize);
            }
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                tBox.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, tBox.Text);
            }
        }

        private void RedExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            tBox.Foreground = Brushes.Red;
        }

        private void BlackExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            tBox.Foreground = Brushes.Black;
        }

        private void UnderlineExecuted(object sender, ExecutedRoutedEventArgs e)
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

        private void ItalicExecuted(object sender, ExecutedRoutedEventArgs e)
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

        private void BoldExecuted(object sender, ExecutedRoutedEventArgs e)
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
    }
}
