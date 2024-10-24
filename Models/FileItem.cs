using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeDataGrid.Models
{
    public partial class FileItem : ObservableObject
    {
        [ObservableProperty]
        public string name;
        [ObservableProperty]
        public string path;
        [ObservableProperty]
        public long? size;
        [ObservableProperty]
        public int flag;
        [ObservableProperty]
        public ObservableCollection<FileItem> children;
    }
}
