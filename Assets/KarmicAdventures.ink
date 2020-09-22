VAR spiritKarma = 0
VAR demonKarma = 0
VAR gold = 0

== function alter(ref x, y)
    ~ x = x + y

== function Give_Gold_And_Demon_Karma(goldAmount, karmaAmount)
    ~ Give_Demon_Karma(karmaAmount)
    ~ Give_Gold(goldAmount)

== function Give_Demon_Karma(x)
    ~ alter(demonKarma, x)

== function Give_Spirit_Karma(x)
    ~ alter(spiritKarma, x)
    
== function Give_Gold(x)
    ~ alter(gold, x)

=== Dad ===
=is_stone
Help me my son. There is so much to tell you but so little time to do it in.
*[Wh.. what's happening?]
    It's the blight, son. The whole village has been turned to stone. The whole village... except for you.
        **[Me?! Why me?]
        **[What's so special about me?]
-   You have a gift, my son. Magic runs through your veins, an old magic. A great magic. You have the power inside you to turn us back to our human forms.
    *[How?]
    *[I do? How?]
    *[Tell me what to do.]
-   There's an object you must find. It's a very powerful gemstone. You'll know it when you see it. Go. Now.
-> DONE

=is_awake
Oh, my son. Thank you so much for freeing me. We don't have much time and you must be on your way. I'm sure you've got plenty of questions. I'll only have time to answer a few..
- (opts)
+[Why is this happening to me?]
    It's happening to you because you're special, my son. I know every parent thinks their child is special, but you actually are. Since you were born, strange things have happened around you. It took us some time, but we eventually realized that it was you causing it. We don't know how or why, but you have access to a great magic, son. Use it wisely. -> opts
+(stones)[Tell me about the avatar stones!]
    Stories say that when God Emperor Magnus died, his power didn't die with him - it left his body in search of a new host. The power entered the first living creature it encountered - a tiny mouse. The mouse wasn't strong enough to contain this great power, and it exploded - shattering God Emperor's power in the process. Every avatar stone is a piece of that shattered power that you can unlock, take within you and use. 
    ++[How many avatar stones are there?] 
        There are 12 avatar stones altogether, as best as anyone can tell. There could be more, there could be less, it's hard to say. Very little is known about the circumstances surrounding the death of God Emperor Magnus, but there are a few people who've located these avatar stones and they've studied them, and they all agree that his power split into 12 pieces.-> stones
    ++[What kind of powers will they give?] 
        No one can say for sure, exactly. God Emperor Magnus was extremely powerful, and even a small piece of his power would eclipse almost any other sorceror in the Eternal Kingdoms. A few people have located some of these avatar stones, but no one has been able to access the power within until you just did.-> stones
    ++ -> opts
+[What do you know about the Wizard Saints?]
    Not much, my son. The Wizard Saints are very powerful, quite nearly immortal beings. The Wizard Saint Moro Storm-Tamer lives in the castle nearby. It's said that he can control storms and even causes the seasons to change. When Moro's angry, it's said that crops will fail and the harvest will be poor. We try very hard not to anger him. -> opts
+[No more questions] 
    Good luck, my son. -> DONE

=== Mom ===
=is_stone
I...<br>Love...<br>you...
-> DONE

=is_awake
Thank the eternal spirit of the God Emperor! You've freed me from that horrible state. I could feel my memories start to fade away. I don't know what I'd do if I forgot you.
-> DONE

=== Brother ===
=is_stone
Haha this feels weird. Am I going to be stuck like this forever?
* Yes
    Oh no! I don't want to be a statue forever!
* No
    Thank god. I don't want to be a statue forever!
* Of course not! I'll save you, baby bro!
    You're the best, big bro! I knew you'd help me...
- ->DONE

=is_awake
Hey big bro. I have a question for you. Have you got an answer for me?
*[Yes] -> yes
*[No]
    Well boo. -> DONE
*[Yeah, but you won't like my answer...] -> yes

=yes
So all of us are turned to stone. What do you think happened to all the plants and animals? Do you think they're changed too? Do you think Pup-pup is turned to stone too?
*[Hmmm. That's a very good question. Where even is Pup-pup?] -> positive
*[I don't think so! I think animals will be fine. Don't worry about Pup-pup.] -> positive
*[There's a very good chance that Pup-pup got turned to stone too. But don't worry, I'll save him too!] -> positive
*[Of course he is. Don't be stupid.] -> negative

- (positive)
Oh thank heavens. I would cry if that happened to Pup-pup. My head stuff was all weird when I was stuck like that. It was like my mind was going away. Can I ask you something else?
+[Anything you want...]
    I lost my thing. Can you go find it for me?
    **[Sure, little bro]
    #GiveQuest
        You're the best big brother ever! -> DONE
    **[I don't have time for this!]
        You never have time for me! -> DONE
+[Not right now, I'm in a rush.]-> DONE

- (negative)
You're a mean jerk, you know that? I'm glad you're going away and it's just going to be me and mom and dad now. -> DONE

=== Villager ===
=is_stone
{~Help me..|I'm so confused! What's going on?|Where am I? What's happened to me?|I can't move...<br>I can't see...<br>Am I still alive?|Hahaha *cough* haha *sob*}->DONE

=is_awake
{~Thanks for saving me!|My memories are slowly coming back. I didn't even know they were going.|All my strength is returning. It feels good to be alive again. Thank you.|If only the God Emperor was alive, we wouldn't have needed you to rescue us.} -> DONE

=== Villager_2 ===
=is_stone
{~Has the Blight reached us now?|This is the work of the Wizard Saints, I know it.|The Wizard Saints are responsible for this. You watch..|Happy birthday! It is your birthday today, right? Or did I get that wrong too...} ->DONE

=is_awake
{~The Blight is going to take us all. Mark my words boy, mark my words.|I'm sorry this had to happen on your birthday. Strange. It's also the anniversary of God Emperor's death.} -> DONE

=== Villager_3 ===
=is_stone
{~Oh woe is me. Terrible things are happening all over the world | Ever since God Emperor Magnus died, the world is falling apart. | God is dead and this is our reward!} ->DONE

=is_awake
All this hullaballoo on your birthday, of all days. It's also the anniversary of God Emperor Magnus dying. Do you think the two are related? Is that why you were spared this horrible fate?
*[What do you know about God Emperor Magnus?]
    Not very much. I know he was a powerful wizard and lived for over 1000 years. We all thought he was immortal up to the very minute of his death. -> positive
*[My birthday and God Emperor's death day are the same?]
    Yes it is. 18 years ago today, God Emperor Magnus died and you were born. Uncanny coincidence, isn't it? -> positive
*[I'm awesome, that's why I was spared this horrible fate.]
    If you say so, buddy. -> DONE
    
- (positive)
*[If the Emperor is immortal, how did he die?]
    There's the rub: No one knows. Some say if he was a true god, he couldn't die. But did he die of old age finally? Did someone find some way to murder him? Some say he didn't die, he just returned to the spirit world. It's a mystery to us all, but the Emperor is gone all the same.  ->DONE
    
=== Villager_4 ===
=is_stone
Things are getting all mixed up in my head. It's only just happened and already I feel like I'm forgetting. -> DONE

=is_awake
Thank you so much for saving me. You went to all this trouble for me. And on your birthday! -> DONE

=== Villager_5 ===
=is_stone
We let God Emperor die, so we brought this on ourselves. -> DONE

=is_awake
Over 1000 years ago, God Emperor Magnus and the 8 Wizard Saints fought back an evil from the land so that we could all live here peacefully. When he died, the protection he offered died with him. That's why the Blight is happening. Mark my words.
- (opts)
+[Do you know how they fought back the evil?]
    Only rumours and legends. They say that God Emperor Magnus drew upon the power of the 8 Wizard Saints and together they cast a powerful spell that held back the great evil. -> opts
+[What can you tell me about the Wizard Saints?]
    I try not to mess around in the affairs of wizards. My daughter married a soldier in his Castle Guard and he says that Moro has gone insane. I'd believe it too, judging by how this place looks. -> opts
+[Is there anything else you can tell me?]
    I can tell you loads, but none of it useful to ya. Strange things have been happening lately. And not just here.
    **[What do you mean?]
        Just go outside and you can see for yourself. There's monsters everywhere, lad. -> opts
    **[Are the strange things only happening here?]
        I've heard whispers from other lands that strange things are happening there too. The whole world's gone mad slowly. -> opts
+[I don't have any other questions]
    And I'm fresh out of answers. Have a good day, lad. -> DONE
    
=== Villager_6 ===
=is_stone
We used to worship the Wizard Saints, and look at what they've done to us now. -> DONE

=is_awake
The Wizard Saints may be bad, but you're not. I'll gladly worship you now.
*[Oh please don't]
*[That sounds a bit creepy.]
*[I like how that sounds.]
*[Get some friends and worship me together!] {Give_Demon_Karma(1)}
- You may not be <i>the</i> saviour, but you're definitely MY saviour. -> DONE

=== Villager_7 ===
=is_stone
I was just setting the table this morning for breakfast when something happened and now I'm stuck. Or was it yesterday morning? -> DONE

=is_awake
I've heard that over in the next town over, people have been turned into monsters, not statues. The Shopkeeper told me yesterday. -> DONE

=== Villager_8 ===
=is_stone
When grandma comes over, mom lets us have ice cream. I'll have my ice cream now, though. Pistachio. -> DONE

=is_awake
Thanks for saving me! Oh! It's your birthday, isn't it? Happy Birthday! {is_stone:You can have some ice cream with me too!} -> DONE

=== Villager_9 ===
=is_stone
{~The Wizard Saints are behind this for sure. To think we used to worship them!|Moro Storm-Tamer is the most powerful and was the most worshipped Wizard Saint. And look where that got us.|The Wizard Saints have slowly been falling to evil since God Emperor Magnus died.That's why this is happening.|If Moro's behind this, and he is, we're all doomed. Doomed!} -> DONE

=is_awake
{~Oh I'm so relieved to be free. I didn't think we'd ever be human again.|Thank you for saving us! I never expected to be free.|When you find Moro, give him my best... right hook! Punch him right in the face for me.} -> DONE

=== Villager_10 ===
=is_stone
I feel like I'm slowly losing my memory. Who I am is cracking. Falling apart. I'm melting... melting. -> DONE

=is_awake
Thank you so much for saving me. I can't ever thank you enough. Is there any way I can repay you for saving me?
- (opts)
*[You can answer a couple questions for me]
    Sure, what can I help you with?
    - (sub_opts)
    **[What can you tell me about the God Emperor?]
        Not a whole heck of a lot you wouldn't already know. The God Emperor and the Wizard Saints saved us all from a great evil that they banished from the Eternal Kingdoms. He lived for over 1000 years before he somehow died. I think he was murdered, though. Mark my words. -> sub_opts
    **[What can you tell me about the Blight?]
        When the God Emperor died, the spell he cast to save us all from the evil broke. Everything started to change after that. Dark whispers are in the air if you know how to listen for them. -> sub_opts
    **[What can you tell me about the Wizard Saint Moro?]
        Moro is very much the most feared of the Wizard Saints. If anyone were to have murdered the God Emperor, it would have been Moro. It has been said that he has a power to rival the God Emperor's himself. He's ambitious enough to want to replace Magnus on the throne and become the new God Emperor. But it looks like his plan backfired. The Kingdoms are in ruin. -> sub_opts
    **[I have no further questions]
        Ok. -> is_awake
*[I accept all major credit cards, debit, and cold hard CASH]
    Well, I uh. You see. We're uh. We're very poor and don't have much. But if you insist I will gladly give you some of our gold.
    **[Haha, I was just kidding.]
        Thank you. You're as humorous as you are kind. -> DONE
    **[I insist]
        Well. Here you go. {Give_Gold_And_Demon_Karma(5, 1)} -> DONE
*[Nothing else but your thanks is needed.]
    You're too kind. -> DONE
    
=== Villager_11 ===
=is_stone
I'm scared. What's happening? -> DONE

=is_awake
I'm so glad you saved me. You're a good friend. -> DONE

=== Villager_12 ===
=is_stone
The Blight has finally reached our little town. Damn the Wizard Saints to hell. -> DONE

=is_awake
Thank you so much for helping me. Want some advice?
*[Yes]
    Go home. Now. You'll never kill Moro. He'll kill you first. -> DONE
*[No]
    Well I'm going to give it to you anyway. Go home. Now. You'll never kill Moro. He'll kill you first for sure. -> DONE

=== Villager_13 ===
=is_stone
You're never going to find the potion I hid in the armoire, thief!
*[I'm not a thief! I'm going to help you!]
    Well thank heavens for that! -> is_awake
*(thief)[What else are you hiding, lady?]
    There's a health potion in the grain sack by the sink. {Give_Demon_Karma(1)} -> is_awake
    
=is_awake
{
- is_stone && not thief: 
Thanks for helping. I still think you're a thief though. -> DONE
- is_stone && thief: 
Considering you stole from us, I didn't think you'd bother to help me. I guess you're not all bad.
+[Thanks, I guess...]
    Listen. If you want to make some quick cash, I've got an opportunity for you. That is, if you choose to accept it.
    ++[I'll do anything for a quick buck.]
    #GiveQuest
        Yeah I thought you would. Here, check this out.. {Give_Demon_Karma(2)} -> DONE
    ++[I'll pass, thanks.]
        You're a much nicer person than I thought. If you change your mind though, you know where to find me. -> DONE
- else:
Thanks so much for saving me. I was sure you would turn out to be a thief though. -> DONE
        }

=== Villager_14 ===
=is_stone
There are so many ghosts flying around the village these days. I'm scared of ghosts. -> DONE

=is_awake
Thanks so much for freeing me. Do you think you can do me a huge favour?
+[Absolutely!]
    #GiveQuest
    Excellent.{nope: I knew the reward would hook you!} See. I'm scared of ghosts. If you could help clear some ghosts out from the village, that would be great. -> DONE 
+(nope)[Definitely not.]
    I thought you might be too busy. If you change your mind ever, come see me. There's a reward... -> DONE
    
=== Villager_15 ===
=is_stone
It's getting harder and harder to think. -> DONE

=is_awake
Thank you so much. It was horrible being stuck in that state. -> DONE

=== Shopkeeper ===
=is_stone
Shop's closed, if you can't see. The Blight's reached our little village here, if you can't tell. 
-(opts)
*[I can see, I can tell. What do you mean by "reached"?]
    You're a spicy one, if you can't tell. Every single province in the Eternal Kingdoms have been visited by the Blight and we were the last, if you can't see. That's what I meant by "reached" if you can't tell. -> opts
+(blight)[What can you tell me about the Blight?]
    I can tell you {three things|two things|one last thing|nothing more} about the Blight, if you can't see{blight <= 3::|.}{not started:<br>How it started.}{not fight:<br>How to fight it.}{not end:<br>How to end it.}{blight <= 3:<br>What do you want to know?| Sorry my friend.}
    **(started)[How it started]
        Slowly, if you can't tell. From the death of God Emperor until today, a terrible evil slithered across the land like a snake, poisoning everything it touched, if you can't see. It's the same evil that the God Emperor fought off long ago, if you can't tell. And now it's back. -> opts
    **(fight)[How to fight it.]
        You hold a great power, if you can't tell. One of the things you can do is visit other dimensions, if you can't tell. If you find a warp crystal and stand in a stone circle, you'll be able to travel to the spirit realms or the demon realms, if you can't see. You'll find powerful magical artifacts that you'll be able fight back the Blight with, if you can't tell. -> opts
    **(end)[How to end it.]
        Such a great evil requires a focal point, if you can't tell. Legends tell of dark crystals scattered across the land, if you can't see. These crystals were dark until the God Emperor died, and now they're active again, if you can't tell. There's a powerful and dark magic coming from the forest, if you can't see. Go to the forest and seek out this crystal, if you can't see. If you can destroy it, the Blight will begin to fade, if you can't tell. -> opts
    ++ -> opts
*[When will your shop reopen?]
    Maybe never, if you can't tell. I'm stuck like this and the whole world's fallen to the Blight, if you can't see. But if you can find some way to turn me back into a human, I'll open my store just for you, if you can't see. You'll need to stock up on supplies for your journey, if you can't tell. -> opts
*[No further questions]
    Good luck on your travels, if you can't see. You'll need it, if you can't tell. -> DONE

=is_awake
Thank you for saving me! I'm so glad to be free of that monstrous form. I'll reopen my shop for you right away. Is there anything else I can help you with?
- (opts)
+(blighted)[What can you tell me about the Blight?]
    I can tell you {is_stone and is_stone.blight:the same }{three things|two things|one last thing|nothing more} about the Blight{is_stone and is_stone.blight: that I could before}{blighted <= 3::|.}{not startedIt:<br>How it started.}{not fightIt:<br>How to fight it.}{not endIt:<br>How to end it.}<br>{is_stone and is_stone.blight:Sorry I can't tell you anything new. }{blighted <= 3:<br>What do you want to know?|}
    **(startedIt)[How it started]
        Slowly. From the death of God Emperor until today, a terrible evil slithered across the land like a snake, poisoning everything it touched. It's the same evil that the God Emperor fought off long ago, and now it's back. ->opts
    **(fightIt)[How to fight it.]
        You hold a great power buried within you. One of the things you can do is visit other dimensions. If you find a warp crystal and stand in a stone circle, you'll be able to travel to the spirit realms or the demon realm. You'll find powerful magical artifacts that you'll be able fight back the Blight with. -> opts
    **(endIt)[How to end it.]
        Such a great evil requires a focal point. Legends tell of dark crystals scattered across the land. These crystals were dark until the God Emperor died, and now they're active again. There's a powerful and dark magic coming from the forest. Go to the forest and seek out this crystal. If you can destroy it, the Blight will begin to fade. -> opts
    ++ -> opts
*[Can you tell me anything about Moro Storm-Tamer?]
    All beings great and small can tell you something about Moro. The trick is to separate the truth from the lies.
    **[What do you mean?]
        Moro Storm-Tamer has been worshipped like a god for many centuries. There are many and more myths and legends surrounding him than there are truths at this point. Moro encourages these myths to protect himself. From what, I don't know. It's not like many people have the power to stand up to him. -> opts
    **[How will I know the truths from the lies?]
        Moro Storm-Tamer has been worshipped like a god for many centuries. There are many and more myths and legends surrounding him than there are truths at this point. Moro encourages these myths to protect himself. From what, I don't know. You can probably assume <i>most</i> things you hear about him to be false, at least to some degree. -> opts
*[No further questions]
    Good luck on your travels. You'll need it. -> DONE