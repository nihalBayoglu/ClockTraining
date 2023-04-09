using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClockTraining.CustomControls
{
    public class AnalogClock : Control //Bu satır bize xaml sayfasından bu class'ı çağırmayı sağlar.Control class'ından kalıtım aldığmz için
    {
        private Line hourHand;
        private Line minuteHand;
        private Line secondHand;
        static AnalogClock()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
        }

        public override void OnApplyTemplate()
        {
            hourHand = Template.FindName("PART_HourHand", this) as Line;
            minuteHand = Template.FindName("PART_MinuteHand", this) as Line;
            secondHand = Template.FindName("PART_SecondHand", this) as Line;

            UpdateHandAngles();

            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += (s, e) => UpdateHandAngles();
            dispatcherTimer.Start();


            base.OnApplyTemplate();
        }

        private void UpdateHandAngles()
        {
            hourHand.RenderTransform = new RotateTransform(DateTime.Now.Hour / 12.0 * 360, 0.5, 0.5);
            minuteHand.RenderTransform = new RotateTransform(DateTime.Now.Minute / 60.0 * 360, 0.5, 0.5);
            secondHand.RenderTransform = new RotateTransform(DateTime.Now.Second / 60.0 * 360, 0.5, 0.5);
        }
    }
}
