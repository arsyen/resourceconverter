using Microsoft.Win32;
using NLog;
using System;
using System.IO;
using System.Windows;
using ResourceConverter.Core;

namespace ResourceConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IResourceConverter resourceConverter;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MainWindow(IResourceConverter resourceConverter)
        {
            InitializeComponent();
            this.resourceConverter = resourceConverter;
        }
        
        private void btnChooseSource_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                txtFileFrom.Text = openFileDialog.FileName;
            }
        }

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileFrom.Text))
            {
                MessageBox.Show("Source file is missing. Please select source file");
                return;
            }
            else if (string.IsNullOrEmpty(txtFileTo.Text))
            {
                MessageBox.Show("Destination file is missing. Please enter destination file path");
                return;
            }

            try
            {
                ITextTranslator translator = TextTranslatorFactory.GetTranslator(TranslatorType.EngToHsilgne);

                resourceConverter.Convert(txtFileFrom.Text, txtFileTo.Text, translator);
                
                txtFileFrom.Text = null;
                txtFileTo.Text = null;
                MessageBox.Show("Successfully converted");
            }
            catch (IOException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("You don't have permissions to write to destination path." +
                    "Please select other path or run application as Administrator");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something wrong happened. Plese try again later");
                logger.Error($"{ex.Message}  |  {ex.StackTrace}");
            }
        }
    }
}
