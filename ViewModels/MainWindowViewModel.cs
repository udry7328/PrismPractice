using System;
using System.CodeDom;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismPractice.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // ボタンの表示非表示
        // ----------------------------------------------------------------------
        public bool _yesButtonVisibled = true;
        public bool YesButtonVisibled
        {
            get { return _yesButtonVisibled; }
            set { SetProperty(ref _yesButtonVisibled, value); }
        }

        public bool _noButtonVisibled = true;
        public bool NoButtonVisibled
        {
            get { return _noButtonVisibled; }
            set { SetProperty(ref _noButtonVisibled, value); }
        }

        public bool _returnButtonVisibled = false;
        public bool ReturnButtonVisibled
        {
            get { return _returnButtonVisibled; }
            set { SetProperty(ref _returnButtonVisibled, value); }
        }
        // ----------------------------------------------------------------------

        private static string WEATHER_QUESTION_STR = "こんにちは。今日の天気は良いですか？";
        private string _message = WEATHER_QUESTION_STR;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public DelegateCommand YesCommand {get;}
        public DelegateCommand NoCommand {get;}

        public DelegateCommand ReturnCommand { get; }

        public MainWindowViewModel()
        {
            YesCommand = new DelegateCommand(DoYes);
            NoCommand = new DelegateCommand(DoNo);
            ReturnCommand = new DelegateCommand(DoReturn);
        }

        private void DoYes()
        {
            Message = "それは良かったです！気分が良いですね。";
            YesButtonVisibled = false;
            NoButtonVisibled = false;
            ReturnButtonVisibled = true;
        }

        private void DoNo()
        {
            Message = "あら、それは残念ですね。";
            YesButtonVisibled = false;
            NoButtonVisibled = false;
            ReturnButtonVisibled = true;
        }

        private void DoReturn()
        {
            Message = WEATHER_QUESTION_STR;
            YesButtonVisibled = true;
            NoButtonVisibled = true;
            ReturnButtonVisibled = false;
        }
    }
}
