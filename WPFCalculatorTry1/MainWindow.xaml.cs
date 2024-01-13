using System;
using System.Collections.Generic;
using System.Data;
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

namespace WPFCalculatorTry1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement element in Buttons.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += ButtonClick;
                }
            }
        }

        private void ButtonClick(Object sender, RoutedEventArgs e)
        {
            try
            {
                string TextButton = ((Button)e.OriginalSource).Content.ToString();

                //string TextButton = ((Button)e.OriginalSource).Content.ToString();

                if (TextButton == "Clear all")
                {
                    text.Clear();
                }
                else if (TextButton == "Save last")
                {
                    text.Text = text.Text.Substring(text.Text.Length - 1);
                }
                else if (TextButton == "=")
                {
                    text.Text = new DataTable().Compute(text.Text, null).ToString();
                }
                else text.Text += TextButton;
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
