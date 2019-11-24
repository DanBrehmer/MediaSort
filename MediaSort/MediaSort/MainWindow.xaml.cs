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
using System.ComponentModel;
using MediaSort.Helpers;
using MediaSort.Workers;

namespace MediaSort
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BrowseSourcePath_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    SourcePath.Text = dialog.SelectedPath;
                }
            }

        }

        private void BrowseDestinationPath_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = dialog.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    DestinationPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void StartSort_Click(object sender, RoutedEventArgs e)
        {
            bool abort = false;

            if (!Directory.Exists(SourcePath.Text))
            {
                MessageBox.Show("Choosen Source path does not exist.");
                abort = true;
            }

            if (!Directory.Exists(DestinationPath.Text))
            {
                MessageBox.Show("Choosen Destination path does not exist.");
                abort = true;
            }

            if (abort)
            {
                return;
            }
           
            SorterInfomation sorterInfo = 
                new SorterInfomation(SourcePath.Text,
                                     DestinationPath.Text);

            BackgroundWorker worker = new BackgroundWorker();
            SortingWorker sortingWorker = new SortingWorker();

            worker.WorkerReportsProgress = true;
            worker.DoWork += sortingWorker.worker_DoWork;
            worker.ProgressChanged += sortingWorker.worker_ProgressChanged;
            worker.RunWorkerCompleted += sortingWorker.worker_RunWorkerCompleted;
            worker.RunWorkerAsync(sorterInfo);
        }
    }
}
