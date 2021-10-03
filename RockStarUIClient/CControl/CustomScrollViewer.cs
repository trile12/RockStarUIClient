using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RockStarUIClient.CControl
{
    public class CustomScrollViewer : ScrollViewer
    {


        public double MyOffet
        {
            get { return (double)GetValue(ScrollViewer.HorizontalOffsetProperty); }
            set { this.ScrollToHorizontalOffset(value); }
        }

        // Using a DependencyProperty as the backing store for MyOffet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyOffetProperty =
            DependencyProperty.Register("MyOffet", typeof(double), typeof(CustomScrollViewer), new PropertyMetadata(new PropertyChangedCallback(Onchanged)));

        private static void Onchanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomScrollViewer)d).MyOffet = (double)e.NewValue;
        }
    }
}
