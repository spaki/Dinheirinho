﻿using Dinheirinho.Repositories;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Push;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Dinheirinho
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        static DinheirinhoDatabase dinheirinhoDatabase;

        public static DinheirinhoDatabase DinheirinhoDatabase
        {
            get
            {
                if (dinheirinhoDatabase == null)
                    dinheirinhoDatabase = new DinheirinhoDatabase(
                        Path.Combine(
                            Environment.GetFolderPath(
                                Environment.SpecialFolder.LocalApplicationData
                            ), "DinheirinhoDatabase.db3"
                        )
                    );

                return dinheirinhoDatabase;
            }
        }

        protected override void OnStart()
        {
            base.OnStart();
            AppCenter.Start("[CHAVE AQUI!!!]", typeof(Push));
        }
    }
}
