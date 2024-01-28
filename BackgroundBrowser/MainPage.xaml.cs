namespace BackgroundBrowser {
    public partial class MainPage : ContentPage {

        private const string YOUTUBE_SOURCE = "https://www.youtube.com/";

        protected string DisplayWebViewSource = YOUTUBE_SOURCE;

        public MainPage() {
            InitializeComponent();

            this.InitializeWebView(); // DisplayWebView の初期化

            // TODO Android で、バックグラウンド実行可能にする。
            // バックグラウンドで、音の出力を許可させる

            // AdBlocker を有効化させる
        }

        /// <summary>
        /// DisplayWebView を初期化
        /// </summary>
        protected void InitializeWebView() {
            // 初期表示は、youtube を表示
            this.DisplayWebView.Source = YOUTUBE_SOURCE;

            // DisplayWebView.Property 変更イベント
            this.DisplayWebView.PropertyChanged += DisplayWebView_PropertyChanged;
        }

        /// <summary>
        /// DisplayWebView の .Source 変更時イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisplayWebView_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {

            // TODO WebViewSource.SourceChanged が internal になっているせいで、参照できない

            if (this.DisplayWebView.Source is UrlWebViewSource uri) {
                string url = uri.Url;

                // TODO Debug で確認したが、youtube の URLは書き換わらなかった
                // TODO なぜ？

                // DisplayWebView.Source が書き換わっているかをチェック
                if (!DisplayWebViewSource.Equals(url)) {

                    // ブラウザーの URLをテキストエディターに反映
                    this.ViewSourceEditor.Text = url;
                }
            }
        }

        /// <summary>
        /// BtnChangeSource のクリック時
        /// </summary>
        private void BtnChangeSource_Clicked(object sender, EventArgs e) {

            // DisplayWebView.Source をエディタの値で上書きする
            this.DisplayWebView.Source = this.ViewSourceEditor.Text;

            // TODO 以下、何のコード
            // SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
