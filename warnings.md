# Warnings

# 1) 

The first time that you run GLIDE, do not close it before the lesson, problem, and answer choice images, are displayed. There is a risk of the building of the database not completing, and the program will crash, next time it is opened, if this happens.

# 2) 

After completing all of the problems to a lesson, do not close GLIDE, before the images for the next lesson appear, or the message displays to notify you that there is nothing more to study today. Again, the database may not completely build, and not only will the program crash upon it's next start up, but you will lose all of your progress.

# Solving 1 & 2

The first problem I listed, is very easy for me to solve. It simply requires a catch-try block.

The second problem, of possibly losing all the saved progress, requires me to build a system for the user to back the database file up to the location of the user's choosing. The try-catch block for the first issue, will have to prompt the user for to choose the file location of the saved database, or to choose the file that was automatically backed up.

These problems exist, because I currently only know how to implement a database with C#, exactly the way that the program currently does. For a single course; using a text file, or json file, would be an easy work around. But, I think a database is the best storage solution in the long run. These two issues will not exist after a short amount of time from now, and it saves the updates from having extra code built, just to convert the information in these files to a database. My concern was getting an application built first, that works, so that I can learn everything that I need to make it better, along with a lot of other new stuff, in a very short amount of time once it worked. Now it does work, so this app will improve greatly within a short amount of time.

In the mean time; occasionally make a back up of the database file. I would copy-and-paste that file to a thumb drive, before every study session for the day, just incase the electricty goes out, or my laptop battery falls out. My laptop's battery lock doesn't work well a lot of the time.


# 3) Course Design

For the personal courses of any particular user; creating the problem images, and answer images, will not always be as simple as copy and pasting, from an e-book, or from images of a physical book. A lot of text books have "filler" material. The authors will often write many lines, that would not hurt the material if it were scribled over, before making their point that a student needs to learn. Often, this filler material consists of a lot of bad jokes, needless analogies, or sometimes they just love making people read a lot to find the knowledge that the reader needs to learn. This is even true for a GPL algebra book that I looked into copying and pasting, to make a course for GLIDE to offer right away. I am guessing that about 60% of that book was filler material, and that person wasn't even getting paid per page.

If you make a course for yourself, you will not fully benefit from GLIDE, if you copy and paste the filler material that is present, in many of the textbooks available. For every topic of a text book that you want GLIDE to teach you, you need to leave all of that filler material out. In the context of GLIDE, a topic is the smallest section of a chapter.
