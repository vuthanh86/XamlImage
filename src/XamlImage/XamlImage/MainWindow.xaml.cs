using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace XamlImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public DrawingImage MyImage
        {
            get
            {
                string path = "Images/MyVectorContent.xaml";

                StreamResourceInfo sri = Application.GetResourceStream(new Uri(path, UriKind.Relative));
                if (sri != null)
                {
                    using (Stream stream = sri.Stream)
                    {
                        var logo = XamlReader.Load(stream) as DrawingImage;

                        if (logo != null)
                        {
                            return logo;
                        }
                    }
                }
                throw new Exception("Resource not found");
            }
        }
    }
}
