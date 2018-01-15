# App Center Hands On with Xamarin

2017/12/14 [@ytabuchi](https://twitter.com/ytabuchi) Created.









## 事前準備



### GitHub アカウントの準備

このハンズオンでは、GitHub の連携を使用して App Center の Build や Analytics を体験します。そのため、GitHub のアカウントが必要です。

まだ GitHub のアカウントを持っていない方は [github.com](https://github.com/) からアカウントを作成してください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh001.png" width="600" />

#### レポジトリの作成

アカウントを作成したらレポジトリを作成します。

自分のページにアクセスし、「Repositories」タブをクリックして、「New」ボタンからレポジトリを作成します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh002.png" width="600" />

任意の名前でレポジトリを作成し、「Add .gitignore」を「Visual Studio」などに指定して「Create repository」をクリックして作成します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh003.png" width="600" />

#### .gitignore の設定


作成されたレポジトリの `.gitignore` ファイルを開き、[Xamarin 用の設定（現時点ではこの `.gitignore` ファイルがお勧めです。）](https://github.com/ytabuchi/GitIgnoreTest/blob/master/.gitignore) に修正します。「Edit アイコン」をクリックすることで、そのままサイト上でも編集できます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh004.png" width="600" />

GitHub の準備が完了したのでローカルに Clone します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh005.png" width="600" />

ローカルのクライアントは何でも構いません。以下などがあります。

- [GitHub Desktop](https://desktop.github.com/)
- [Sourcetree](https://ja.atlassian.com/software/sourcetree)

Visual Studio の拡張機能もあります。

- [GitHub Extension for Visual Studio](https://visualstudio.github.com/)

ここではクライアントの使い方は割愛します。興味がある方は是非調べてみてください。



### App Center アカウントの準備

次に App Center のアカウントを作成します。[appcenter.ms](https://appcenter.ms) にアクセスします。

右上の「GET STARTED」をクリックして次に進みます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac001.png" width="600" />

App Center には、次の方法でアクセスが出来ます。

- GitHub アカウント
- Microsoft アカウント
- facebook アカウント
- Google アカウント
- App Center のアカウント

ここでは、GitHub のアカウントでログインしてみましょう。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac002.png" width="600" />

「Authorize VSAppCenter」をクリックして App Center を Authorize します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac003.png" width="300" />

Microsoft アカウントでログインする場合は、アカウントを選択してログインします。複数のアカウントを持っている場合は次のような画面になります。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac004.png" width="300" />


次のような画面が表示されればログインは完了です。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac101.png" width="600" />

GitHub の設定の [Authorized OAuth Apps](https://github.com/settings/applications) に App Center が追加されていることが確認できます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/gh101.png" width="450" >


事前準備はこれで終了です。




## App Center にアプリ追加

そのまま App Center にアプリを追加していきます。「Add New App」をクリックして、まずは Android アプリを追加します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac102.png" width="600" />

「Name」に「AppCenterSampleAndroid」と入力し、「Android」と「Xamarin」を選択して「App new app」をクリックします。

アプリが作成されました。下の方にスクロールすると Xamarin 用、Xamarin.Forms 用のドキュメントが参照できます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac103.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac104.png" width="600" />

左上のアイコンでホーム画面に戻り、同様に「Add new＞Add new app」から iOS アプリ「AppCenterSampleiOS」と UWP アプリ「AppCenterSampleUWP」を作成します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac105.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac106.png" width="600" />


Android アプリ「AppCenterSampleAndroid」を開き、「Settings」をクリックすると、右上に App Secret が確認できます。この Secret は後で使用しますので、Android、iOS、UWP の Secret を控えておいてください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac107.png" width="600" />





## Visual Studio プロジェクトの準備

それでは実際に App Center で使用するプロジェクトを作成します。このドキュメントでは Windows の Visual Studio での画面を掲載しています。Mac の Visual Studio for Mac を使用している方は適宜読み替えてください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs001.png" width="450" />

Visual Studio を開き、「新しいプロジェクトの作成」から、「Visual C#＞Cross-Platform＞Corsss-Platform App (Xamarin.Forms)」を選択します。今回はプロジェクトの名前を「AppCenterSample」としました。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs002.png" width="450" />

「Platform」をすべてチェック、「UI Technology」を「Xamarin.Forms」、「Code Sharing Strategy」を「.NET Standard」にして「OK」をクリックします。

プロジェクトが作成されたら使用しているライブラリを最新にしておきましょう。

ソリューションを右クリックして、「ソリューションの NuGet パッケージの管理」から NuGet パッケージマネージャーを開き、「更新」タブの「すべて更新」をチェックし、「更新」ボタンをクリックします。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs003.png" width="450" />

そのまま以下の NuGet パッケージをインストールします。

- `Microsoft.AppCenter.Analytics`（macOS の場合は `App Center Analytics`）
- `Microsoft.AppCenter.Crashes`（macOS の場合は `App Center Crashes`）

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs004.png" width="450" />

PCL／.NET Standard を使用している場合は、すべてのプロジェクトにインストールすることに注意してください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs005.png" width="300" />

インストールが完了すると、次のようなプロジェクト構成になっているはずです。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs006.png" width="300" />

次に Xamarin.Forms プロジェクトの `App.xaml.cs` を開き、以下の using を追加します。

```cs
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
```

同じファイルの `OnStart()` メソッド内に次のコードを追加します。

```cs
if (Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.UWP)
    AppCenter.Start("uwp={Your UWP App secret here};", 
        typeof(Analytics));
else
    AppCenter.Start("android={Your Android App secret here};" + "ios={Your iOS App secret here}",
        typeof(Analytics), typeof(Crashes));
```

> Secret は各プラットフォーム毎に発行されます。「App Center にアプリ追加」の章で作成した各プラットフォームの App Secret で上記の {Your xxx App secret here} を置き換えてください。

それでは、Android アプリをビルドして起動してみましょう。

> java.lang.OutOfMemoryError. Consider increasing the value of $(JavaMaximumHeapSize). Java ran out of memory while executing 'java.exe ...<br />
と、Android プロジェクトでヒープメモリのビルドエラーが出る場合、Android プロジェクトのプロパティを開き、「Android オプション＞詳細設定（一番下にあるボタン）＞Java Max Heap Size」を「1G」に指定してください。<br />
<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/vs101.png" />


この時点で、OS 情報などの Analytics が取得出来ていることが確認できます。

App Center でビルドしたアプリ（今回は Android）の「Analytics」を開いてみましょう。Emulator で言語設定が英語になっているのが分かります。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac201.png" />





## App Center の各種機能を使う

ローカルでソリューションがビルド出来たところで、実際に App Center で色々出来るようにしていきましょう。



### Build

左側のメニューから「Build」を開きます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac301.png" width="600" />

GitHub や VSTS（Visual Studio Team Service）、BitBucket のレポジトリに変更があれば自動ビルドを行う仕組みです。

今回は、GitHub のレポジトリを指定してみましょう。GitHub をクリックすると、次のような認証画面に移行します。そのまま「Authrize VSAppCenter」をクリックしてください。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac302.png" width="300" />

自身のレポジトリ一覧が表示されるので、最初に作成したレポジトリを指定します。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac303.png" width="600" />

ブランチをクリックして、「Configure build」をクリックします。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac304.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac305.png" width="600" />

まずはそのままの設定で「Save & Build」ボタンをクリックしてビルドしてみましょう。「Build this branch on every push」が選択されているので、Master ブランチにプッシュされる度に自動的にビルドが開始されます。

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac306.png" width="600" />

ビルドが無事完了しました！

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac307.png" width="600" />

<img src="https://raw.githubusercontent.com/ytabuchi/AppCenterSample/master/images/ac308.png" width="600" />





> 以下、執筆中

### Test

Windows

`%LOCALAPPDATA%\Xamarin\Mono for Android\debug.keystore`

macOS

`~/.local/share/Xamarin/Mono for Android/debug.keystore`

[Finding your Keystore's MD5 or SHA1 Signature \- Xamarin](https://developer.xamarin.com/guides/android/deployment,_testing,_and_metrics/MD5_SHA1/)




### Distribute

xxx


### Crashes

xxx


### Analytics

xxx


### Push

xxx








## まとめ

