using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;
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
using CefSharp.Wpf;

namespace LAVTechWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool ctrl = false;
        bool shft = false;
        bool ctrlsActive = false;
        bool movAble = false;

        public MainWindow()
        {
            InitializeComponent();
            //Window.AllowsTransparencyProperty = true;
            //this.AddHandler(MouseDownEvent, Window_MouseDown(this, ));
            theOpacitySlider.Value = this.Opacity;
            this.Topmost = true;
            HideControls();
            
            //Default:youtube
            theBrowser.Address = "www.youtube.com";

            
        }
        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
              shft = true;
            if (e.Key == Key.LeftCtrl)
                ctrl = true;
            if(ctrlsActive&& e.Key == Key.LeftAlt)
                movAble = true;
           if (!ctrlsActive &&shft && ctrl)
                    ShowControls();
           else if (ctrlsActive&&e.Key == Key.OemTilde)   
                   ShutDown();

        }
        private void ShutDown() {
            Console.WriteLine("SHUTING DOWN!");
            App.Current.Shutdown();
        }

        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
            {
                shft = false;
                
            }
            if (movAble&& e.Key == Key.LeftAlt)
            {
                movAble = false;

            }
            if (e.Key == Key.LeftCtrl)
            {
                ctrl = false;
                HideControls();
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Button is down");
            
        }
        private void drag(object sender, MouseButtonEventArgs e)
        {
           
            if (movAble&& e.ChangedButton == MouseButton.Left)
                this.DragMove();
            if (ctrl) { }
        }
        private void drop(object sender, MouseButtonEventArgs e)
        {
            if (movAble && e.ChangedButton == MouseButton.Left)
                HideControls();

        }
        private void enter(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Mouse Entered the window");
            this.Topmost = true;
            if(ctrlsActive)
            this.BorderThickness = new Thickness(4d, 04d, 04d, 04d);
        }
        private void desert(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Mouse deserted the window");
            //if (ctrlsActive)
                this.BorderThickness = new Thickness(02d, 02d, 02d, 02d);
        }
        private void ShowControls() {
            //Window.AllowsTransparencyProperty = true;
            ctrlsActive = true; //avoids the spam of ctrls. 
            this.ResizeMode = System.Windows.ResizeMode.CanResizeWithGrip;

            //thi
            theMainButton.Visibility = Visibility.Visible;
            alexaimg.Visibility = Visibility.Visible;
            theOpacitySlider.Visibility = Visibility.Visible;

            this.BorderThickness = new Thickness(2d, 02d, 02d, 02d);
            //this.BorderBrush =
        }
        private void HideControls() {
            Console.WriteLine("CONTROLS HIDDEN");
            ctrlsActive = false;
            movAble = false;    
            //Window.ResizeModeProperty = NoResize;
            theMainButton.Visibility = Visibility.Hidden;
            alexaimg.Visibility = Visibility.Hidden;
            theOpacitySlider.Visibility = Visibility.Hidden;    

            this.ResizeMode=System.Windows.ResizeMode.NoResize;
            this.BorderThickness = new Thickness(0d, 0d, 0d, 0d);
            
        }

        private void theMainButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Support the developer </Alexandra>");
        }

        private void theOpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity= theOpacitySlider.Value;
        }
    }
}
