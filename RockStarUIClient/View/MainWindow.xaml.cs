using RockStarUIClient.CControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RockStarUIClient.View
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

        private void home_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MediaElement_Ended(object sender, RoutedEventArgs e)
        {

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Restore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {

        }

        private void navRightBtn_Click(object sender, RoutedEventArgs e)
        {
            navRightBtn.IsEnabled = false;
            navLeftBtn.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(CustomScrollViewer.MyOffetProperty);
            DoubleAnimation goRight = new DoubleAnimation(offset, offset + 500 + 20, new Duration(TimeSpan.FromSeconds(.6)))
            {
                AccelerationRatio=.2,
                DecelerationRatio=.8
            };
            goRight.Completed += GoRight_Completed;
            scrollViewer.BeginAnimation(CustomScrollViewer.MyOffetProperty, goRight);
        }

        private void GoRight_Completed(object sender, EventArgs e)
        {
            navRightBtn.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == Convert.ToInt32(scrollViewer.ScrollableWidth))
                navRightBtn.Visibility = Visibility.Collapsed;
        }

        private void navLeftBtn_Click(object sender, RoutedEventArgs e)
        {
            navLeftBtn.IsEnabled = false;
            navRightBtn.Visibility = Visibility.Visible;

            double offset = (double)scrollViewer.GetValue(CustomScrollViewer.MyOffetProperty);
            DoubleAnimation goLeft = new DoubleAnimation(offset, offset - 500 - 20, new Duration(TimeSpan.FromSeconds(.6)))
            {
                AccelerationRatio = .2,
                DecelerationRatio = .8
            };
            goLeft.Completed += GoLeft_Completed; ;
            scrollViewer.BeginAnimation(CustomScrollViewer.MyOffetProperty, goLeft);
        }

        private void GoLeft_Completed(object sender, EventArgs e)
        {
            navLeftBtn.IsEnabled = true;
            if (Convert.ToInt32(scrollViewer.HorizontalOffset) == 0)
                navLeftBtn.Visibility = Visibility.Collapsed;
        }
    }
}
