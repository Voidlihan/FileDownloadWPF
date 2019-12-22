﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.IO;
using System.Threading;
using System.Windows.Threading;

namespace PotokFileDownload
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

        private void FileDownload(object sender, RoutedEventArgs e)
        {
            loadProgressBar.IsIndeterminate = true;
            Thread thread = new Thread(FileLoading);
            thread.IsBackground = true;
            thread.Priority = ThreadPriority.Lowest;
            thread.Start(textBoxUrl.Text);
        }
        private void FileLoading(object url) {
            WebClient webClient = new WebClient();
            var res = webClient.DownloadString(url.ToString());
            Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate () {
                loadProgressBar.IsIndeterminate = false;
            });
            MessageBox.Show("Загрузка выполнена!");
        }
    }
}
