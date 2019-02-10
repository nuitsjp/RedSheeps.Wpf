﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace RedSheeps.Wpf.Interactivity
{
    public class OpenFilesAction : TriggerAction<DependencyObject>
    {
        #region Dependency Properties
        public static readonly DependencyProperty DefaultExtProperty = DependencyProperty.Register(
            "DefaultExt", typeof(string), typeof(OpenFilesAction), new PropertyMetadata(default(string)));

        public string DefaultExt
        {
            get { return (string)GetValue(DefaultExtProperty); }
            set { SetValue(DefaultExtProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register(
            "Filter", typeof(string), typeof(OpenFilesAction), new PropertyMetadata(default(string)));

        public string Filter
        {
            get { return (string)GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(OpenFilesAction), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(OpenFilesAction), new PropertyMetadata(default(ICommand)));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        #endregion

        protected override void Invoke(object parameter)
        {
            if (Command != null && Command.CanExecute(null))
            {
                var dialog = new OpenFileDialog();
                dialog.DefaultExt = DefaultExt;
                dialog.Filter = Filter;
                dialog.Title = Title;
                dialog.Multiselect = true;
                if (dialog.ShowDialog() == true)
                {
                    Command.Execute(dialog.FileNames);
                }
            }
        }
    }
}