# 360_Project
Script for our game draft. 

NOTE - Game Project in Unity will vary from dev to dev. 
Just do whatever works

How to setup dev environment:

Install git for windows - https://gitforwindows.org/

after install, open cmd
run (substituting your information):
git config --global user.email 'username@email.com"
git config --global user.name 'My Name'
close cmd

This is how you add the repository to vs

select the source control button on the left
clone repository
paste: https://github.com/StephG646/360_Project into the url box
select a folder to save it (documents or something)
click open in the bottom right
select yes, I trust the authors
On the top bar, select the terminal menu, followed by new terminal (if one isn't already open)

make sure the current directory is where the git folder is saved (last part should be \CareWare>)
if not, cd to where you saved the git repo in the earlier step
run: npm install


After modifying a file (or multiple)

go to the source control page
click the three dots, then pull. This forcefully pulls down any changes made by others currently on github
click the plus button next to any changes you want to commit (or do all)
enter a commit message (like: "add home page" or "fix login bug", don't use past tense)
press the check mark to commit (this commits your changes locally to git, you will still need to push these up to github for others to see them)
press the sync button
If this is your first commit/push:
a github sign in box appears
sign in using your browser
after signing in, close the browser
click yes on the pop up in the corner "would you like code to periodically run git fetch"
