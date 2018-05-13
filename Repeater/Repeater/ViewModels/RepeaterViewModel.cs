using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Repeater.ViewModels
{
	public class RepeaterViewModel : INotifyPropertyChanged
	{
		private List<string> repeatItems;
        
		public List<string> RepeatItems
		{
			get => repeatItems;
			set
			{
				repeatItems = value;
				OnPropertyChanged();
			}
		}

		private int repeatCount = 1;



		public int RepeatCount
		{
			get => repeatCount;
			set
			{
				repeatCount = value;
				RepeatItems.Clear();
				InitRepeatItems();

				OnPropertyChanged();
			}
		}


		public RepeaterViewModel()
		{
			RepeatItems = new List<string>();
			InitRepeatItems();

		}

		private void InitRepeatItems()
		{
			for (int i = 0; i < RepeatCount; i++)
			{
				RepeatItems.Add(i.ToString());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
