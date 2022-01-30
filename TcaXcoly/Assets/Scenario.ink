EXTERNAL ShowCharacter(characterName, position, mood) 
EXTERNAL HideCharacter(characterName)
EXTERNAL ChangeMood(characterName, mood)
EXTERNAL ShowBackground(backgroundName,sprite,position)
EXTERNAL HideBackground(backgroundName)
EXTERNAL ChangeBackground(backgroundName,sprite)

-> start_knot // this tell ink where to start the story

=== start_knot ===
{ShowBackground("Bg", "Front", "center")}
「ハァ……ハァ……」
{ChangeBackground("Bg","Classroom")}
「ここが……事件現場……」
{ChangeBackground("Bg","Front")}
他とはどこか違う、独特な雰囲気。

横吹く風が、どこからか、何かをここへ運んでくる。#oliver

// ShowsoundEffect("sound","walking",center)
〈トタ、トタ、トタ、トタ〉革靴でゆっくり歩いている#john
{ChangeBackground("Bg","School")}
{ShowCharacter("Protagoniste", "Left", "Fine")}
{ShowCharacter("Jack", "Right", "Fine")}
オリヴァー: 「やっと来たか、助手君」#david
{HideCharacter("Detective")}
{ShowCharacter("Detective", "Center", "Sad")}
{HideCharacter("Killer")}
//A branch
***「はいっ！　お待たせしてすみません」
{HideCharacter("Detective")}
{ShowCharacter("Detective", "Right", "right")}
->A_branch

//B branch
***「あの……今回はどういった事件なのですか？」
->B_branch

===A_branch===
オリヴァー: 「捜査の内容はしっかり頭に入れているな」
{ShowCharacter("Detective", "Left", "Sad")}
***「はいっ！」
{ChangeMood("Detective", "Upset")}
「そんなかしこまらなくていい」
->C_branch

===B_branch===
{ChangeMood("Detective", "Upset")}
オリヴァー:「資料を見ていないのか？」
***「は、はい……」
{ChangeMood("Detective", "Serious")}
「まぁ、いい。後で説明する」
->C_branch

===C_branch===
{ShowCharacter("Killer", "Right", "Serious")}
ジャック:「遅かったようだな。オリヴァー」
「そいつは誰だ」
オリヴァー:「助手だ。素人だが、そこらのプロよりはマシだ」
***「は……初めまして」
->D_branch

===D_branch===
オリヴァー:「敬語は使うな。こいつが今回の犯人だ」
ジャック:「決めつけないでくれ、まだ証拠は掴んでいないんだろう」
オリヴァー:「何人もの人がこの場所で姿を消し、その後遺体として発見されている」
「報道でも流れている連続殺人事件の犯人、お前のネタはほとんどあがっているんだ」
ジャック:「そうか、それなら精々証拠品探しに励むといい」
{HideCharacter("Killer")}
オリヴァー:「行くぞ助手君」
***「はい！」
->E_branch


===E_branch===
{ChangeBackground("Bg","Bedroom2")}
{HideCharacter("Detective")}
{ShowCharacter("Killer", "Left", "Serious")}
ジャック:「ここは客間だ」
{ShowCharacter("Detective", "Right", "Serious")}
オリヴァー:「暖炉と、チェスのコマ……。この肖像画は誰だ？」
ジャック:「無論。私だ」
オリヴァー:「……助手君。君はどこが怪しいと思う？」
***「え……っと」
->F_branch


===F_branch===
***「棚や、肖像画の裏とかでしょうか？」
->G_branch


===G_branch===
{ShowCharacter("Detective", "Right", "Serious")}
オリヴァー:「半分正解だ」
「残るは椅子の裏やカーペットの下、何食わぬ顔で見えやすい場所に置いてあることもある」
「全体を見て、目のいかない場所を探してみるといい」
***「わかりました！」
->H_branch


===H_branch===
//fade out
{ChangeBackground("Bg","Livingroom")}
//fade in
ジャック:「ここは診察室。私の仕事場だ」

***「今は医者をしているんだってな。仕事部屋と考えればそこまで違和感はないが、ここには薬品などもあるだろう」
->I_branch


===I_branch===
***「診察室にしては、ベッドが見当たりませんが……」
->J_branch

===J_branch===
ジャック:「フッ……。何もベッドがあるから診察室というわけでもないだろう」
「しかし、良い目をしている」
「私は基本、病名を調べ、病にあった薬を調合し渡しているだけだ」
「メスなども無くはないが、ほとんど使う機会はない」
//fade out
{ChangeBackground("Bg","Bedroom")}
//fade in
ジャック:「ここは寝室だ」
***「ほとんど、何もない……？」
->k_branch

===k_branch===
ジャック:「寝るための場所だ。何も問題はないだろう」
オリヴァー:「そうだ、まず疑問に思うこと。それが一番大切だ。」
「一つも疑問を感じない部屋などない。もしそんな部屋があったら、そここそ本当の犯行現場だ」
//fade out
{ChangeBackground("Bg","Workingroom")}
//fade in
ジャック:「ここが書斎。これで最後だ」
***「こんなに沢山の本……」
->L_branch

===L_branch===
オリヴァー:「学院の頃からお前は常に本を読んでいたっけな」
「今もそうだが、よくわからない行動をしていた」
***「お二人はお知り合いだったんですか？」
->M_branch

===M_branch===
オリヴァー:「知り合いというほどでもない。ただ通っていた学院が同じってだけだ」
「話したこともそうなかったはずだ」
ジャック:「……」
***なんだろう。やけにずっとオリヴァーさんを見ている。この人は何か、オリヴァーさんに思っていることがあるのだろうか。
->N_branch


===N_branch===
// show 4 image room
{ChangeBackground("Bg","Fourroom")}
ジャック:「さて、これですべての部屋は周った。あとは好きに探すといい」

オリヴァー:「客間、診察室、寝室、そして……書斎」
「この部屋のどこかに、失踪事件解決のカギがあるはずだ」
「先ほど見てきた四つの部屋にはいくつかの怪しいものがあった」
「その中から一つ選び、私の元に持ってきてくれ」
「直接の証拠でなくてもいい、怪しいと思ったもの、証拠につながるものを探してくれ」
「わからないことがあれば、なんでも聞いてくれて構わない。頼んだぞ」
ジャック:「私は見物でもしていますか」
「頑張ってください探偵、それと、助手の君も」

->END




