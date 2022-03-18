EXTERNAL ShowCharacter(characterName, position, mood) 
EXTERNAL HideCharacter(characterName)
EXTERNAL ChangeMood(characterName, mood)
EXTERNAL ShowBackground(backgroundName,sprite,position)
EXTERNAL HideBackground(backgroundName)
EXTERNAL ChangeBackground(backgroundName,sprite)

-> start_knot // this tell ink where to start the story

=== start_knot ===
{ShowBackground("Bg", "Front", "center")}
{ShowCharacter("Noctania", "Right", "Fine")}
なんとか狩れたな#ノキタニア
{ShowCharacter("Protagoniste", "Left", "Fine")}
「うなずく」#主人公
ほら、さっさと帰るぞ#ノキタニア

->END