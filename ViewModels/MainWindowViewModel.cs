using Prism.Commands;
using Prism.Mvvm;

namespace PrismPractice.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        // ボタン名
        private string _leftButtonName = "はい";
        public string LeftButtonName
        {
            get => _leftButtonName;
        }

        private string _centerButtonName = "戻る";
        public string CenterButtonName
        {
            get => _centerButtonName;
        }

        private string _rightButtonName = "いいえ";
        public string RightButtonName
        {
            get => _rightButtonName;
        }

        // ボタンの表示非表示
        public bool _leftButtonVisibled = true;
        public bool LeftButtonVisibled
        {
            get { return _leftButtonVisibled; }
            set { SetProperty(ref _leftButtonVisibled, value); }
        }

        public bool _centerButtonVisibled = false;
        public bool CenterButtonVisibled
        {
            get { return _centerButtonVisibled; }
            set { SetProperty(ref _centerButtonVisibled, value); }
        }

        public bool _rightButtonVisibled = true;
        public bool RightButtonVisibled
        {
            get { return _rightButtonVisibled; }
            set { SetProperty(ref _rightButtonVisibled, value); }
        }

        // ボタン押下時のイベント
        public DelegateCommand LeftCommand { get; }

        public DelegateCommand CenterCommand { get; }

        public DelegateCommand RightCommand { get; }

        // 表示テキスト
        private static string WEATHER_QUESTION_STR = "こんにちは。今日の天気は良いですか？";
        private string _message= WEATHER_QUESTION_STR;
        
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public MainWindowViewModel()
        {
            LeftCommand = new DelegateCommand(DoLeft);
            CenterCommand = new DelegateCommand(DoCenter);
            RightCommand = new DelegateCommand(DoRight);
        }

        private void DoLeft()
        {
            Message = "それは良かったです！気分が良いですね。";
            LeftButtonVisibled = false;
            RightButtonVisibled = false;
            CenterButtonVisibled = true;
        }

        private void DoCenter()
        {
            Message = WEATHER_QUESTION_STR;
            LeftButtonVisibled = true;
            RightButtonVisibled = true;
            CenterButtonVisibled = false;
        }

        private void DoRight()
        {
            Message = "あら、それは残念ですね。";
            LeftButtonVisibled = false;
            RightButtonVisibled = false;
            CenterButtonVisibled = true;
        }
    }
}
