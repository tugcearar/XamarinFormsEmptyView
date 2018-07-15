using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XFEmptyViewSample.Models;

namespace XFEmptyViewSample.ViewModels
{
    public class ListViewPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private IList<Birds> birdsList;
        bool isRefreshing;
        private bool isEmpty;

        public bool IsEmpty
        {
            get { return isEmpty; } set { isEmpty = value; OnPropertyChanged(); }
            }
        public IList<Birds> BirdsList
        {
            get { return birdsList; }
            set { birdsList = value; OnPropertyChanged(); }
        }


        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }

            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public Command RefreshCommand { get; set; }
        public ListViewPageViewModel()
        {
            BirdsList = new ObservableCollection<Birds>();
            RefreshCommand = new Command(() => GetData());
            GetData();
        }

        void GetData()
        {
            IsRefreshing = true;
            birdsList.Clear();
            Random random = new Random();
            int number = random.Next(0, 4);
            for (int i = 0; i < number; i++)
            {
                BirdsList.Add(new Birds
                {
                    Title = "Quetzal",
                    Description = "The Quetzal are shockingly colored birds common in western Mexico and Guatemala. Historically, they were sacred to the Mayan and Aztec people, who believed that the Quetzal was the God of Air, and they used their green tail feathers in spiritual ceremonies. The bird inhabits the cold mountain woods, and during the dry seasons, it perches at a height of nearly 10,000 feet!",

                });
            }
            IsEmpty = BirdsList.Count == 0;
            IsRefreshing = false;
        }
    }
}