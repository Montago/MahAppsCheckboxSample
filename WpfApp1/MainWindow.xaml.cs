using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace WpfApp1
{
	public partial class MainWindow : MetroWindow
	{
		public List<Element> Elements { get; set; } = new List<Element>();

		public MainWindow()
		{
			InitializeComponent();

			var R = new Random();

			for (int i = 0; i < 100; i++)
			{
				var item = new Element 
				{ 
					Name = $"Elem {i}",
					Prop1 = R.Next(0, 1) == 1,
					Prop2 = R.Next(0, 1) == 1,
					Prop3 = R.Next(0, 1) == 1,
				};
				item.PropertyChanged += Item_PropertyChanged;
				Elements.Add(item);
			}
		}

		private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Debug.WriteLine((sender as Element).Name + ", " + e.PropertyName);
		}
	}

	public class Element : INotifyPropertyChanged
	{
		#region INotifyPropertyChanged

		public void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion

		public string Name { get; set; }

		#region Prop1 INPC Property
		private bool _Prop1;

		public bool Prop1
		{
			get { return _Prop1; }
			set { _Prop1 = value; OnPropertyChanged("Prop1"); }
		}
		#endregion

		#region Prop2 INPC Property
		private bool _Prop2;

		public bool Prop2
		{
			get { return _Prop2; }
			set { _Prop2 = value; OnPropertyChanged("Prop2"); }
		}
		#endregion

		#region Prop3 INPC Property
		private bool _Prop3;

		public bool Prop3
		{
			get { return _Prop3; }
			set { _Prop3 = value; OnPropertyChanged("Prop3"); }
		}
		#endregion
	}
}
