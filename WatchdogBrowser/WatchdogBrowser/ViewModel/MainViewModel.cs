using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using WatchdogBrowser.Models;

namespace WatchdogBrowser.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}            
            CreateMockupTabs();
        }


        private ObservableCollection<TabItemModel> tabs = new ObservableCollection<TabItemModel>();

        public ObservableCollection<TabItemModel> Tabs {
            get {
                return tabs;
            }
            set {
                tabs = value;
                RaisePropertyChanged("Tabs");
            }
        }


        private void CreateMockupTabs() {
            Tabs.Add(new TabItemModel { Title = "����� ���� 1", Url = "http://yandex.ru/" });
            Tabs.Add(new TabItemModel { Title = "�����", Url = "http://bash.im/" });
            Tabs.Add(new TabItemModel { Title = "������ ���", Url = "http://9gag.com/" });
            RaisePropertyChanged("Tabs");
        }
    }
}