using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Interop;
using System.Runtime.InteropServices;

namespace FtpClient
{
    public partial class WindowTemplate : ResourceDictionary
    {
        private bool flipWindow = false;
        double workHeight = SystemParameters.WorkArea.Height;
        double workWidth = SystemParameters.WorkArea.Width;

        public WindowTemplate()
        {
            InitializeComponent();
        }

        private void TopTitle_MouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://professorweb.ru");
        }

        #region "Сворачивание, разворачивание, закрытие, перетаскивание окна"
        private void closeWindow(object sender, RoutedEventArgs e)
        {
            Window win = (Window)((FrameworkElement)sender).TemplatedParent;
            win.Close();
        }

        private void minimizeWindow(object sender, RoutedEventArgs e)
        {
            Window win = (Window)((FrameworkElement)sender).TemplatedParent;
            win.WindowState = WindowState.Minimized;
        }

        private void maximizedWindow(object sender, RoutedEventArgs e)
        {
            Window win = (Window)((FrameworkElement)sender).TemplatedParent;
            Button btn = (Button)sender;

            if (!flipWindow)
            {
                flipWindow = true;
                win.Height = workHeight * 0.75;
                win.Width = workWidth * 0.75;
                win.Top = workHeight / 8;
                win.Left = workWidth / 8;
                btn.Content = Application.Current.FindResource("DataButtonMaximize");
            }
            else
            {
                flipWindow = false;
                win.Height = workHeight;
                win.Width = workWidth;
                win.Top = 0;
                win.Left = 0;
                btn.Content = Application.Current.FindResource("DataButtonMinimize");
            }
        }

        private void title_MouseMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window win = (Window)((FrameworkElement)sender).TemplatedParent;
            if (flipWindow)
                win.DragMove();
        }

        #endregion

        private void timeline_MouseMove(object sender, MouseEventArgs e)
        {
            FrameworkElement element = (FrameworkElement)sender;
            double x = e.GetPosition(element).X;
            ToolTip tt = (ToolTip)element.ToolTip;
            tt.HorizontalOffset = x - tt.ActualWidth / 2;
        }

    }
}
