using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using IncludeEngenharia.Models;
using System.Collections.ObjectModel;
using Prism.Services;
using SQLite;
//using SQLite.Net;

namespace IncludeEngenharia.ViewModels
{
    public class ContatoPageViewModel : ViewModelBase
    {

        public IPageDialogService _dialogService { get; set; }

        public DelegateCommand<string> NavigateCommand { get; }

        public ObservableCollection<Contato> _listaContato;

        public ObservableCollection<Contato> _listViewlistaContato;



        public ContatoPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
                                    : base(navigationService)
        {

            _dialogService = dialogService;

            listaContato = new ObservableCollection<Contato>() { };
            ListViewlistaContato = listaContato;

            NavigateCommand = new DelegateCommand<string>(OnNavigateCommandExecuted);
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            OnNavigatingToAsync(parameters);
        }

        public void OnNavigatingToAsync(NavigationParameters parameters)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Contato>();
                var posts = conn.Table<Contato>().ToList();
                listaContato = new ObservableCollection<Contato>(posts);
                ListViewlistaContato = listaContato;
            }
        }

        private async void OnNavigateCommandExecuted(string path)
        {
            await _navigationService.NavigateAsync(path);
        }


        private string _SearchText;
        public string SearchText
        {
            get { return _SearchText; }
            set
            {
                SetProperty(ref _SearchText, value);
                On_SearchTextChanged();
            }
        }

        private void On_SearchTextChanged()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                ListViewlistaContato = listaContato;
            }

            else
            {
                var filter = listaContato.Where(c => c.Nome_Lead.ToLower().Contains(SearchText.ToLower())).ToList();
                ListViewlistaContato = new ObservableCollection<Contato>(filter);
            }
        }

        public ObservableCollection<Contato> listaContato
        {
            get { return _listaContato; }
            set { SetProperty(ref _listaContato, value); }
        }
        public ObservableCollection<Contato> ListViewlistaContato
        {
            get { return _listViewlistaContato; }
            set { SetProperty(ref _listViewlistaContato, value); }
        }


    }
}
