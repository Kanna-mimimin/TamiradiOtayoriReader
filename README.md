# たみらじ!!おたよりリーダー

お名前にあたる項目と本文にあたる項目を指定してCSVファイルを読み込むと，  
お好みの画像の上にお名前と本文が表示できるよ♪


## ちょっとした使い方🔰

### ☆インストールほうほう
[リリースページ](https://github.com/Kanna-mimimin/TamiradiOtayoriReader/releases)から最新版の「TamiradiOtayoriReader-Ver〇.〇.〇.zip」をダウンロードしてお好みの場所に展開するだけ！


### ☆準備
1. 背景用画像を用意しておきます．  
このアプリは読み込んだ画像に合わせて画面サイズが変化するので，ちょうどいいサイズの画像を用意しておいてください．

1. Googleフォームから集計結果のCSVファイルをダウンロードしておきます♪  
※ZIPで圧縮されているので，中身のCSVファイルだけ取り出しておいてね！  
※ファイル名が文字化けしている場合は，わかるように名前を変えておいてね！  
<a href="./img/googleforms.png" target="_blank"><img src="./img/googleforms.png" width="200"></a>  
<br />  

### ☆使ってみる✨
1. 起動してみる  
「TamiradiOtayoriReader.exe」を実行します．
起動するとデフォルトの画像でおたより画面が表示されます．  
<a href="./img/otayori1.png" target="_blank"><img src="./img/otayori1.png" width="200"></a>  

1. おたよりを表示してみる  
おたより画面を右クリックするとコントロールパネル画面が開きます．  
「設定(おたより読込)」タブを選択すると，おたより読込設定画面が表示されます．   
    1. 「1 CSVファイル選択・項目名取得」欄にて，準備しておいたCSVファイルのパスを指定し「項目名取得」ボタンを押下します．  
    1. 「2 表示項目選択」欄にて，お名前項目名と本文項目名を選択して「おたより読込」ボタンを押下すると，おたよりが読み込まれるよ！  
<a href="./img/configcsv.png" target="_blank"><img src="./img/configcsv.png" width="300"></a>  
<a href="./img/csv.png" target="_blank"><img src="./img/csv.png" width="600"></a>  
※このCSVファイルの場合はお名前項目名が「お名前」、本文項目名が「お題」になります．  

1. おたよりを選んでみる  
コントロールパネルの「おたより選択」タブを選んで，おたより選択画面を表示します．  
2つ前，1つ前，1つ次，2つ次のおたよりへ移動するボタンと各おたよりの投稿者と本文の内容が少しだけ表示されます．  
移動ボタンでそれぞれのおたよりへ移動できるよ♪  
本文が見えない場合はカーソルを合わせると本文の全文がポップアップで表示されるよ！  
スライダーを有効にすると，お好みのおたよりまで移動できるよ！！  
<a href="./img/otayori2.png" target="_blank"><img src="./img/otayori2.png" width="250"></a>
<a href="./img/configselector.png" target="_blank"><img src="./img/configselector.png" width="300"></a>  

1. 背景画像や表示位置を調整してみる  
「設定(表示調整)」タブで色々調整ができるよ．  
背景画像設定のテキストボックスにお好みの背景画像を指定すると，お好みの画像が表示されます♪  
各種調整画面では文字の大きさや表示位置が調整できます．  
「保存ボタン」で設定を保存できるよ！  
※設定ファイルは実行ファイルと同じ場所に「TamiradiOtayoriReader.json」で保存されます．  
<a href="./img/configdisplay.png" target="_blank"><img src="./img/configdisplay.png" width="300"></a>  
　  
各種調整枠を表示すると，おたより画面に調整用の枠が表示されます．  
この枠をつかんで表示位置を調整できます．  
※茶色枠中央部(本文表示領域)では枠がつかめないから注意！その場合は外周部に表示されている枠を掴んでね！  
<a href="./img/otayori3.png" target="_blank"><img src="./img/otayori3.png" width="250"></a>  
<br />  

### コントロールパネルを小さくしてみる🆕

コントロールパネル画面右上の縮小ボタンをクリックするとミニコントロールパネルに変化するよ‼  
<a href="./img/ControlPanel-Nomal.png" target="_blank"><img src="./img/ControlPanel-Nomal.png" width="300"></a>  
　　⬆  
　変形‼  
　　⬇  
ミニコントロールパネル右下の拡大ボタンをクリックすると通常のコントロールパネルに戻るよ  
<a href="./img/ControlPanel-Mini.png" target="_blank"><img src="./img/ControlPanel-Mini.png"></a>  
<br /> 

### ☆OBSキャプチャ確認
- ウィンドウキャプチャでキャプチャできることを確認！  
- フィルタのクロマキーに背景色を指定することで背景の透過を確認♪  

<a href="./img/obs1.png" target="_blank"><img src="./img/obs1.png" width="230"></a>  
<a href="./img/obs2.png" target="_blank"><img src="./img/obs2.png" width="400"></a>  
<br />  

## 既知の不具合⚠
* コントロールパネルを開きなおすとラジオボタンの設定内容が壊れる💥  
➡対策方法が分からないため、コントロールパネルを閉じれないように暫定処置しました💦