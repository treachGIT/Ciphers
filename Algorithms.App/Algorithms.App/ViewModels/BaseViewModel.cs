using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.App.ViewModels
{
    public abstract class BaseViewModel
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected BaseViewModel()
		{

		}

		public virtual void Prepare()
		{

		}

		public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
		{
			if (Object.Equals(storage, value))
				return false;

			storage = value;
			OnPropertyChanged(propertyName);
			return true;
		}

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}


	}

	public abstract class BaseViewModel<TParameter> : BaseViewModel
	{
		public abstract void Prepare(TParameter parameter);
	}
}
