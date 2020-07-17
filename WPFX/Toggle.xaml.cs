using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPFX {
    /// <summary>
    /// Toggle arguments.
    /// </summary>
    public class ToggleArgs {
        public ToggleArgs(bool t) { toggled = t; }
        public bool toggled { get; } // readonly
    }

    /// <summary>
    /// A toggle.
    /// </summary>
    public partial class Toggle : UserControl {

        /// <summary>
        /// A toggle event.
        /// </summary>
        public delegate void ToggleEvent(object sender, ToggleArgs e);

        /// <summary>
        /// Fires when the toggle is toggled.
        /// </summary>
        public virtual event ToggleEvent Toggled;

        /// <summary>
        /// ImageSource for the on state.
        /// </summary>
        public ImageSource OnImage;
        /// <summary>
        /// ImageSource for the off state.
        /// </summary>
        public ImageSource OffImage;

        // Used internally to keep track of the toggle's state.
        private bool state;

        public Toggle() {
            // Initialize the component
            InitializeComponent();
            // Set the out of the box images for the states
            if (OnImage == null) OnImage = new BitmapImage(new Uri("pack://application:,,,/WPFX;component/Resources/toggle_right.png"));
            if (OffImage == null) OffImage = new BitmapImage(new Uri("pack://application:,,,/WPFX;component/Resources/toggle_left.png"));
        }

        // Fires when the mouse button is clicked
        private void toggleImage_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            // Toggle the state
            state = !state;
            // Fire the toggle event
            InvokeToggle();
            // Change the toggle image
            toggleImage.Source = state ? OnImage : OffImage;
        }

        protected virtual void InvokeToggle() {
            Toggled?.Invoke(this, new ToggleArgs(state));
        }
    }
}
