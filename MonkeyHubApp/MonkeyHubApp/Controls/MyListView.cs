﻿using System.Windows.Input;
using Xamarin.Forms;

namespace MonkeyHubApp.Controls
{
    public class MyListView: ListView
    {
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create("ItemTappedCommand", typeof(ICommand), typeof(MyListView), null);


        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set
            {
                SetValue(ItemTappedCommandProperty, value);
            }
        }

        public MyListView(ListViewCachingStrategy strategy) :base(strategy)
        {
            Initialize();
        }

        //cada celular vai ter o conteudo atualizado RecycleElement
        public MyListView() : this(ListViewCachingStrategy.RecycleElement)
        {
            Initialize();
        }

        private void Initialize()
        {
            this.ItemSelected += (sender, e) =>
            {
                if (ItemTappedCommand == null) return;

                if (ItemTappedCommand.CanExecute(e.SelectedItem))
                    ItemTappedCommand.Execute(e.SelectedItem);
            };
        }

    }
}
