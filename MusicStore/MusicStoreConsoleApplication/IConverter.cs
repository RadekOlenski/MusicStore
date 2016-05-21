﻿using MusicStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreConsoleApplication
{
    interface IConverter
    {
        void writeObject(object obj, string path);

        void writeCollection(List<Client> collection, string path);
        void writeCollection(ObservableCollection<Transaction> collection, string path);
        void writeCollection(Dictionary<int, Product> collection, string path);

        Product readProduct(string path);
        Transaction readTransaction(string path);
        Client readClient(string path);
        List<object> readList(string path);
        ObservableCollection<object> readObservableCollection(string path);
        Dictionary<int, object> readDictionary(string path);

    }
}
