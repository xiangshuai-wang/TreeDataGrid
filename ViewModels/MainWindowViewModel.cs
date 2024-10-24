using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TreeDataGrid.Models;

namespace TreeDataGrid.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        [ObservableProperty]
        public ObservableCollection<FileItem> files = new ObservableCollection<FileItem>();
        [ObservableProperty]
        public int flag;

        FileItem newFileItem = new FileItem()
        {
            Name = "A",
            Path = "/A",
            Size = 50,
            Flag = 0,
            Children = new ObservableCollection<FileItem>()
                {
                    new FileItem()
                    {
                        Name = "AA",
                        Path = "/AA",
                        Size = 51,
                        Flag = 0,
                        Children = new ObservableCollection<FileItem>()
                        {
                            new FileItem()
                            {
                                Name = "AAA",
                                Path = "/AAA",
                                Size = 51,
                                Flag = 0,
                            }
                        }
                    },
                    new FileItem()
                    {
                        Name = "AB",
                        Path = "/AB",
                        Size = 52,
                        Flag = 0,
                    },
                }
        };
        FileItem newFileItem2 = new FileItem()
        {
            Name = "B",
            Path = "/B",
            Size = 50,
            Flag = 1,
            Children = new ObservableCollection<FileItem>()
                {
                    new FileItem()
                    {
                        Name = "BA",
                        Path = "/BA",
                        Size = 51,
                        Flag = 1,
                    },
                    new FileItem()
                    {
                        Name = "BB",
                        Path = "/BB",
                        Size = 52,
                        Flag = 1,
                    },
                }
        };

        public MainWindowViewModel()
        {
            Flag = 0;
            Files.Add(newFileItem);
        }

        [RelayCommand]
        private void ChangeFiles()
        {
            if (Flag == 0)
            {
                Files.Clear();
                Flag = 1;
                Files.Add(newFileItem2);
            }
            else if (Flag == 1)
            {
                Files.Clear();
                Flag = 0;
                Files.Add(newFileItem);
            }
        }
    }
}
