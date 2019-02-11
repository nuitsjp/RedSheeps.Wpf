﻿using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
using Microsoft.Win32;

namespace RedSheeps.Wpf.Interactivity
{
    public class SaveFileAction : TriggerAction<DependencyObject>
    {
        #region Dependency Properties
        public static readonly DependencyProperty DefaultExtProperty = DependencyProperty.Register(
            "DefaultExt", typeof(string), typeof(SaveFileAction), new PropertyMetadata(default(string)));

        public string DefaultExt
        {
            get { return (string) GetValue(DefaultExtProperty); }
            set { SetValue(DefaultExtProperty, value); }
        }

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register("FileName", typeof(string), typeof(SaveFileAction), new PropertyMetadata(default(string)));

        public string FileName
        {
            get { return (string)GetValue(FileNameProperty); }
            set { SetValue(FileNameProperty, value); }
        }

        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register(
            "Filter", typeof(string), typeof(SaveFileAction), new PropertyMetadata(default(string)));

        public string Filter
        {
            get { return (string) GetValue(FilterProperty); }
            set { SetValue(FilterProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(SaveFileAction), new PropertyMetadata(default(string)));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(SaveFileAction), new PropertyMetadata(default(ICommand)));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        protected override void Invoke(object parameter)
        {
            if(Command != null && Command.CanExecute(null))
            {
                var dialog = new SaveFileDialog();
                dialog.DefaultExt = DefaultExt;
                dialog.FileName = FileName;
                dialog.Filter = Filter;
                dialog.Title = Title;
                if (dialog.ShowDialog() == true)
                {
                    Command.Execute(dialog.FileName);
                }
            }
        }
    }
}
