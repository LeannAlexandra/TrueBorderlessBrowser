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
using System.Windows.Interop;

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

        //transparceny and clickthrough
        const int WS_EX_TRANSPARENT = 0x00000020;
        int WS_EX_NOT_TRANSPARENT = 0;
        const int GWL_EXSTYLE = (-20);
        IntPtr hwnd;


        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hwnd, int nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll")]
        private static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            hwnd = new WindowInteropHelper(this).Handle;

            //var hwnd = new WindowInteropHelper(this).Handle;
            //SetWindowExTransparent(hwnd);
        }
        public MainWindow()

        {
            InitializeComponent();
            //Window.AllowsTransparencyProperty = true;
            //this.AddHandler(MouseDownEvent, Window_MouseDown(this, ));
            theOpacitySlider.Value = this.Opacity;
            this.Topmost = true;
            HideControls();
            HideImgs();
            //Default:youtube
            theBrowser.Address = "www.youtube.com";

            //ToggleControls();//switches on controls
        }
        
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
              shft = true;
            if (e.Key == Key.LeftCtrl)
                ctrl = true;
            if (ctrlsActive && e.Key == Key.LeftAlt)
            {
                movAble = true;
                moveImg.Visibility = Visibility.Visible;
            }
            if (!ctrlsActive &&shft && ctrl)
                    ShowControls();
           else if (ctrlsActive&&e.Key == Key.OemTilde)   
                   ShutDown();

        }
        private void HideImgs() {
            netflix.Visibility = Visibility.Hidden;
            udemy.Visibility = Visibility.Hidden;
            youtube.Visibility = Visibility.Hidden;
        }

        private void Netflix_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HideImgs();
            //theBrowser.Address = "www.netflix.com";
            //Console.WriteLine("clicked the netflix");
        }
        private void Udemy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HideImgs();
            //theBrowser.Address = "www.udemy.com";
            //Console.WriteLine("clicked the netflix");
        }
        private void Youtube_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            HideImgs();
            //theBrowser.Address = "www.youtube.com";
            //Console.WriteLine("clicked the netflix");
        }


        private void ShutDown() {
            //Console.WriteLine("SHUTING DOWN!");
            App.Current.Shutdown();
        }

        private void OnKeyUpHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift)
            {
                shft = false;
                HideControls(false);//hides elements but not control.

            }
            if (movAble && e.Key == Key.LeftAlt)
            {
                movAble = false;
                moveImg.Visibility = Visibility.Hidden;

            }
            else
            {
                moveImg.Visibility = Visibility.Hidden;
            }
            if (e.Key == Key.LeftCtrl)
            {
                ctrl = false;
                HideControls(false);//hides elements but not control.
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //Console.WriteLine("Button is down");
            
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
                HideControls(false);

        }
        private void enter(object sender, MouseEventArgs e)
        {
            //Console.WriteLine("Mouse Entered the window");
            //this.Topmost = true;
            //if(ctrlsActive)
            //this.BorderThickness = new Thickness(4d, 04d, 04d, 04d);
        }
        private void desert(object sender, MouseEventArgs e)
        {
         //   Console.WriteLine("Mouse deserted the window");
            //if (ctrlsActive)
                this.BorderThickness = new Thickness(0d, 0d, 0d, 0d);
            HideControls();
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
            ToggleControls(WS_EX_NOT_TRANSPARENT);
            //this.BorderBrush =
        }
        private void HideControls(bool clickthr = true) {
            if (clickthr)
                ToggleControls(); 
            
            moveImg.Visibility = Visibility.Hidden;

            //Console.WriteLine("CONTROLS HIDDEN");
            ctrlsActive = false;
            movAble = false;    
            //Window.ResizeModeProperty = NoResize;
            theMainButton.Visibility = Visibility.Hidden;
            alexaimg.Visibility = Visibility.Hidden;
            theOpacitySlider.Visibility = Visibility.Hidden;    

            this.ResizeMode=System.Windows.ResizeMode.NoResize;
            this.BorderThickness = new Thickness(0d, 0d, 0d, 0d);

        }
        public void SetWindowExTransparent(IntPtr hwnd)
        {
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            WS_EX_NOT_TRANSPARENT |= extendedStyle;
            SetWindowLong(hwnd, GWL_EXSTYLE, extendedStyle | WS_EX_TRANSPARENT);
        }
        private void ToggleControls(int a= WS_EX_TRANSPARENT)
        {
            //var hwnd = new WindowInteropHelper(this).Handle;
            var extendedStyle = GetWindowLong(hwnd, GWL_EXSTYLE);
            //Console.WriteLine(extendedStyle.ToString());
             SetWindowLong(hwnd, GWL_EXSTYLE, a);
            
        }







        private void theMainButton_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Support the developer </Alexandra>");
        }

        private void theOpacitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.Opacity= theOpacitySlider.Value;
        }

        private void netflix_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
