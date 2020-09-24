-> Dad.is_awake

=== Dad ===
=is_stone
Help me my son. There is so much to tell you but so little time to do it in.
+[Wh.. what's happening?]
    It's the blight, son. The whole village has been turned to stone. The whole village... except for you.
        ++[Me?! Why me?]
        ++[What's so special about me?]
-   You have a gift, my son. Magic runs through your veins, an old magic. A great magic. You have the power inside you to turn us back to our human forms.
    +[How?]
    +[I do? How?]
    *[Tell me what to do.]
-   There's an object you must find. It's a very powerful gemstone. You'll know it when you see it. Go. Now. -> DONE

=is_awake
Oh, my son. Thank you so much for freeing me. We don't have much time and you must be on your way. I'm sure you've got plenty of questions. I'll only have time to answer a few..
- (opts)
+[Why is this happening to me?]
    It's happening to you because you're special, my son. I know every parent thinks their child is special, but you actually are. Since you were born, strange things have happened around you. It took us some time, but we eventually realized that it was you causing it. We don't know how or why, but you have access to a great magic, son. Use it wisely. -> opts
+[Tell me about the avatar stones!]
    Stories say that when God Emperor Magnus died, his power didn't die with him - it left his body in search of a new host. The power entered the first living creature it encountered - a tiny mouse. The mouse wasn't strong enough to contain this great power, and it exploded - shattering God Emperor's power in the process. Every avatar stone is a piece of that shattered power that you can unlock, take within you and use. 
    --(stones)
    ++[How many avatar stones are there?] 
        There are 12 avatar stones altogether, as best as anyone can tell. There could be more, there could be less, it's hard to say. Very little is known about the circumstances surrounding the death of God Emperor Magnus, but there are a few people who've located a few of these avatar stones and they've studied them, and they all agree that his power split into 12 pieces.
        +++[Who are these people?]
            I do not know the names of many, but seek out Claudius and Gaius. They've studied some and can help you with more. -> stones
    ++[What kind of powers will they give?] 
        No one can say for sure, exactly. God Emperor Magnus was extremely powerful, and even a small piece of his power would eclipse almost any other sorceror in the Eternal Kingdoms. A few people have located some of these avatar stones, but no one has been able to access the power within until you just did.
        +++[Who are these people?]
            I do not know the names of many, but seek out Claudius and Gaius. They'll be able to help you with more. Even little Ajay might be able to answer some questions.
            -> stones
    ++ [No further questions] -> opts
+[What do you know about the Wizard Saints?]
    Not much, my son. The Wizard Saints are very powerful, quite nearly immortal beings. The Wizard Saint Moro Storm-Tamer lives in the castle nearby. It's said that he can control storms and even causes the seasons to change. When Moro's angry, it's said that crops will fail and the harvest will be poor. We try very hard not to anger him. -> opts
+[No more questions] 
    Good luck, my son. -> DONE

=== Mom ===
-> is_stone
=is_stone
I...<br>Love...<br>you...
-> DONE

=is_awake
Thank the eternal spirit of the God Emperor! You've freed me from that horrible state. I could feel my memories start to fade away. I don't know what I'd do if I forgot you.
-> DONE

=== Brother ===
-> is_stone
=is_stone
Haha this feels weird. Am I going to be stuck like this forever?
+ Yes
    Oh no! I don't want to be a statue forever!
+ No
    Thank god. I don't want to be a statue forever!
+ Of course not! I'll save you, baby bro!
    You're the best, big bro! I knew you'd help me...
- ->DONE

=is_awake
Hey big bro. I have a question for you. Have you got an answer for me?
+[Yes] -> yes
+[No]
    Well boo. -> DONE
+[Yeah, but you won't like my answer...] -> yes

=yes
So all of us are turned to stone. What do you think happened to all the plants and animals? Do you think they're changed too? Do you think Pup-pup is turned to stone too?
+[Hmmm. That's a very good question. Where even is Pup-pup?] -> positive
+[I don't think so! I think animals will be fine. Don't worry about Pup-pup.] -> positive
+[There's a very good chance that Pup-pup got turned to stone too. But don't worry, I'll save him too!] -> positive
+[Of course he is. Don't be stupid.] -> negative

- (positive)
Oh thank heavens. I would cry if that happened to Pup-pup. My head stuff was all weird when I was stuck like that. It was like my mind was going away. Can I ask you something else?
+[Anything you want...]
    I lost my thing. Can you go find it for me?
    **[Sure, little bro]
    #GiveQuest
        You're the best big brother ever! -> DONE
    ++[I don't have time for this!]
        You never have time for me! -> DONE
+[Not right now, I'm in a rush.]-> DONE

- (negative)
You're a mean jerk, you know that? I'm glad you're going away and it's just going to be me and mom and dad now. -> DONE

=== Villager ===
-> is_stone
=is_stone
{~Help me..|I'm so confused! What's going on?|Where am I? What's happened to me?|I can't move...<br>I can't see...<br>Am I still alive?|Hahaha *cough* haha *sob*}->DONE

=is_awake
{~Thanks for saving me!|My memories are slowly coming back. I didn't even know they were going.|All my strength is returning. It feels good to be alive again. Thank you.|If only the God Emperor was alive, we wouldn't have needed you to rescue us.} -> DONE

== Villager_1 ===
-> is_stone
=is_stone
This is all Claudius' fault. He's been messing about with things he shouldn't be again. Mark my words, when the dust settles, he'll be behind it all. Hmpf. ->DONE

=is_awake
Well, it seems I was wrong. It wasn't Claudius' fault at all. This time. I'm sure it'll be his fault next time. -> DONE

=== Claudius ===
-> is_stone
=is_stone
I, Claudius.. No, I am Error. No... Who am I? ->DONE

=is_awake
So it's true! It is possible for the power within the Avatar Stones to be released and contained. I always knew! And to think, it's you who manages to do it.
- (opts)
+[What do you mean "to think it's me who manages to do it"?]
    Well as I'm sure you know, you were born the very night that God Emperor Magnus died. Ever since you were a child, it was obvious that the old magic lived inside you and that you were strong in it. Your father and I long suspected that your birth and the God Emperor's death have caused your fates to be linked. -> opts
+[What can you tell me about the power of the Avatar Stones?]
    I've studied these stones for years. I've only come across two in my entire life, one which I kept and you've recently found, and one went to another, Gaius. Gaius and I studied these stones for years. The best we could determine was that the stone in my possession was filled with a fire that burned hotter than the sun. It seems we were correct. We never could determine the power inside the one Gaius found. All we could tell was that it too was a great power. -> opts
+[How did you determine there were 12 stones?]
    - (subopts)
    Gaius and I conducted many experiments, magical and otherwise when we were trying to unlock its mysteries. The stone carried with it a feeling of incompleteness, a sense of being one part of a whole. When we found the second stone, we got a flash of some sort of memory of being split into 12 pieces before exploding outwards. There could be more, there could be less. But if that memory's accurate, there are 12 Avatar stones altogether.
        ++[Why do you call them Avatar stones?]
            We believed that when a person was able to unlock the power within these stones, it would transform them into that piece of the God Emperor's power - an avatar of the God Emperor himself. -> subopts
        ++[A memory?]
            The essence that we draw upon that we call "magic" flows within all of us to varying degrees. This essence is as alive as you and I are. It also possesses a memory of sorts - flashes of information for those who are sensitive to it. -> subopts
        ++[No more questions] 
            OK. -> subopts
+[No more questions]
   Find Gaius. He might be able to tell you more. -> DONE

=== George ===
-> is_stone
=is_stone
Claudius and Gaius are experts on this. They'll know what to do. ->DONE

=is_awake
Can I get you to do something for me?
+[Consider it done]
#GiveQuest
    Thanks, son. -> DONE
+[Maybe later]
    You know where I'll be -> DONE
    
=== Martha ===
-> is_stone
=is_stone
Things are getting all mixed up in my head. It's only just happened and already I feel like I'm forgetting. Where's Folly? -> DONE

=is_awake
Thank you so much for saving me. You went to all this trouble for me. And on your birthday! I should go check on Folly. I'm sure Brenda was behind this. 
+[What is Folly?]
Folly is a magic sword that Brenda found a long time ago. It's as beautiful as it is powerful. She lost it in a gambling match and it made its way into my armoire... I mean hands. -> DONE

=== Ajay ===
-> is_stone
=is_stone
We let God Emperor die, so we brought this on ourselves. -> DONE

=is_awake
When mom and dad start fighting, I go over to Uncle Gaius' house and help him with his work. He's a wizard you know!
*[Have you worked on studying Avatar stones with him?]
    Sure, I've studied the Avatar stones some! Enough to know that you've unlocked the power of at least one.
        **Oh really.. [What can you tell me about them?]
            The Avatar stones are full of power. They hold more than just one kind of power though. I found that out!
                ***[More than one power? What do you mean?]
- The Avatar stones hold a second, deeper power: The power of transformation. That's what you used to set us free from the stone crysalis. Different Avatar forms will allow you to perform different transformations - as long as you use the right Awakening stone with it.
+[There's more than one Awakening stone?]
    12 Avatar forms, 12 Awakening stones. It's like poetry, they rhyme. 
    ++[Why do you call them Awakening stones?]
        All 12 of these stones return you to human form from some other state. They awaken the human within, so Uncle Gaius let me call them Awakening stones. Isn't that neat? 
        +++[You're pretty smart kid, you know that?]
            Hey thanks! You're not so bad yourself. -> DONE
    
=== Villager_6 ===
-> is_stone
=is_stone
I was just setting the table this morning for breakfast when something happened and now I'm stuck. Or was it yesterday morning? -> DONE

=is_awake
I've heard that over in the next town over, people have been turned into monsters, not statues. The Shopkeeper told me yesterday. -> DONE
    
=== Villager_7 ===
-> is_stone
=is_stone
We used to worship the Wizard Saints, and look at what they've done to us now. -> DONE

=is_awake
The Wizard Saints may be bad, but you're not. I'll gladly worship you now.
+[Oh please don't]
+[That sounds a bit creepy.]
+[I like how that sounds.]
*[Get some friends and worship me together!] #GiveDemonKarma
- You may not be <i>the</i> saviour, but you're definitely MY saviour. -> DONE

=== Villager_8 ===
-> is_stone
=is_stone
When grandma comes over, mom lets us have ice cream. I'll have my ice cream now, though. Pistachio. -> DONE

=is_awake
Thanks for saving me! Oh! It's your birthday, isn't it? Happy Birthday! {is_stone:You can have some ice cream with me too!} -> DONE

=== Villager_9 ===
-> is_stone
=is_stone
{~The Wizard Saints are behind this for sure. To think we used to worship them!|Moro Storm-Tamer is the most powerful and was the most worshipped Wizard Saint. And look where that got us.|The Wizard Saints have slowly been falling to evil since God Emperor Magnus died.That's why this is happening.|If Moro's behind this, and he is, we're all doomed. Doomed!} -> DONE

=is_awake
{~Oh I'm so relieved to be free. I didn't think we'd ever be human again.|Thank you for saving us! I never expected to be free.|When you find Moro, give him my best... right hook! Punch him right in the face for me.} -> DONE

=== Arthur ===
-> is_stone
=is_stone
I feel like I'm slowly losing my memory. Who I am is cracking. Falling apart. I'm melting... melting. -> DONE

=is_awake
Thank you so much for saving me. I can't ever thank you enough. Is there any way I can repay you for saving me?
- (opts)
+[You can answer a couple questions for me]
    Sure, what can I help you with?
    - (sub_opts)
    ++[What can you tell me about the God Emperor?]
        Not a whole heck of a lot you wouldn't already know. The God Emperor and the Wizard Saints saved us all from a great evil that they banished from the Eternal Kingdoms. He lived for over 1000 years before he somehow died. I think he was murdered, though. Mark my words. -> sub_opts
    ++[What can you tell me about the Blight?]
        When the God Emperor died, the spell he cast to save us all from the evil broke. Everything started to change after that. Dark whispers are in the air if you know how to listen for them. -> sub_opts
    ++[What can you tell me about the Wizard Saint Moro?]
        Moro is very much the most feared of the Wizard Saints. If anyone were to have murdered the God Emperor, it would have been Moro. It has been said that he has a power to rival the God Emperor's himself. He's ambitious enough to want to replace Magnus on the throne and become the new God Emperor. But it looks like his plan backfired. The Kingdoms are in ruin. -> sub_opts
    ++[I have no further questions]
        Ok. -> DONE
*[I accept all major credit cards, debit, and cold hard CASH]
    Well, I uh. You see. We're uh. We're very poor and don't have much. But if you insist I will gladly give you some of our gold.
    **[Haha, I was just kidding.]
        Thank you. You're as humorous as you are kind. -> DONE
    **[I insist]
    #GiveDemonKarma
    #GiveGold
        Well. Here you go. -> DONE
+[Nothing else but your thanks is needed.]
    You're too kind. -> DONE
    
=== Villager_11 ===
-> is_stone
=is_stone
I'm scared. What's happening? -> DONE

=is_awake
I'm so glad you saved me. You're a good friend. -> DONE

=== Villager_12 ===
-> is_stone
=is_stone
The Blight has finally reached our little town. Damn the Wizard Saints to hell. I hope Gaius and Claudius are OK. They'll know what to do. -> DONE

=is_awake
Thank you so much for helping me. Want some advice?
+[Yes]
    Go home. Now. You'll never kill Moro. He'll kill you first. -> DONE
+[No]
    Well I'm going to give it to you anyway. Go home. Now. You'll never kill Moro. He'll kill you first for sure. -> DONE

=== Brenda ===
-> is_stone
=is_stone
You're never going to find the potion I hid in the armoire, thief!
+[I'm not a thief! I'm going to help you!]
    Well thank heavens for that! -> DONE
*(thief)[What else are you hiding, lady?]
#GiveDemonKarma
    There's a health potion in the grain sack by the sink. -> DONE
    
=is_awake
{
- is_stone && not thief: 
Thanks for helping. I still think you're a thief though. -> DONE
- is_stone && thief: 
Considering you stole from us, I didn't think you'd bother to help me. I guess you're not all bad.
+[Thanks, I guess...]
    Listen. If you want to make some quick cash, I've got an opportunity for you. That is, if you choose to accept it.
    **[I'll do anything for a quick buck.]
    #GiveQuest
    #GiveDemonKarma
        Yeah I thought you would. Here, check this out.. -> DONE
    ++[I'll pass, thanks.]
        You're a much nicer person than I thought. If you change your mind though, you know where to find me. -> DONE
- else:
Thanks so much for saving me. I was sure you would turn out to be a thief though. -> DONE
        }

=== Jace ===
-> is_stone
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
-> is_stone
=is_stone
Ma's raised us alone since we was kids ever since Da' ran off.
->DONE

=is_awake
Thanks, mister!
->DONE

=== Villager_16 ===
-> is_stone
=is_stone
Oh dear, I bet those kids are running around creating a terrible mess. I can't see or hear anything like this!
->DONE

=is_awake
Oh thank goodness you saved me. I felt like my mind and my memories were slipping away.
->DONE
    
=== Villager_17 ===
-> is_stone
=is_stone
It's getting harder and harder to think. Claudius? Gaius? Is that you?-> DONE

=is_awake
Thank you so much. It was horrible being stuck in that state. -> DONE

=== Gaius ===
-> is_stone
=is_stone
Can you hear me boy? Over here. Come closer. Hello? Can you hear me? I have something important to tell you. ->DONE

=is_awake
Oh thank heavens I'm free.
{Claudius.is_awake: 
+(opts)[Gaius, is it? I have a lot of questions for you.]
    I'll bet you do my boy, I'll bet you do. I'm sure I've got answers to questions you haven't even dreamed up yet. But we have little time and I can only answer a few.
    ++[Claudius tells me you found an Avatar stone?]
        I did. Many, many years ago. Claudius and I were never able to determine what power it contained inside. The power always seemed to be shifting and elusive. I hid the stone a long time ago, some place it would be safe.
        ***[Where'd you hide it?]
            If you head over to the pond in the middle of town and look around, you'll find it there. -> opts
    ++[How did you and Claudius determine there were 12 stones?]
        I'm sure Claudius told you about how magic has its own memory? I am able to read these memories from objects and can get information about the magic, its caster and so on. I was able to glean next to no information from the individual Avatar stones, but I kept getting a sense there used to be one, but now there are 12 of them. This... sense of 12-ness was pervasive. -> opts
    ++[We're done here.]
        Good luck on your travels, boy. You'll need it. -> DONE
}
{Gaius.is_stone && not Claudius.is_awake:
+[You said you have some information for me?] -> information
    
}
{not Gaius.is_stone && not Claudius.is_awake:
<> There's a lot I have to tell you, if you've ears to hear it.
+[I've got ears for it, old man. Speak.] -> information
+[I don't have time for this right now, I'll come back later.]
    As you wish. But be sure you do come back. -> DONE
}
=information
I can see that you've discovered at least one Avatar stone. I can tell you a bit about them if you'd like...
    ++[I very much would like. What do you know?]
        Many years ago, I discovered an Avatar stone along with my friend Claudius. We studied this stone for years until we found a second one. We could never tell much about the stones, they were a mystery to us no matter what we did to get to the secrets within. We discovered one stone held a fire more powerful than the sun. The other gave us nothing. We decided that it would be best to split up the stones, as they would be dangerous in the wrong hands. Claudius kept one, and I the other. I hid this stone years ago.
        -(stones_talk)
        +++[How do you know there are 12 stones?]
            It may shock you to learn that magic has its own memory.I am able to read these memories from objects and can get information about the magic, its caster and so on. I was able to glean next to no information from the individual Avatar stones, but I kept getting a sense there used to be one, but now there are 12 of them. This... sense of 12-ness was pervasive. -> stones_talk
        +++[Where did you hide the stone?]
            If you head over to the pond in the middle of town and look around, you'll find it there. -> stones_talk
        +++[Can you tell me anything at all about the other stone's power?]
            The power always seemed to be shifting and elusive - as if it was constantly shifting. Despite how much power the stone obviously contained, the power felt faint, as if it were masked. I do not know if this was a property of the stone itself, or the power inside. -> stones_talk
        +++[I've got no other questions right now]
            Good luck on your travels, boy. You'll need it. -> DONE

=== Villager_19 ===
-> is_stone
=is_stone
Hi, I'm Billy! No you're Billy! What's a billy? Is it a cat? Am I a cat?
->DONE

=is_awake
Wow that was really scary. Thank you for saving me.
->DONE

=== Villager_20 ===
-> is_stone
=is_stone
Oh, Gaius. I hope you're not stuck like this too. You'll know what to do. You always do.
->DONE

=is_awake
Oh my dear boy. Thank you so much for saving me. I can't even begin to describe it.
->DONE

=== Villager_21 ===
-> is_stone
=is_stone
The Wizard Saints can't be behind this. They don't have this kind of power. But no, it can't be.
->DONE

=is_awake
This isn't the work of the Wizard Saints. I'm sure of that now. There's a greater evil at work here than even those bastards.
->DONE

=== Shopkeeper ===
-> is_stone
=is_stone
Shop's closed, if you can't see. The Blight's reached our little village here, if you can't tell. 
-(opts)
+[I can see, I can tell. What do you mean by "reached"?]
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
+[When will your shop reopen?]
    Maybe never, if you can't tell. I'm stuck like this and the whole world's fallen to the Blight, if you can't see. But if you can find some way to turn me back into a human, I'll open my store just for you, if you can't see. You'll need to stock up on supplies for your journey, if you can't tell. -> opts
+[No further questions]
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
+[Can you tell me anything about Moro Storm-Tamer?]
    All beings great and small can tell you something about Moro. The trick is to separate the truth from the lies.
    ++[What do you mean?]
        Moro Storm-Tamer has been worshipped like a god for many centuries. There are many and more myths and legends surrounding him than there are truths at this point. Moro encourages these myths to protect himself. From what, I don't know. It's not like many people have the power to stand up to him. -> opts
    ++[How will I know the truths from the lies?]
        Moro Storm-Tamer has been worshipped like a god for many centuries. There are many and more myths and legends surrounding him than there are truths at this point. Moro encourages these myths to protect himself. From what, I don't know. You can probably assume <i>most</i> things you hear about him to be false, at least to some degree. -> opts
+[No further questions]
    Good luck on your travels. You'll need it. -> DONE
    
=== Shopkeeper_Graveyard ===
-> is_stone
=is_stone
{Shopkeeper.is_stone:
You found me here too, if you can't see. I'm a fast and sneaky little bugger, if you can't tell. Maybe one day I'll tell you how I got here before you, if you can't see. -> DONE
- else:
I'm the gravekeper here, if you can't see. But I'm also the Shopkeeper, if you can't tell. You'll find me by the market stalls in the daytime if you can't tell. -> DONE
}

=is_awake
During the daytime, I run my market shop. In the evenings, I have to work at the cemetery. It's getting harder and harder to make ends meet. -> DONE
    
=== Castle_Guard ===
-> is_stone
=is_stone
There's no getting by us. Nope. Not at all. *sob* Change us back and we'll let you through -> DONE
=is_awake
Well. That worked like a charm. Still not getting through though -> DONE

=== ForestDweller ===
-> is_stone
=is_stone
There's a dark energy coming from the northeast corner of the forest. Can't you feel it? -> DONE

=== ForestDweller_1 ===
-> is_stone
=is_stone
Things are getting very weird since God Emperor Magnus died. I didn't even know he could die. I thought he was immortal... -> DONE

=== ForestDweller_2 ===
-> is_stone
=is_stone
There's a haunted house in the forest. It's getting more and more haunted every day. Have you seen its eerie green glow yet?<br><br>Stay away from it. Stay very far away from it.-> DONE

=== ForestDweller_3 ===
-> is_stone
=is_stone
There are so many monsters in the forest these days. I want to run away, but for some reason I can't. What's wrong with my legs? -> DONE

=== ForestDweller_4 ===
-> is_stone
=is_stone
You're a wizard, aren't you? I can tell.-> DONE

=== ForestDweller_5 ===
-> is_stone
=is_stone
I'm just a simple hermit living in the forest. Why is this happening to me? What's going on? -> DONE