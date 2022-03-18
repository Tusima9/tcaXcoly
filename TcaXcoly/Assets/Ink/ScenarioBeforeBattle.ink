EXTERNAL ShowCharacter(characterName, position, mood) 
EXTERNAL HideCharacter(characterName)
EXTERNAL ChangeMood(characterName, mood)
EXTERNAL ShowBackground(backgroundName,sprite,position)
EXTERNAL HideBackground(backgroundName)
EXTERNAL ChangeBackground(backgroundName,sprite)

-> start_knot // this tell ink where to start the story

=== start_knot ===

雨が降っていた

いつもの高校からの帰り道

私は死んだ

殺された…死神に

これは、死神によって命を奪われた少女が、自分自身を取り戻す物語

…い。おい。おい！！#???
{ShowBackground("Bg", "Front", "center")}
{ShowCharacter("Protagoniste", "Left", "Fine")}
？！#主人公

{ShowCharacter("Noctania", "Right", "Fine")}
ボサっとするなウスノロ！また死にてえのか！#ノキタニア

…死神はそう簡単に死ねんぞ#アルター

こいつは死ぬだろ！おら、死にたくなきゃかまえろ。来るぞ！#ノキタニア

->END




