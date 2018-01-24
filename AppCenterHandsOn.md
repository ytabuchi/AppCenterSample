# App Center Hands On with Xamarin

> 2017/12/14 [@ytabuchi](https://twitter.com/ytabuchi) Created.

## はじめに

このドキュメントでは、GitHub に配置したリポジトリと Microsoft の Visual Studio App Center を連携させて、Xamarin.Forms のアプリの自動ビルド、アプリの Analytics や Crash レポート、配布などを試してみよう！というハンズオンが出来ます。

私 [@ytabuchi](https://twitter.com/ytabuchi) の主宰している JXUG の勉強会、[JXUGC \#24 春の App Center 祭り \- connpass](https://jxug.connpass.com/event/72491/) で行ったミニハンズオン用に用意したものですが、見積もっていた時間がかなり少なかったため、終わらない方もいらっしゃいました。大変申し訳ありませんでした。

そのため、短時間でも確実で完遂できるように内容をブラッシュアップさせたものを再度公開します。是非、App Center での各種機能を味わってみてください。








## 事前準備

実際の作業を始める前に、いくつか事前準備が必要です。




### GitHub での準備

このハンズオンでは、GitHub の連携を使用して App Center の Build や Analytics を体験するため、GitHub のアカウントが必要です。

まだ GitHub のアカウントを持っていない方は [github.com](https://github.com/) からアカウントを作成してください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh001.png" width="600" />

また、何らかの GitHub クライアントが必要です。単体で動作する GitHub 製の GitHub Desktop や定番の Sourcetree の他に Visual Studio の拡張機能もあります。以下のリンクからダウンロード、インストールが可能です。

- [GitHub Desktop](https://desktop.github.com/)
- [Sourcetree](https://ja.atlassian.com/software/sourcetree)
- [GitHub Extension for Visual Studio](https://visualstudio.github.com/)

ここではクライアントの使い方は割愛します。興味がある方は是非調べてみてください。

GitHub のクライアントでお持ちの、または作成したアカウントでログインしておきます。


#### リポジトリの作成

アカウントを作成したら、本リポジトリを自身の GitHub に Fork します。

[本リポジトリのルート](https://github.com/ytabuchi/AppCenterSample) にアクセスし、右上の「Fork」ボタンをクリックします。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh002.png" width="600" />

Fork が完了すると、自身のリポジトリに `AppCenterSample` リポジトリが追加され、リポジトリ名の下に「forked from ytabuchi/AppCenterSample」と表示されているはずです。

GitHub の準備が完了したので、右側の「Clone or download」ボタンをクリックしてローカルに Clone します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh003.png" width="600" />

GitHub Desktop の場合は次のような確認画面が出てローカルに Clone が出来ます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh004.png" width="450" />

> Windows の場合は、Clone する際にローカルのリポジトリをなるべく「浅いフォルダ」に指定してください。Android のプロジェクトで NTFS の PATH 文字数の制限 260 文字に引っ掛かってしまう場合があるためです。`C:\GitHub\` などをリポジトリのルートフォルダにすることをお勧めします。

Clone されたら GitHub での作業はひとまず完了です。





### App Center での準備

次に App Center のアカウントを作成します。[appcenter.ms](https://appcenter.ms) にアクセスします。

右上の「GET STARTED」をクリックして次に進みます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac001.png" width="600" />

App Center には、次の方法でアクセスが出来ます。

- GitHub アカウント
- Microsoft アカウント
- facebook アカウント
- Google アカウント
- App Center のアカウント

今回は「Continue with GitHub」をクリックして、GitHub のアカウントでログインします。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac002.png" width="600" />

「Authorize VSAppCenter」をクリックして App Center を Authorize します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac003.png" width="300" />

Microsoft アカウントでログインする場合は、アカウントを選択してログインします。複数のアカウントを持っている場合は次のような画面になります。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac004.png" width="300" />


次のような画面が表示されればログインは完了です。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac101.png" width="600" />

> GitHub の設定の [Authorized OAuth Apps](https://github.com/settings/applications) に App Center が追加されていることが確認できます。<br />
<br />
<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh101.png" width="450" >


事前準備はこれで終了です。






## App Center にアプリ追加

まずは App Center にアプリを追加していきます。「Add New App」をクリックして、まずは Android アプリを追加します。既にアカウントを持っていたり、プロジェクトを作ったことがある方は右上の「Add New」ボタンから「Add New App」をクリックします。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac102.png" width="600" />

「Name」に「AppCenterSampleAndroid」と入力し、「Android」と「Xamarin」を選択して「App new app」をクリックします。

アプリが作成されました。下の方にスクロールすると Xamarin 用、Xamarin.Forms 用のドキュメントが参照できます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac103.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac104.png" width="600" />

左上のアイコンでホーム画面に戻り、同様に「Add new＞Add new app」から iOS アプリ「AppCenterSampleiOS」を作成します。UWP でも試したい場合は、UWP アプリ「AppCenterSampleUWP」も作成します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac105.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac106.png" width="600" />

Android アプリ「AppCenterSampleAndroid」を開き、「Settings」をクリックすると、右上に「APP SECRET」が確認できます。この Secret は後で使用しますので、すべてのアプリの Secret を控えておいてください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac107.png" width="600" />

App Center での作業はまずは完了です。





## Visual Studio プロジェクトのビルド

それでは実際に App Center で使用する Xamarin.Forms のプロジェクトを開きましょう。

Visual Studio の拡張機能を使用している場合は、次の画面のように「チームエクスプローラー」の「ローカル Git リポジトリ」で `AppCenterSample` をダブルクリックして開きます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs001.png" width="300" />

その後ソリューションから `AppCenterSample` ソリューションを開きます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs002.png" width="300" />

macOS や別の GitHub クライアントを使用している場合は、Finder、Windows エクスプローラーで Clone したフォルダに移動し、`AppCenterSample.sln` をダブルクリックしてプロジェクトを開きます。

> 新規でプロジェクトを作る場合は、iOS／Android／UWP の各プロジェクトに App Center の NuGet パッケージをインストールする必要があります。
> 
> Windows の Visual Studio 2017 の場合は、ソリューションを右クリックして、「ソリューションの NuGet パッケージの管理」をクリックし、以下の文字列で検索してすべてのプロジェクトにインストールします。macOS の Visual Studio for Mac の場合は、各プロジェクトを右クリックして、「追加＞NuGet パッケージ」をクリックし、以下の文字列で検索してインストールします。
> 
> - `Microsoft.AppCenter.Analytics`（macOS の場合は `App Center Analytics`）
> - `Microsoft.AppCenter.Crashes`（macOS の場合は `App Center Crashes`）
> 
> <img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs003.png" width="450" />
> 
> PCL／.NET Standard を使用している場合は、iOS／Android／UWP を含むすべてのプロジェクトにインストールすることに注意してください。
> 
> <img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs004.png" width="300" />
> 
> インストールが完了すると、次のようなプロジェクト構成になっているはずです。PCL や Shared プロジェクトの場合は少し異なりますが、iOS／Android／UWP のプロジェクトに `Analytics` と `Crashes` のライブラリが入っていることを確認してください。
> 
> <img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs005.png" width="300" />


次に Xamarin.Forms プロジェクトの `App.xaml.cs` を開き、以下の using があることを確認します。

```cs
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
```

同じファイルの `OnStart()` メソッド内に次のコードを追加します。

```cs
AppCenter.Start($"uwp={Your UWP App secret here};android={Your Android App secret here};ios={Your iOS App secret here}",
    typeof(Analytics), typeof(Crashes));
```

> Secret は各プラットフォーム毎に発行されます。「App Center にアプリ追加」の章で作成した各プラットフォームの App Secret で上記の {Your xxx App secret here} を置き換えてください。

それでは、Android アプリをビルドして起動してみましょう。

> java.lang.OutOfMemoryError. Consider increasing the value of $(JavaMaximumHeapSize). Java ran out of memory while executing 'java.exe ...<br />
と、Android プロジェクトでヒープメモリのビルドエラーが出る場合、Android プロジェクトのプロパティを開き、「Android オプション＞詳細設定（一番下にあるボタン）＞Java Max Heap Size」を「1G」に指定してください。<br />
<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs101.png" width="300" />


App Secret がこの時点で、OS 情報などの Analytics が取得出来ていることが確認できます。

App Center でビルドしたアプリ（今回は Android）の「Analytics」を開いてみましょう。今回は英語の言語設定の Emulator で実行したので、「Top devices」に Emulator、「Languages」に English がリストされているのが分かります。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac201.png" width="600" />





## App Center の各種機能を使う

ローカルでソリューションがビルド出来たところで、実際に App Center で色々出来るようにしていきましょう。



### Build

左側のメニューから「Build」を開きます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac301.png" width="600" />

GitHub や VSTS（Visual Studio Team Service）、BitBucket のリポジトリに変更があれば自動ビルドを行う仕組みです。

今回は、GitHub のリポジトリを指定してみましょう。GitHub をクリックすると、次のような認証画面に移行します。そのまま「Authrize VSAppCenter」をクリックしてください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac302.png" width="300" />

自身のリポジトリ一覧が表示されるので、最初に作成したリポジトリを指定します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac303.png" width="600" />

ブランチをクリックして、「Configure build」をクリックします。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac304.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac305.png" width="600" />

まずはそのままの設定で「Save & Build」ボタンをクリックしてビルドしてみましょう。「Build this branch on every push」が選択されているので、Master ブランチにプッシュされる度に自動的にビルドが開始されます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac306.png" width="600" />

ビルドが無事完了しました！

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac307.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac308.png" width="600" />


iOS もビルドしてみましょう。iOS の場合は、Simulator 用のビルド（x86 のバイナリ）とデバイス用のビルド（ARM バイナリ）を指定する必要があり、デバイス用のビルドには Apple Developer Program に加入すると取得できる証明書で署名する必要があります。今回は、デバッグビルド、Simulator Build、Sign なしを選択してビルドしてみましょう。



<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac309.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac310.png" width="600" />


無事ビルドが完了しました！

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac311.png" width="600" />


それでは、App Center の目玉の機能の一つである Analytics と Crash Report を使ってみましょう。


### Analytics

Analytics はユーザーがアプリでどのような操作を行ったかなどを記録する機能です。詳しくは以下の公式ドキュメントをご覧ください。

[App Center Analytics for Xamarin \| Microsoft Docs](https://docs.microsoft.com/ja-jp/appcenter/sdk/analytics/xamarin)

Analytics では、

- 5 個までのプロパティ
- 200 個までのイベント名
- 各イベント 64 文字

の仕様の元、例えば以下のようにデータを送信することができます。

```csharp
Analytics.TrackEvent("Video clicked", new Dictionary<string, string> {
    { "Category", "Music" },
    { "FileName", "favorite.avi"}
});
```

単にイベントをトラックしたいだけなら以下のように簡単にも書けます。

```csharp
Analytics.TrackEvent("Video clicked");
```

トラックの開始／停止、チェックはそれぞれ以下のコードで可能です。

```csharp
// 停止
Analytics.SetEnabledAsync(false);

// 開始
Analytics.SetEnabledAsync(true);

// チェック
bool isEnabled = await Analytics.IsEnabledAsync();
```

では実際に組み込んでみましょう。

まずはページを用意します。

`MainPage.xaml` を開き、`Content` を次のコードで置き換えます。

```xml
<StackLayout VerticalOptions="Center">
    <Label Text="Welcome to Xamarin.Forms!" 
           HorizontalOptions="Center" />
    <Button Text="Show Second Page"
            Clicked="Button1_Clicked" />
    <Button Text="Show Third Page"
            Clicked="Button2_Clicked" />
</StackLayout>
```

次に `MainPage.xaml.cs` を開き、`MainPage` クラスを次のコードで置き換えます。

```csharp
public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    async void Button1_Clicked(object sender, System.EventArgs e)
    {
        Analytics.TrackEvent("Navigation", new Dictionary<string, string>{
            {"MainPage", "SecondPage"}
        });
        await Navigation.PushAsync(new SecondPage());
    }

    async void Button2_Clicked(object sender, System.EventArgs e)
    {
        Analytics.TrackEvent("Navigation", new Dictionary<string, string>{
            {"MainPage", "ThirdPage"}
        });
        await Navigation.PushAsync(new ThirdPage());
    }
}
```

ナビゲーション先の `SecondPage` を作成します。

実際にアプリを動かしてみましょう。ローカルのビルドで構いません。iOS は Release モードでビルドをしてください。

SecondPage に遷移すると、Analytics の画面で各種情報が見られるようになります。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac401.png" width="600" />


### Crashes

クラッシュイベントを取得する機能です。詳しくは以下の公式ドキュメントをご覧ください。

[App Center Crashes for Xamarin \| Microsoft Docs](https://docs.microsoft.com/ja-jp/appcenter/sdk/crashes/xamarin)

App Center SDK にはテストのクラッシュを発生させるメソッドが用意されています。

```csharp
Crashes.GenerateTestCrash();
```

これも実際に組み込んでみましょう。

`ThirdPage` を作成します。`ThirdPage` は C# で作成してみました。

`ThirdPage` の ThirdPage クラスの C# コードを次のコードで置き換えます。

```csharp
public ThirdPage()
{
    var label = new Label
    {
        Text = "Third Page",
        HorizontalTextAlignment = TextAlignment.Center,
    };

    var button1 = new Button
    {
        Text = "Crash test!",
    };
    button1.Clicked += Button1_Clicked;

    var button2 = new Button
    {
        Text = "Crash test!",
    };
    button2.Clicked += Button2_Clicked;


    Title = "Third Page";
    Content = new StackLayout
    {
        VerticalOptions = LayoutOptions.Center,
        Children = {
            label,
            button1,
            button2
        }
    };
}

void Button1_Clicked(object sender, EventArgs e)
{
    // App Center SDK で用意されているクラッシュ送付メソッド
    // TestCrashException が Throw されます
    Crashes.GenerateTestCrash();
}

void Button2_Clicked(object sender, EventArgs e)
{
    throw new throw new SystemException();
}
```

上のボタンで、App Center SDK で用意されている TestCrashException が Throw され、下のボタンで SystemException が Throw されます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac501.png" width="600" />

集まった Exception は Crash の画面に表示されていきます。

エラーの種類でまとまって、⚡️が件数、🙍‍♂️がデバイス数です。


### 現時点でのまとめ

SDK をインストールして、キーを指定するだけでビルドができて、Analytics、Crash のデータも取れます。便利ですよね。



その他、App Center には以下の機能もあります。ぜひ使ってみてください。

なお、Android の Test、Distribute にはご自身で作成した keystore か Xamarin が用意した Debug 用の keystore を使用します。通常の Debug 時にXamarin が使用するキーは、通常の Android 開発で使用するキーとは場所が異なりますので以下に記載しておきます。

Windows：<br />
`%LOCALAPPDATA%\Xamarin\Mono for Android\debug.keystore`

macOS：<br />
`~/.local/share/Xamarin/Mono for Android/debug.keystore`

詳細は [Finding your Keystore's MD5 or SHA1 Signature \- Xamarin](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/MD5_SHA1/) をご参照ください。



### Test

公式ドキュメント：<br />
[App Center Test \| Microsoft Docs](https://docs.microsoft.com/en-us/appcenter/test-cloud/)



### Distribute

公式ドキュメント：<br />
[Distribute Mobile Apps with App Center \| Microsoft Docs](https://docs.microsoft.com/en-us/appcenter/distribution/)



### Push

公式ドキュメント：<br />
[App Center Push \| Microsoft Docs](https://docs.microsoft.com/en-us/appcenter/push/)





## まとめ

App Center は「VSTS の小規模版＋App Insights Xamarin 版」のような感じで、簡単に CI/CD の環境、およびアプリ解析の環境を提供してくれる中々良いサービスだと思います。

ぜひ周りの方にも使ってもらってみてください。
