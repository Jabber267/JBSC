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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JBSC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            
            // Prevent app from covering the taskbar
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;


        }

        private void cvsTopPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnMaxRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == System.Windows.WindowState.Maximized)
            {
                WindowState = System.Windows.WindowState.Normal;
                imgBtnMaxRestore.Source = new BitmapImage(new Uri(@"\images\1024x1024_ButtonRestore.png", UriKind.Relative));
            }
            else
            {
                WindowState = System.Windows.WindowState.Maximized;
                imgBtnMaxRestore.Source = new BitmapImage(new Uri(@"\images\1024x1024_ButtonMinMax.png", UriKind.Relative));
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("TODO: Settings");
            // TODO: Add settins
        }

        private void btnSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            imgBtnSearch.Source = new BitmapImage(new Uri(@"\images\800x600_ButtonMagnifyingGlassShadow.png", UriKind.Relative));
        }

        private void btnSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            imgBtnSearch.Source = new BitmapImage(new Uri(@"\images\800x600_ButtonMagnifyingGlass.png", UriKind.Relative));
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("TODO: Create search funtionality");
            // TODO: Add search functionality
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("TODO: Implement \"Go Back\"");
            // TODO: Add undo/previous functionality
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult msg = MessageBox.Show("TODO: Implement Undo/Previous");
            // TODO: Add back functionality
        }

        private void txbSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txbSearch.Text.ToLower() == "search")
            {
                txbSearch.Clear();
                txbSearch.FontStyle = FontStyles.Normal;
                this.Foreground = Brushes.Black;
            }
        }

        private void txbSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txbSearch.Text.ToLower() == "")
            {
                txbSearch.Text = "Search";
                txbSearch.FontStyle = FontStyles.Italic;
                this.Foreground = Brushes.Gray;
            }
        }
    }

    public class PlaceholderTextbox : TextBox
    {
        bool isPlaceHolder = true;
        string _placeHolderText;
        public string PlaceHolderText
        {
            get { return _placeHolderText; }
            set
            {
                _placeHolderText = value;
                setPlaceholder();
            }
        }

        //when the control loses focus, the placeholder is shown
        private void setPlaceholder()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.Text = PlaceHolderText;
                this.Foreground = Brushes.Gray;
                this.FontStyle = FontStyles.Italic;
                isPlaceHolder = true;
            }
        }

        //when the control is focused, the placeholder is removed
        private void removePlaceHolder()
        {

            if (isPlaceHolder)
            {
                this.Text = "";
                this.Foreground = Brushes.Black;
                this.FontStyle = FontStyles.Normal;
                isPlaceHolder = false;
            }
        }

        public void PlaceHolderTextBox()
        {
            GotFocus += removePlaceHolder;
            LostFocus += setPlaceholder;
        }

        private void setPlaceholder(object sender, EventArgs e)
        {
            setPlaceholder();
        }

        private void removePlaceHolder(object sender, EventArgs e)
        {
            removePlaceHolder();
        }
    }

}
