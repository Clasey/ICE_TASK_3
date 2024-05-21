using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

delegate void EventHandle(object sender, EventArgs e);

namespace Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandle handler = new EventHandle(HandleEvent);

            handler(null, EventArgs.Empty);
        }

        static void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("Events Handled");
            Console.ReadLine();
        }
    }

    class Button
    {
        public event EventHandler Click;

        public void ClickButtin()
        {
            Click?.Invoke(this, EventArgs.Empty);
            Console.ReadLine();
        }
    }

    static void Main(string [] args)
    {
        Button button = new Button();

        button.Click += Button_Click;

        button
    }
}
