#
#gcc compilation aliases:c89, c99, debug mode, release mode
alias gd='gcc -ansi -pedantic-errors -Wall -Wextra -g -Og'
alias gc='gcc -ansi -pedantic-errors -Wall -Wextra -DNDEBUG -O3'
alias gd9='gcc -std=c99 -pedantic-errors -Wall -Wextra -g -Og'
alias gc9='gcc -std=c99 -pedantic-errors -Wall -Wextra -DNDEBUG -O3'
#

#cpp compilation aliases
alias gdpp='g++ -ansi -pedantic-errors -Wall -Wextra -g -Og'
alias gcpp='g++ -ansi -pedantic-errors -Wall -Wextra -DNDEBUG -O3'

alias gdpp11='g++ -std=c++11 -pedantic-errors -Wall -Wextra -g -Og'
alias gcpp11='g++ -std=c++11 -pedantic-errors -Wall -Wextra -DNDEBUG -O3'
#
#clang compilation aliases:c89, c99, debug mode, release mode
alias clgd='clang -ansi -pedantic-errors -Wall -Wextra -g -Og'
alias clgc='clang -ansi -pedantic-errors -Wall -Wextra -DNDEBUG -O3'
alias clgd9='clang -std=c99 -pedantic-errors -Wall -Wextra -g -Og'
alias clgc9='clang -std=c99 -pedantic-errors -Wall -Wextra -DNDEBUG -O3'


# Valgrind alias
alias vlg='valgrind --leak-check=yes --track-origins=yes'
#
#git alias
alias gpsh="git push -u origin master"
alias gpll="git pull origin master"
alias gcm="git commit -m"

#change working directory alias
alias cdd="cd ~/Downloads" 

#usage example: get hrd11 ws8
function find_rd() { find $1 -name "$2*" -type f; }

function get() {    geany -n  `find_rd ~/InfinityLabs/$1/ $2`; }

function find_rd_dir() { find $1 -name "$2*" -type d; }
function getVSCode() {    code -n  `find_rd_dir ~/InfinityLabs/$1/ $2`; }

function pull_lab()
{
    ~/pull_lab $1;
}

function gitdisp(){
    export PS1='\[\e]0;\u@\h: \w\a\]${debian_chroot:+($debian_chroot)}\[\033[01;32m\]\u@\h\[\033[00m\]:\[\033[01;34m\]\w\[\033[0;32m\]$(__git_ps1)\[\033[00m\]\$ '
}

function disp(){
    export PS1='\[\e]0;\u@\h: \w\a\]${debian_chroot:+($debian_chroot)}\[\033[01;32m\]\u@\h\[\033[00m\]:\[\033[01;34m\]\w\[\033[00m\]\$ '
}

declare SUBJECT;
declare TOPIC;
EXIT_MSG="doesnt exist - exiting..";
declare -A subjects=( ["c"]="c" ["ds"]="data_structures" ["q"]="quizzes" ["sp"]="system_programming" )   

function get_subject()
{
    if [ -v ${subjects[$SUBJECT]} ];
    then
        echo -e "please enter:"
        for s in "${!subjects[@]}"
        do
            echo "$s : ${subjects[$s]}"
        done
        read SUBJECT
        if [ -v ${subjects[$SUBJECT]} ];
        then return 1; 
        fi;
    fi;
    SUBJECT=${subjects[$SUBJECT]}; 

}

function get_topic()
{
    NUM=1; 
    echo -e "please enter:"
    for  t in `ls ~/Syllabus/ol_syllabus/$SUBJECT`
    do 
        echo "$NUM $t"
        ((NUM++));
    done;
    read LINE; 
    if [ $LINE -ge $NUM ] 
    then return 2;
    fi;
    TOPIC=`ls ~/Syllabus/ol_syllabus/$SUBJECT | head -n $LINE | tail -1`;

}

function find_topic()
{ 
    if [[ $# -ne 2 ]]
    then 
        echo "usage is: find_topic <subject_name> <topic_name>"
        return 3;
    fi;
    SUBJECT="$1"  
    if [ ! -e ~/Syllabus/ol_syllabus/$1/ ]; 
    then get_subject
        if [ $? -eq 1 ]
        then echo $EXIT_MSG;
             return 1
        fi;
    fi;
    TOPIC="$2";
    if [ ! -e  ~/Syllabus/ol_syllabus/$SUBJECT/$2 ];
    then echo "dir: ~/Syllabus/ol_syllabus/$1/$2 doesnt exist"
        get_topic
        if [ $? -eq 2 ]
        then echo $EXIT_MSG;
             return 1
        fi;
    fi;
    code ~/Syllabus/ol_syllabus/$SUBJECT/$TOPIC/solution/*;
}

function open_vscode()
{
    for name in `ls ~/InfinityLabs/$1`;
    do
        DIR_NAME="/tmp/${name}_${1}"
        if [ -e  $DIR_NAME ];
        then rm -r $DIR_NAME;
        fi;
        mkdir $DIR_NAME
        for file in `find ~/InfinityLabs/$1/$name -name "$2*" -type f`;
        do
            cp $file $DIR_NAME
        done;
    done;
    code `find /tmp/ -name "*_$1" -type d 2>/dev/null`
    code -r `find /tmp/*_$1 -name "*" -type f 2>/dev/null`  
}


