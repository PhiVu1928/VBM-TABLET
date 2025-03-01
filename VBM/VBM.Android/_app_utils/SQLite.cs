﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VBM._app_utils;
using VBM.Droid._app_utils;
using Xamarin.Forms;

[assembly: Dependency(typeof(Android_SQLite))]
namespace VBM.Droid._app_utils
{
    public class Android_SQLite : ISQLite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var dbName = "OurDBStore.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            var path = System.IO.Path.Combine(dbPath, dbName);
            var conn = new SQLite.SQLiteConnection(path);
            return conn;
        }
    }
}